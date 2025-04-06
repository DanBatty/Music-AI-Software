using Music_AI_Software.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.Players
{
    public class WmpAudioPlayer : IAudioPlayer
    {
        private readonly AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.Timer progressTimer;

        public WmpAudioPlayer(AxWMPLib.AxWindowsMediaPlayer player)
        {
            this.player = player;

            progressTimer = new System.Windows.Forms.Timer
            {
                Interval = 500 // Update every half second
            };
            progressTimer.Tick += ProgressTimer_Tick;
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
        }

        public event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;

        public void Play(string filePath)
        {

        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }

        public void SetVolume(int volume)
        {

        }

    }
}
