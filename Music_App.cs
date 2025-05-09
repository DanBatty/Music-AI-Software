using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Music_AI_Software.Interfaces;
using Music_AI_Software.Players;
using Music_AI_Software.UI;

namespace Music_AI_Software
{
    /// <summary>
    /// Main form for the Music_AI_Software application, currently handles music playback and UI interactions.
    /// </summary>
    public partial class Music_App : Form
    {
        private IAudioPlayer audioPlayer1;
        private IAudioPlayer audioPlayer2;

        private FormScaler formScaler;

        private string[] paths;
        private string[] files;

        private MLRecommendationModel recommendationModel;

        /// <summary>
        /// Initializes a new instance of the Music_App form.
        /// </summary>
        public Music_App()
        {
            InitializeComponent();

            formScaler = new FormScaler(this);

            audioPlayer1 = new NAudioPlayer();
            audioPlayer2 = new NAudioPlayer();

            audioPlayer1.PlaybackProgress += AudioPlayer1_PlaybackProgress;
            audioPlayer2.PlaybackProgress += AudioPlayer2_PlaybackProgress;

            sliderVolume1.ValueChanged += SliderVolume1_ValueChanged;
            sliderVolume2.ValueChanged += SliderVolume2_ValueChanged;

            SetupDragAndDrop();

            btnPlay1.Click += btnPlay1_Click;
            btnPlay2.Click += btnPlay2_Click;
            btnPause1.Click += btnPause1_Click;
            btnPause2.Click += btnPause2_Click;

            recommendationModel = new MLRecommendationModel();

            InitializeRecommendationsUI();
        }

        /// <summary>
        /// Handles volume slider 1 changes.
        /// </summary>
        private void SliderVolume1_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer1.SetVolume(sliderVolume1.Value);
        }

