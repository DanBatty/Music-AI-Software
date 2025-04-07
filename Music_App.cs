using Music_AI_Software.Interfaces;
using Music_AI_Software.Players;
using Music_AI_Software.UI;

namespace Music_AI_Software
{
    public partial class Music_App : Form
    {
        private IAudioPlayer audioPlayer;
        private FormScaler formScaler;

        public Music_App()
        {
            InitializeComponent();

            formScaler = new FormScaler(this);

            audioPlayer = new WmpAudioPlayer(trackPlayer);

            audioPlayer.PlaybackProgress += AudioPlayer_PlaybackProgress;

            sliderVolume1.ValueChanged += SliderVolume1_ValueChanged;
            sliderVolume2.ValueChanged += SliderVolume2_ValueChanged;
        }

        private void SliderVolume1_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer.SetVolume(sliderVolume1.Value);
            sliderVolume2.Value = sliderVolume1.Value;
        }

        private void SliderVolume2_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer.SetVolume(sliderVolume2.Value);
            sliderVolume1.Value = sliderVolume2.Value;
        }

        private void AudioPlayer_PlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdatePlaybackUI(e)));
            }
            else
            {
                UpdatePlaybackUI(e);
            }
        }

        private void UpdatePlaybackUI(PlaybackProgressEventArgs e)
        {
            // Format times as mm:ss
            TimeSpan currentTime = TimeSpan.FromSeconds(e.CurrentPosition);
            TimeSpan totalTime = TimeSpan.FromSeconds(e.Duration);

            labelTrackStart.Text = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";
            lblTrackEnd.Text = $"{totalTime.Minutes:D2}:{totalTime.Seconds:D2}";

            // Update progress bar
            if (e.Duration > 0)
            {
                progressBar1.Value = (int)((e.CurrentPosition / e.Duration) * 100);
            }
            else
            {
                progressBar1.Value = 0;
            }
        }

        string[] paths, files;

        private void Music_App_Load(object sender, EventArgs e)
        {
            // Initialize the volume sliders
            sliderVolume1.Maximum = 100;
            sliderVolume2.Maximum = 100;
            sliderVolume1.Value = 50;
            sliderVolume2.Value = 50;

            // Set initial volume
            audioPlayer.SetVolume(sliderVolume1.Value);
        }

        private void trackMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.wma;*.aac;*.m4a|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;

                listSongs.Items.Clear();
                for (int x = 0; x < files.Length; x++)
                {
                    listSongs.Items.Add(files[x]);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex >= 0)
            {
                audioPlayer.Play(paths[listSongs.SelectedIndex]);
            }
        }

        private void listSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex >= 0)
            {
                audioPlayer.Play(paths[listSongs.SelectedIndex]);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            audioPlayer?.Stop();
        }
    }
}