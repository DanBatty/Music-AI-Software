using Music_AI_Software.Interfaces;
using NAudio.Wave;
using System;
using System.Windows.Forms;
using System.IO;

namespace Music_AI_Software.Players
{
    /// <summary>
    /// Implements IAudioPlayer using NAudio library to provide audio playback functionality.
    /// </summary>
    public class NAudioPlayer : IAudioPlayer, IDisposable
    {
        /// <summary>
        /// The audio output device.
        /// </summary>
        private IWavePlayer waveOutDevice;

        /// <summary>
        /// The audio file reader.
        /// </summary>
        private AudioFileReader audioFileReader;

        /// <summary>
        /// Timer used to track playback progress and trigger events.
        /// </summary>
        private System.Windows.Forms.Timer progressTimer;

        /// <summary>
        /// The current audio file path.
        /// </summary>
        private string currentFilePath;

        /// <summary>
        /// Initializes a new instance of the NAudioPlayer class.
        /// </summary>
        public NAudioPlayer()
        {
            progressTimer = new System.Windows.Forms.Timer
            {
                Interval = 500 // Update every half second
            };
            progressTimer.Tick += ProgressTimer_Tick;
        }

        /// <summary>
        /// Handles timer tick events to update playback progress.
        /// </summary>
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (IsPlaying && audioFileReader != null)
            {
                OnPlaybackProgress(CurrentPosition, Duration);
            }
        }

        /// <summary>
        /// Event raised when playback progress updates.
        /// </summary>
        public event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;

        /// <summary>
        /// Plays audio from the given file path.
        /// </summary>
        /// <param name="filePath">The file path to the audio file to play.</param>
        /// <exception cref="ArgumentNullException">Thrown if filePath is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
        public void Play(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Audio file not found", filePath);

            Stop();

            try
            {
                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);

                waveOutDevice.Play();
                progressTimer.Start();
                currentFilePath = filePath;
            }
            catch (Exception ex)
            {
                CleanupResources();
                throw new InvalidOperationException($"Failed to play audio file: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Pauses the current playback.
        /// </summary>
        public void Pause()
        {
            waveOutDevice?.Pause();
        }

        /// <summary>
        /// Stops the current playback and resets the playback position.
        /// </summary>
        public void Stop()
        {
            progressTimer.Stop();

            if (waveOutDevice != null)
            {
                if (waveOutDevice.PlaybackState != PlaybackState.Stopped)
                {
                    waveOutDevice.Stop();
                }
            }

            CleanupResources();
        }

        /// <summary>
        /// Gets the current playback position in seconds.
        /// </summary>
        public double CurrentPosition
        {
            get
            {
                if (audioFileReader == null) return 0;
                return audioFileReader.CurrentTime.TotalSeconds;
            }
        }

        /// <summary>
        /// Gets the total duration of the current media in seconds.
        /// </summary>
        public double Duration
        {
            get
            {
                if (audioFileReader == null) return 0;
                return audioFileReader.TotalTime.TotalSeconds;
            }
        }

        /// <summary>
        /// Boolean value indicating whether audio is currently playing.
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                return waveOutDevice != null &&
                       waveOutDevice.PlaybackState == PlaybackState.Playing;
            }
        }

        /// <summary>
        /// Sets the playback volume.
        /// </summary>
        /// <param name="volume">Volume level from 0 to 100.</param>
        public void SetVolume(int volume)
        {
            if (audioFileReader != null)
            {
                // NAudio uses a 0.0 to 1.0 scale for volume
                float normalizedVolume = Math.Clamp(volume, 0, 100) / 100f;
                audioFileReader.Volume = normalizedVolume;
            }
        }

        /// <summary>
        /// Raises the PlaybackProgress event with current playback information.
        /// </summary>
        /// <param name="position">Current playback position in seconds.</param>
        /// <param name="duration">Total duration in seconds.</param>
        protected void OnPlaybackProgress(double position, double duration)
        {
            PlaybackProgress?.Invoke(this, new PlaybackProgressEventArgs
            {
                CurrentPosition = position,
                Duration = duration
            });
        }

        /// <summary>
        /// Cleans up audio resources.
        /// </summary>
        private void CleanupResources()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        /// <summary>
        /// Disposes resources used by the NAudioPlayer.
        /// </summary>
        public void Dispose()
        {
            Stop();
            progressTimer?.Dispose();
        }
    }
}