using Music_AI_Software.Interfaces;
using Music_AI_Software.Players;
using Music_AI_Software.UI;

namespace Music_AI_Software
{
    public partial class Music_App : Form
    {
        private float originalWidth;
        private float originalHeight;
        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        private IAudioPlayer audioPlayer;

        public Music_App()
        {
            InitializeComponent();

            audioPlayer = new WmpAudioPlayer(trackPlayer);

            this.Load += Music_App_Load;
            this.Resize += Music_App_Resize;

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
            originalWidth = this.ClientSize.Width;
            originalHeight = this.ClientSize.Height;

            StoreAllControlDimensions();

            sliderVolume1.Maximum = 100;
            sliderVolume2.Maximum = 100;
            sliderVolume1.Value = 50;
            sliderVolume2.Value = 50;

            //Initial volume
            audioPlayer.SetVolume(sliderVolume1.Value);
        }

        private void StoreAllControlDimensions()
        {
            StoreControlDimensions(this);
        }

        private void StoreControlDimensions(Control container)
        {
            foreach (Control control in container.Controls)
            {
                // Store dimensions for all controls
                originalControls[control] = new Rectangle(
                    control.Left, control.Top, control.Width, control.Height);

                if (control.Font != null)
                {
                    originalFontSizes[control] = control.Font.Size;
                }

                // If this control has children, store their dimensions too
                if (control.Controls.Count > 0)
                {
                    StoreControlDimensions(control);
                }
            }
        }

        private void Music_App_Resize(object sender, EventArgs e)
        {
            if (originalControls.Count == 0 || originalWidth == 0 || originalHeight == 0)
                return;

            // Calculate scaling factors based on client size (not window size)
            float widthRatio = (float)this.ClientSize.Width / originalWidth;
            float heightRatio = (float)this.ClientSize.Height / originalHeight;

            // Apply scaling
            ScaleAllControls(this, widthRatio, heightRatio);
        }

        private void ScaleAllControls(Control container, float widthRatio, float heightRatio)
        {
            foreach (Control control in container.Controls)
            {
                if (originalControls.ContainsKey(control))
                {
                    Rectangle original = originalControls[control];

                    // Scale position and size
                    control.Left = (int)(original.Left * widthRatio);
                    control.Top = (int)(original.Top * heightRatio);
                    control.Width = (int)(original.Width * widthRatio);
                    control.Height = (int)(original.Height * heightRatio);

                    // Scale font if needed
                    if (originalFontSizes.ContainsKey(control) && control.Font != null)
                    {
                        float originalSize = originalFontSizes[control];
                        float scaleFactor = Math.Min(widthRatio, heightRatio);
                        float newSize = originalSize * scaleFactor;

                        // Ensure minimum readable size
                        newSize = Math.Max(8.0f, newSize);

                        control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
                    }
                }

                if (control.Controls.Count > 0)
                {
                    ScaleAllControls(control, widthRatio, heightRatio);
                }
            }
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