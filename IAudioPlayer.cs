using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.Interfaces
{
    /// <summary>
    /// Event arguments for playback progress updates such as playback position and total duration.
    /// </summary>
    public class PlaybackProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Get/set the current playback position in seconds.
        /// </summary>
        public double CurrentPosition { get; set; }

        /// <summary>
        /// Get/set the total duration of the current media in seconds.
        /// </summary>
        public double Duration { get; set; }
    }

    /// <summary>
    /// Definition for audio player implementations. Includes a series of methods and properties for controlling media playback.
    /// </summary>
    public interface IAudioPlayer
    {
        /// <summary>
        /// Plays audio from the given file path.
        /// </summary>
        /// <param name="filePath">The file path to the audio file to play.</param>
        void Play(string filePath);

        /// <summary>
        /// Pauses the current playback.
        /// </summary>
        void Pause();

        /// <summary>
        /// Stops the current playback and resets the playback position.
        /// </summary>
        void Stop();

        /// <summary>
        /// Sets the playback volume.
        /// </summary>
        /// <param name="volume">Volume level from 0 to 100.</param>
        void SetVolume(int volume);

        /// <summary>
        /// Gets the current playback position in seconds.
        /// </summary>
        double CurrentPosition { get; }

        /// <summary>
        /// Gets the total duration of the current media in seconds.
        /// </summary>
        double Duration { get; }

        /// <summary>
        /// Boolean value indicating whether audio is currently playing.
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// Handles playback progress event changes. Can be used to update UI elements with current playback information.
        /// </summary>
        event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;
    }
}