        /// <summary>
        /// Handles volume slider 2 changes.
        /// </summary>
        private void SliderVolume2_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer2.SetVolume(sliderVolume2.Value);
        }

        /// <summary>
        /// Playback progress handler for player 1
        /// </summary>
        private void AudioPlayer1_PlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdatePlaybackUI1(e)));
            }
            else
            {
                UpdatePlaybackUI1(e);
            }
        }

        /// <summary>
        /// Playback progress handler for player 2
        /// </summary>
        private void AudioPlayer2_PlaybackProgress(object sender, PlaybackProgressEventArgs e)
        {
            // Handle cross-thread UI updates
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdatePlaybackUI2(e)));
            }
            else
            {
                UpdatePlaybackUI2(e);
            }
        }

        /// <summary>
        /// Updates the player 1 UI with current playback information.
        /// </summary>
        /// <param name="e">Event args containing playback position/duration</param>
        private void UpdatePlaybackUI1(PlaybackProgressEventArgs e)
        {
            // Format times as mm:ss
            TimeSpan currentTime = TimeSpan.FromSeconds(e.CurrentPosition);
            TimeSpan totalTime = TimeSpan.FromSeconds(e.Duration);

            labelTrackStart1.Text = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";
            lblTrackEnd1.Text = $"{totalTime.Minutes:D2}:{totalTime.Seconds:D2}";

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
        /// Updates the player 2 UI with current playback information.
        /// </summary>
        /// <param name="e">Event args containing playback position/duration</param>
        private void UpdatePlaybackUI2(PlaybackProgressEventArgs e)
        {
            // Format times as mm:ss
            TimeSpan currentTime = TimeSpan.FromSeconds(e.CurrentPosition);
            TimeSpan totalTime = TimeSpan.FromSeconds(e.Duration);

            labelTrackStart2.Text = $"{currentTime.Minutes:D2}:{currentTime.Seconds:D2}";
            lblTrackEnd2.Text = $"{totalTime.Minutes:D2}:{totalTime.Seconds:D2}";

            // Update progress bar
            if (e.Duration > 0)
            {
                progressBar2.Value = (int)((e.CurrentPosition / e.Duration) * 100);
            }
            else
            {
                progressBar2.Value = 0;
            }
        }

        /// <summary>
        /// Handles UI events for the recommendation panel and refersh button.
        /// </summary>
        private void InitializeRecommendationsUI()
        {
            refreshBtn.Click += RefreshBtn_Click;

            listRecommendations.DoubleClick += ListRecommendations_DoubleClick;
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

            audioPlayer1.SetVolume(sliderVolume1.Value);
            audioPlayer2.SetVolume(sliderVolume2.Value);
        }

        /// <summary>
        /// Handles the track menu item. Upon click, opens a file dialog where the user can select audio files.
        /// </summary>
        private async void trackMenuItem_Click(object sender, EventArgs e)
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

                    await AnalyseLibraryAsync();
                }
            }
        }

        /// <summary>
        /// Anlayses the loaded music to create the recommendation model.
        /// </summary>
        /// <returns></returns>
        private async Task AnalyseLibraryAsync()
        {
            try
            {
                // Show wait cursor
                this.Cursor = Cursors.WaitCursor;

                // Analyze all tracks
                await recommendationModel.AnalyseLibraryAsync(paths);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing tracks: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the refresh button click event. Calls the RefreshRecomendationsAsync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            await RefreshRecommendationsAsync();
        }

        /// <summary>
        /// Updates the list of recommendations with the songs from the machine learning model.
        /// </summary>
        /// <returns></returns>
        private async Task RefreshRecommendationsAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                listRecommendations.Items.Clear();

                string currentTrack = null;
                if (audioPlayer1.IsPlaying && listSongs.SelectedIndex >= 0)
                {
                    currentTrack = paths[listSongs.SelectedIndex];
                }
                else if (audioPlayer2.IsPlaying && listSongs.SelectedIndex >= 0)
                {
                    currentTrack = paths[listSongs.SelectedIndex];
                }
                else if (listSongs.SelectedIndex >= 0)
                {
                    currentTrack = paths[listSongs.SelectedIndex];
                }

                if (currentTrack != null)
                {
                    var recommendations = await recommendationModel.GetRecommendationsAsync(currentTrack, 10);

                    foreach (var recommendation in recommendations)
                    {
                        string fileName = Path.GetFileName(recommendation);
                        listRecommendations.Items.Add(fileName);
                    }

                    if (recommendations.Count == 0)
                    {
                        listRecommendations.Items.Add("No recommendations available");
                    }
                }
                else
                {
                    listRecommendations.Items.Add("Select a track to get recommendations");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting recommendations: {ex.Message}", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the double click event for the list of recommendations. If empty, song is loaded onto player 1,
        /// if not it is loaded on player 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListRecommendations_DoubleClick(object sender, EventArgs e)
        {
            if (listRecommendations.SelectedIndex >= 0)
            {
                string selectedItem = listRecommendations.SelectedItem.ToString();

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] == selectedItem)
                    {
                        listSongs.SelectedIndex = i;

                        if (!audioPlayer1.IsPlaying)
                        {
                            audioPlayer1.Play(paths[i]);
                        }
                        else if (!audioPlayer2.IsPlaying)
                        {
                            audioPlayer2.Play(paths[i]);
                        }
                        else
                        {
                            audioPlayer1.Play(paths[i]);
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Play button handler for player 1.
        /// </summary>
        private async void btnPlay1_Click(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex >= 0 && paths != null && listSongs.SelectedIndex < paths.Length)
            {
                audioPlayer1.Play(paths[listSongs.SelectedIndex]);
                await RefreshRecommendationsAsync();
            }
        }

        /// <summary>
        /// Play button handler for player 2.
        /// </summary>
        private async void btnPlay2_Click(object sender, EventArgs e)
        {
            if (listSongs.SelectedIndex >= 0 && paths != null && listSongs.SelectedIndex < paths.Length)
            {
                audioPlayer2.Play(paths[listSongs.SelectedIndex]);
                await RefreshRecommendationsAsync();
            }
        }

        /// <summary>
        /// Pause button handler for player 1.
        /// </summary>
        private void btnPause1_Click(object sender, EventArgs e)
        {
            audioPlayer1.Pause();
        }

        /// <summary>
        /// Pause button handler for player 2
        /// </summary>
        private void btnPause2_Click(object sender, EventArgs e)
        {
            audioPlayer2.Pause();
        }

        /// <summary>
        /// Sets up drag and drop functionality for the panels.
        /// </summary>
        private void SetupDragAndDrop()
        {
            listSongs.AllowDrop = true;
            listSongs.MouseDown += ListSongs_MouseDown;

            panelTrack1.AllowDrop = true;
            panelTrack1.DragEnter += PanelTrack_DragEnter;
            panelTrack1.DragDrop += PanelTrack1_DragDrop;

            panelTrack2.AllowDrop = true;
            panelTrack2.DragEnter += PanelTrack_DragEnter;
            panelTrack2.DragDrop += PanelTrack2_DragDrop;
        }

        /// <summary>
        /// Allows for drag and drop functionality on the song list.
        /// </summary>
        private void ListSongs_MouseDown(object sender, MouseEventArgs e)
        {
            if (listSongs.SelectedIndex != -1)
            {
                listSongs.DoDragDrop(listSongs.SelectedIndex.ToString(), DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Handles the drag enter event for the player panels.
        /// </summary>
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

        /// <summary>
        /// Handles the drag drop event for player panel 1.
        /// </summary>
        private void PanelTrack1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string indexStr = (string)e.Data.GetData(DataFormats.StringFormat);

                if (int.TryParse(indexStr, out int index) && index >= 0 && index < paths.Length)
                {
                    audioPlayer1.Play(paths[index]);
                }
            }
        }

        /// <summary>
        /// Handles the drag drop event for player panel 2.
        /// </summary>
        private void PanelTrack2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string indexStr = (string)e.Data.GetData(DataFormats.StringFormat);

                if (int.TryParse(indexStr, out int index) && index >= 0 && index < paths.Length)
                {
                    audioPlayer2.Play(paths[index]);
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
        /// Handles the form closing event and ensures proper cleanup.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (audioPlayer1 is IDisposable disposable1)
            {
                disposable1.Dispose();
            }
            else
            {
                audioPlayer1?.Stop();
            }

            if (audioPlayer2 is IDisposable disposable2)
            {
                disposable2.Dispose();
            }
            else
            {
                audioPlayer2?.Stop();
            }
        }
    }
}