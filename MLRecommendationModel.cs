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
    }
}