using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.Interfaces
{
    // Event args for playback progress
    public class PlaybackProgressEventArgs : EventArgs
    {
        public double CurrentPosition { get; set; }
        public double Duration { get; set; }
    }

    public interface IAudioPlayer
    {
        void Play(string filePath);
        void Pause();
        void Stop();
        void SetVolume(int volume);
        double CurrentPosition { get; }
        double Duration { get; }
        bool IsPlaying { get; }
        event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;
    }

    // UI Scaling interface
    public interface IScalableControl
    {
        void StoreOriginalDimensions();
        void Scale(float widthRatio, float heightRatio);
    }
}