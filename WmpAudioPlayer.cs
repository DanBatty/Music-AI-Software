using Music_AI_Software.Interfaces;
using System;
using System.Windows.Forms;
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
            if (IsPlaying)
            {
                OnPlaybackProgress(CurrentPosition, Duration);
            }
        }

        public event EventHandler<PlaybackProgressEventArgs> PlaybackProgress;

        public void Play(string filePath)
        {
            player.URL = filePath;
            player.Ctlcontrols.play();
            progressTimer.Start();
        }

        public void Pause()
        {
            player.Ctlcontrols.pause();
        }

        public void Stop()
        {
            player.Ctlcontrols.stop();
            progressTimer.Stop();
        }

        public double CurrentPosition => player.Ctlcontrols.currentPosition;
        public double Duration => player.currentMedia?.duration ?? 0;
        public bool IsPlaying => player.playState == WMPLib.WMPPlayState.wmppsPlaying;

        public void SetVolume(int volume)
        {
            player.settings.volume = Math.Clamp(volume, 0, 100);
        }

        protected void OnPlaybackProgress(double position, double duration)
        {
            PlaybackProgress?.Invoke(this, new PlaybackProgressEventArgs
            {
                CurrentPosition = position,
                Duration = duration
            });
        }
    }
}