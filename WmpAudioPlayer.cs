using Music_AI_Software.Interfaces;
using System;
using System.Windows.Forms;

namespace Music_AI_Software.Players
{
    /// <summary>
    /// Implements IAudioPlayer using Windows Media Player controls and provides audio playback 
    /// functionality through the AxWindowsMediaPlayer component.
    /// </summary>
    public class WmpAudioPlayer : IAudioPlayer
    {
        /// <summary>
        /// The underlying Windows Media Player control.
        /// </summary>
        private readonly AxWMPLib.AxWindowsMediaPlayer player;

        /// <summary>
        /// Timer used to track playback progress and trigger events.
        /// </summary>
        private System.Windows.Forms.Timer progressTimer;

        /// <summary>
        /// Initializes a new instance of the WmpAudioPlayer class.
        /// </summary>
        /// <param name="player">Windows Media Player control to use for playback. Cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown if player is null.</exception>
        public WmpAudioPlayer(AxWMPLib.AxWindowsMediaPlayer player)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));

            progressTimer = new System.Windows.Forms.Timer
            {
                Interval = 500 // Update every half second
            };
            progressTimer.Tick += ProgressTimer_Tick;
        }

        /// <summary>
        /// Handles timer tick events to update playback progress.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (IsPlaying)
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
        public void Play(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            player.URL = filePath;
            player.Ctlcontrols.play();
            progressTimer.Start();
        }

        /// <summary>
        /// Pauses the current playback.
        /// </summary>
        public void Pause()
        {
            player.Ctlcontrols.pause();
        }

        /// <summary>
        /// Stops the current playback and resets the playback position.
        /// </summary>
        public void Stop()
        {
            player.Ctlcontrols.stop();
            progressTimer.Stop();
        }

        /// <summary>
        /// Gets the current playback position in seconds.
        /// </summary>
        public double CurrentPosition => player.Ctlcontrols.currentPosition;

        /// <summary>
        /// Gets the total duration of the current media in seconds. Returns 0 if no media is 
        /// loaded or if the duration cannot be found.
        /// </summary>
        public double Duration => player.currentMedia?.duration ?? 0;

        /// <summary>
        /// Boolean value indicating whether audio is currently playing.
        /// </summary>
        public bool IsPlaying => player.playState == WMPLib.WMPPlayState.wmppsPlaying;

        /// <summary>
        /// Sets the playback volume.
        /// </summary>
        /// <param name="volume">Volume level from 0 to 100.</param>
        /// <remarks>
        /// Values outside the range of 0-100 are clamped to the nearest valid value.
        /// </remarks>
        public void SetVolume(int volume)
        {
            player.settings.volume = Math.Clamp(volume, 0, 100);
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
        /// Releases resources used by the WmpAudioPlayer.
        /// </summary>
        public void Dispose()
        {
            progressTimer?.Stop();
            progressTimer?.Dispose();
            progressTimer = null;
        }
    }
}