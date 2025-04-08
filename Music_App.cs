using Music_AI_Software.Interfaces;
using Music_AI_Software.Players;
using Music_AI_Software.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Music_AI_Software
{
    /// <summary>
    /// Main form for the Music_AI_Software application, currently handles music playback and UI interactions.
    /// </summary>
    public partial class Music_App : Form
    {
        private IAudioPlayer audioPlayer;

        private FormScaler formScaler;

        private string[] paths;
        private string[] files;

        /// <summary>
        /// Initializes a new instance of the Music_App form.
        /// </summary>
        public Music_App()
        {
            InitializeComponent();

            formScaler = new FormScaler(this);

            audioPlayer = new WmpAudioPlayer(trackPlayer);

            audioPlayer.PlaybackProgress += AudioPlayer_PlaybackProgress;

            sliderVolume1.ValueChanged += SliderVolume1_ValueChanged;
            sliderVolume2.ValueChanged += SliderVolume2_ValueChanged;

            SetupDragAndDrop();
        }

        /// <summary>
        /// Handles volume slider 1 changes.
        /// </summary>
        private void SliderVolume1_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer.SetVolume(sliderVolume1.Value);
        }

        /// <summary>
        /// Handles volume slider 2 changes.
        /// </summary>
        private void SliderVolume2_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Playback progress handler which updates from the audio player. Updates the UI with current playback position/duration.
        /// </summary>
        private void AudioPlayer_PlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
            // Handle cross-thread UI updates
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdatePlaybackUI(e)));
            }
            else
            {
                UpdatePlaybackUI(e);
            }
        }

        /// <summary>
        /// Updates the UI with current playback information.
        /// </summary>
        /// <param name="e">Event args containing playback position/duration</param>
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

        /// <summary>
        /// Handles the form load event. Initializes controls and settings.
        /// </summary>
        private void Music_App_Load(object sender, EventArgs e)
        {
            sliderVolume1.Minimum = 0;
            sliderVolume1.Maximum = 100;
            sliderVolume2.Minimum = 0;
            sliderVolume2.Maximum = 100;
            sliderVolume1.Value = 50;
            sliderVolume2.Value = 50;

            audioPlayer.SetVolume(sliderVolume1.Value);
        }

        /// <summary>
        /// Handles the track menu item. Upon click, opens a file dialog where the user can select audio files.
        /// </summary>
        private void trackMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
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
        }

        /// <summary>
        /// Play button handler. Upon click event, the currently loaded song will play.
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex >= 0 && paths != null && listSongs.SelectedIndex < paths.Length)
            {
                audioPlayer.Play(paths[listSongs.SelectedIndex]);
            }
        }

        private void SetupDragAndDrop()
        {
            listSongs.AllowDrop = true;
            listSongs.MouseDown += ListSongs_MouseDown;

            panelTrack1.AllowDrop = true;
            panelTrack1.DragEnter += PanelTrack_DragEnter;
            panelTrack1.DragDrop += PanelTrack_DragDrop;
        }

        private void ListSongs_MouseDown(object sender, MouseEventArgs e)
        {
            if (listSongs.SelectedIndex != -1)
            {
                listSongs.DoDragDrop(listSongs.SelectedIndex.ToString(), DragDropEffects.Copy);
            }
        }

        private void PanelTrack_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is in an acceptable format
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PanelTrack_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string indexStr = (string)e.Data.GetData(DataFormats.StringFormat);

                if (int.TryParse(indexStr, out int index) && index >= 0 && index < paths.Length)
                {
                    audioPlayer.Play(paths[index]);
                }
            }
        }

        private void UpdateCurrentTrackDisplay(string fileName)
        { 
            //TODO
        }

        /// <summary>
        /// Handles the song selection change in the playlist.
        /// </summary>
        private void listSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listSongs.SelectedIndex >= 0 && paths != null && listSongs.SelectedIndex < paths.Length)
            //{
            //    audioPlayer.Play(paths[listSongs.SelectedIndex]);
            //}
        }

        /// <summary>
        /// Handles the form closing event ans ensures proper cleanup.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            audioPlayer?.Stop();
        }
    }
}