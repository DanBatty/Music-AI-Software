using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Music_AI_Software
{
    /// <summary>
    /// ML.NET based recommendation for suggesting similar tracks.
    /// </summary>
    public class MLRecommendationModel
    {
        private readonly MLContext mlContext;
        private ITransformer model;
        private PredictionEngine<TrackSimilarityInput, TrackSimilarityPrediction> predictionEngine;
        private readonly MusicAnalyser musicAnalyser;
        private List<TrackFeatures> trackFeatures;

        /// <summary>
        /// Initializes a new instance of the recommendation engine.
        /// </summary>
        public MLRecommendationModel()
        {
            mlContext = new MLContext(seed: 0);
            musicAnalyser = new MusicAnalyser();
            trackFeatures = new List<TrackFeatures>();
        }

        /// <summary>
        /// Represents an input for track similarity prediction.
        /// </summary>
        public class TrackSimilarityInput
        {
            [LoadColumn(0)]
            public string SourceTrackId { get; set; }

            [LoadColumn(1)]
            public string CandidateTrackId { get; set; }

            [LoadColumn(2)]
            public float BpmDifference { get; set; }
        }

        /// <summary>
        /// Represents a similarity prediction between two tracks.
        /// </summary>
        public class TrackSimilarityPrediction
        {
            public float Score { get; set; }
        }

        /// <summary>
        /// Represents training data for track similarity with both input features and label.
        /// </summary>
        public class TrackSimilarityData : TrackSimilarityInput
        {
            public float Label { get; set; }
        }

        /// <summary>
        /// Analyzes a list of music files to extract features for recommendation.
        /// </summary>
        /// <param name="filePaths">List of paths to music files</param>
        public async Task AnalyzeLibraryAsync(IEnumerable<string> filePaths)
        {
            trackFeatures.Clear();

            foreach (var filePath in filePaths)
            {
                try
                {
                    var features = await musicAnalyser.ExtractFeaturesAsync(filePath);
                    if (features.BPM > 0)
                    {
                        trackFeatures.Add(features);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error analyzing file {filePath}: {ex.Message}");
                }
            }

            if (trackFeatures.Count > 1)
            {
                BuildModel();
            }
        }

        /// <summary>
        /// Creates training data for the ML model based on track similarities.
        /// </summary>
        private List<(TrackSimilarityInput Data, float Label)> CreateTrainingData()
        {
            var trainingData = new List<(TrackSimilarityInput, float)>();

            // Create comparisons of all tracks in pairs
            for (int i = 0; i < trackFeatures.Count; i++)
            {
                for (int j = 0; j < trackFeatures.Count; j++)
                {
                    if (i == j) continue;

                    var sourceTrack = trackFeatures[i];
                    var candidateTrack = trackFeatures[j];

                    float bpmDifference = (float)Math.Abs(sourceTrack.BPM - candidateTrack.BPM);

                    // Lower BPM difference = higher similarity
                    float similarityScore = 1.0f - Math.Min(bpmDifference / 40.0f, 1.0f);

                    var input = new TrackSimilarityInput
                    {
                        SourceTrackId = sourceTrack.FilePath,
                        CandidateTrackId = candidateTrack.FilePath,
                        BpmDifference = bpmDifference
                    };

                    trainingData.Add((input, similarityScore));
                }
            }

            return trainingData;
        }

        /// <summary>
        /// Builds the ML model based on analysed tracks.
        /// </summary>
        private void BuildModel()
        {
            var trainingData = CreateTrainingData();
            if (trainingData.Count == 0) return;

            // Define data preparation pipeline
            var pipeline = mlContext.Transforms.Concatenate(
                "Features",
                nameof(TrackSimilarityInput.BpmDifference))
                .Append(mlContext.Regression.Trainers.Sdca(
                    labelColumnName: "Label",
                    featureColumnName: "Features"));

            // Convert training data to the format expected by ML.NET
            var mlData = trainingData.Select(pair => new TrackSimilarityData
            {
                SourceTrackId = pair.Data.SourceTrackId,
                CandidateTrackId = pair.Data.CandidateTrackId,
                BpmDifference = pair.Data.BpmDifference,
                Label = pair.Label
            });

            var dataView = mlContext.Data.LoadFromEnumerable(mlData);
            model = pipeline.Fit(dataView);

            predictionEngine = mlContext.Model.CreatePredictionEngine<TrackSimilarityInput, TrackSimilarityPrediction>(model);
        }

        /// <summary>
        /// Gets recommended tracks similar to the provided track.
        /// </summary>
        /// <param name="trackPath">Path to the source track</param>
        /// <param name="count">Number of recommendations to return</param>
        /// <returns>List of recommended track file paths in order of similarity</returns>
        public async Task<List<string>> GetRecommendationsAsync(string trackPath, int count = 5)
        {
            if (trackFeatures.Count < 2 || model == null)
                return new List<string>();

            TrackFeatures sourceTrack = trackFeatures.FirstOrDefault(t => t.FilePath == trackPath);
            if (sourceTrack == null)
            {
                sourceTrack = await musicAnalyser.ExtractFeaturesAsync(trackPath);
                if (sourceTrack.BPM <= 0)
                    return new List<string>(); 
            }

            var predictions = new List<(string FilePath, float Score)>();
            foreach (var candidateTrack in trackFeatures)
            {
                if (candidateTrack.FilePath == trackPath) continue; 

                var input = new TrackSimilarityInput
                {
                    SourceTrackId = sourceTrack.FilePath,
                    CandidateTrackId = candidateTrack.FilePath,
                    BpmDifference = (float)Math.Abs(sourceTrack.BPM - candidateTrack.BPM)
                };

                var prediction = predictionEngine.Predict(input);
                predictions.Add((candidateTrack.FilePath, prediction.Score));
            }
            return predictions
                .OrderByDescending(p => p.Score)
                .Take(count)
                .Select(p => p.FilePath)
                .ToList();
        }
    }
}