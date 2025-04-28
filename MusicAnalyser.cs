using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Music_AI_Software
{
    /// <summary>
    /// Provides functionality for analyzing music files to extract features.
    /// Currently supports BPM and energy levels.
    /// </summary>
    public class MusicAnalyser
    {
        private const int MIN_BPM = 60;
        private const int MAX_BPM = 200;
        private const int SAMPLE_RATE = 44100;
        private const int CHUNK_SIZE = 2048;
        private const int HISTORY_SIZE = 43; // For averaging, about 1 second of music at 44.1kHz

        /// <summary>
        /// Analyzes the BPM of a track from the given file path. 
        /// Uses async task processing to try and alleviate UI freezing.
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>The detected BPM value or -1 if detection failed</returns>
        public async Task<double> AnalyzeBpmAsync(string filePath)
        {
            try
            {
                return await Task.Run(() => AnalyzeBpm(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error analyzing BPM: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Analyzes the BPM of a track from the given file path.
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>The detected BPM value or -1 if detection failed</returns>
        public double AnalyzeBpm(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Audio file not found", filePath);

            using (var audioFile = new AudioFileReader(filePath))
            {
                // Convert to mono for easier processing
                var sampleProvider = audioFile.ToSampleProvider();
                var monoProvider = sampleProvider.ToMono();

                float[] chunk = new float[CHUNK_SIZE];
                List<float> energyHistory = new List<float>();
                List<int> beatIndices = new List<int>();

                int samplesRead;
                int sampleCount = 0;

                // Process only a portion of the song for efficiency
                // 1 minute or the full song, whichever is shorter
                int maxSamplesToProcess = Math.Min(SAMPLE_RATE * 60, (int)audioFile.Length);

                while ((samplesRead = monoProvider.Read(chunk, 0, CHUNK_SIZE)) > 0 && sampleCount < maxSamplesToProcess)
                {
                    float energy = CalculateEnergy(chunk, samplesRead);
                    energyHistory.Add(energy);

                    // If histroy is long enough, detect if this is a beat
                    if (energyHistory.Count > HISTORY_SIZE)
                    {
                        // Get the local average energy excluding the current value
                        float localAvg = energyHistory
                            .Skip(energyHistory.Count - HISTORY_SIZE)
                            .Take(HISTORY_SIZE - 1)
                            .Average();

                        float threshold = localAvg * 1.3f;

                        // If current energy is significantly higher than local average, it's likely a beat
                        if (energy > threshold && energy > 0.01)
                        {
                            beatIndices.Add(sampleCount);
                        }

                        // Remove oldest history once we have enough
                        if (energyHistory.Count > HISTORY_SIZE * 2)
                            energyHistory.RemoveAt(0);
                    }

                    sampleCount += samplesRead;
                }

                // Calculate BPM from beat intervals
                return CalculateBpmFromBeats(beatIndices, SAMPLE_RATE);
            }
        }

        /// <summary>
        /// Calculates the energy (intensity) of an audio chunk.
        /// </summary>
        private float CalculateEnergy(float[] samples, int count)
        {
            float sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += samples[i] * samples[i]; // Square of amplitude
            }
            return sum / count;
        }

        /// <summary>
        /// Calculates BPM from a list of beat indices.
        /// </summary>
        private double CalculateBpmFromBeats(List<int> beatIndices, int sampleRate)
        {
            if (beatIndices.Count < 4) // Need at least a few beats to calculate
                return -1;

            // Calculate intervals between beats
            List<int> intervals = new List<int>();
            for (int i = 1; i < beatIndices.Count; i++)
            {
                intervals.Add(beatIndices[i] - beatIndices[i - 1]);
            }

            // Filter out outliers (too short or too long intervals)
            int medianInterval = intervals.OrderBy(i => i).ElementAt(intervals.Count / 2);
            var filteredIntervals = intervals.Where(i => i > medianInterval * 0.5 && i < medianInterval * 1.5).ToList();

            if (filteredIntervals.Count < 2)
                return -1;

            double avgInterval = filteredIntervals.Average();

            double bpm = (60.0 * sampleRate) / avgInterval;

            // Ensure BPM is in reasonable range
            if (bpm < MIN_BPM)
                bpm *= 2; // Double if too slow
            else if (bpm > MAX_BPM)
                bpm /= 2; // Half if too fast

            return Math.Round(bpm, 1); // Round to 1 decimal place
        }

        /// <summary>
        /// Extracts multiple features from a track for use in ML recommendation.
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>A TrackFeatures object containing extracted features</returns>
        public async Task<TrackFeatures> ExtractFeaturesAsync(string filePath)
        {
            var features = new TrackFeatures
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                BPM = await AnalyzeBpmAsync(filePath)
            };

            return features;
        }
    }

    /// <summary>
    /// Represents the extracted features of a track for use in ML recommendations.
    /// </summary>
    public class TrackFeatures
    {
        /// <summary>
        /// Full file path to the track
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// File name of the track
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Beats per minute of the track
        /// </summary>
        public double BPM { get; set; }

        // TODO: Add more features such as key/artist
    }
}