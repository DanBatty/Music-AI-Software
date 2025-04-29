namespace Music_AI_Software
{
    partial class Music_App
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Music_App));
            menuStrip1 = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            importMenuItem = new ToolStripMenuItem();
            trackMenuItem = new ToolStripMenuItem();
            folderMenuItem = new ToolStripMenuItem();
            viewItem = new ToolStripMenuItem();
            fullscreenMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            refreshBtn = new Button();
            listRecommendations = new ListBox();
            listSongs = new ListBox();
            panel4 = new Panel();
            panelTrack1 = new Panel();
            trackPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            panelTrackControls1 = new Panel();
            btnPause1 = new Button();
            lblTrackEnd1 = new Label();
            labelTrackStart1 = new Label();
            progressBar1 = new ProgressBar();
            btnPlay1 = new Button();
            panel6 = new Panel();
            lblLow = new Label();
            lblMid = new Label();
            lblHi = new Label();
            lblVolume = new Label();
            sliderHi1 = new TrackBar();
            sliderMid1 = new TrackBar();
            sliderLow1 = new TrackBar();
            sliderVolume1 = new TrackBar();
            panel7 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            sliderHi2 = new TrackBar();
            sliderMid2 = new TrackBar();
            sliderLow2 = new TrackBar();
            sliderVolume2 = new TrackBar();
            panelTrack2 = new Panel();
            trackPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            panelTrackControls2 = new Panel();
            btnPause2 = new Button();
            lblTrackEnd2 = new Label();
            labelTrackStart2 = new Label();
            progressBar2 = new ProgressBar();
            btnPlay2 = new Button();
            lblAnalysis = new Label();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panelTrack1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackPlayer).BeginInit();
            panelTrackControls1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sliderHi1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderMid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderLow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderVolume1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sliderHi2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderMid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderLow2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderVolume2).BeginInit();
            panelTrack2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackPlayer2).BeginInit();
            panelTrackControls2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenuItem, viewItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(37, 20);
            fileMenuItem.Text = "File";
            // 
            // importMenuItem
            // 
            importMenuItem.DropDownItems.AddRange(new ToolStripItem[] { trackMenuItem, folderMenuItem });
            importMenuItem.Name = "importMenuItem";
            importMenuItem.Size = new Size(110, 22);
            importMenuItem.Text = "Import";
            // 
            // trackMenuItem
            // 
            trackMenuItem.Name = "trackMenuItem";
            trackMenuItem.Size = new Size(107, 22);
            trackMenuItem.Text = "Track";
            trackMenuItem.Click += trackMenuItem_Click;
            // 
            // folderMenuItem
            // 
            folderMenuItem.Name = "folderMenuItem";
            folderMenuItem.Size = new Size(107, 22);
            folderMenuItem.Text = "Folder";
            // 
            // viewItem
            // 
            viewItem.DropDownItems.AddRange(new ToolStripItem[] { fullscreenMenuItem });
            viewItem.Name = "viewItem";
            viewItem.Size = new Size(44, 20);
            viewItem.Text = "View";
            // 
            // fullscreenMenuItem
            // 
            fullscreenMenuItem.Name = "fullscreenMenuItem";
            fullscreenMenuItem.Size = new Size(127, 22);
            fullscreenMenuItem.Text = "Fullscreen";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 80);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoSize = true;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 80);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoSize = true;
            panel3.Controls.Add(lblAnalysis);
            panel3.Controls.Add(refreshBtn);
            panel3.Controls.Add(listRecommendations);
            panel3.Controls.Add(listSongs);
            panel3.Location = new Point(0, 424);
            panel3.Name = "panel3";
            panel3.Size = new Size(1264, 257);
            panel3.TabIndex = 5;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(802, 6);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(75, 23);
            refreshBtn.TabIndex = 2;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            // 
            // listRecommendations
            // 
            listRecommendations.Dock = DockStyle.Right;
            listRecommendations.FormattingEnabled = true;
            listRecommendations.ItemHeight = 15;
            listRecommendations.Location = new Point(883, 0);
            listRecommendations.Name = "listRecommendations";
            listRecommendations.Size = new Size(381, 257);
            listRecommendations.TabIndex = 1;
            // 
            // listSongs
            // 
            listSongs.Dock = DockStyle.Left;
            listSongs.FormattingEnabled = true;
            listSongs.ItemHeight = 15;
            listSongs.Location = new Point(0, 0);
            listSongs.Name = "listSongs";
            listSongs.Size = new Size(381, 257);
            listSongs.TabIndex = 0;
            listSongs.SelectedIndexChanged += listSongs_SelectedIndexChanged;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSize = true;
            panel4.Location = new Point(0, 390);
            panel4.Name = "panel4";
            panel4.Size = new Size(1264, 34);
            panel4.TabIndex = 6;
            // 
            // panelTrack1
            // 
            panelTrack1.AllowDrop = true;
            panelTrack1.AutoSize = true;
            panelTrack1.Controls.Add(trackPlayer);
            panelTrack1.Controls.Add(panelTrackControls1);
            panelTrack1.Location = new Point(0, 184);
            panelTrack1.Name = "panelTrack1";
            panelTrack1.Size = new Size(550, 206);
            panelTrack1.TabIndex = 7;
            // 
            // trackPlayer
            // 
            trackPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackPlayer.Enabled = true;
            trackPlayer.Location = new Point(12, 6);
            trackPlayer.Name = "trackPlayer";
            trackPlayer.OcxState = (AxHost.State)resources.GetObject("trackPlayer.OcxState");
            trackPlayer.Size = new Size(528, 131);
            trackPlayer.TabIndex = 5;
            // 
            // panelTrackControls1
            // 
            panelTrackControls1.AutoSize = true;
            panelTrackControls1.Controls.Add(btnPause1);
            panelTrackControls1.Controls.Add(lblTrackEnd1);
            panelTrackControls1.Controls.Add(labelTrackStart1);
            panelTrackControls1.Controls.Add(progressBar1);
            panelTrackControls1.Controls.Add(btnPlay1);
            panelTrackControls1.Dock = DockStyle.Bottom;
            panelTrackControls1.Location = new Point(0, 147);
            panelTrackControls1.Name = "panelTrackControls1";
            panelTrackControls1.Size = new Size(550, 59);
            panelTrackControls1.TabIndex = 4;
            // 
            // btnPause1
            // 
            btnPause1.AutoSize = true;
            btnPause1.Location = new Point(285, 31);
            btnPause1.Name = "btnPause1";
            btnPause1.Size = new Size(75, 25);
            btnPause1.TabIndex = 6;
            btnPause1.Text = "Pause";
            btnPause1.UseVisualStyleBackColor = true;
            btnPause1.Click += btnPause1_Click;
            // 
            // lblTrackEnd1
            // 
            lblTrackEnd1.AutoSize = true;
            lblTrackEnd1.Location = new Point(512, 7);
            lblTrackEnd1.Name = "lblTrackEnd1";
            lblTrackEnd1.Size = new Size(28, 15);
            lblTrackEnd1.TabIndex = 5;
            lblTrackEnd1.Text = "0.00";
            // 
            // labelTrackStart1
            // 
            labelTrackStart1.AutoSize = true;
            labelTrackStart1.Location = new Point(12, 6);
            labelTrackStart1.Name = "labelTrackStart1";
            labelTrackStart1.Size = new Size(28, 15);
            labelTrackStart1.TabIndex = 4;
            labelTrackStart1.Text = "0.00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(46, 11);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(453, 10);
            progressBar1.TabIndex = 3;
            // 
            // btnPlay1
            // 
            btnPlay1.AutoSize = true;
            btnPlay1.Location = new Point(204, 31);
            btnPlay1.Name = "btnPlay1";
            btnPlay1.Size = new Size(75, 25);
            btnPlay1.TabIndex = 2;
            btnPlay1.Text = "Play";
            btnPlay1.UseVisualStyleBackColor = true;
            btnPlay1.Click += btnPlay1_Click;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.AutoSize = true;
            panel6.Controls.Add(lblLow);
            panel6.Controls.Add(lblMid);
            panel6.Controls.Add(lblHi);
            panel6.Controls.Add(lblVolume);
            panel6.Controls.Add(sliderHi1);
            panel6.Controls.Add(sliderMid1);
            panel6.Controls.Add(sliderLow1);
            panel6.Controls.Add(sliderVolume1);
            panel6.Location = new Point(550, 184);
            panel6.Name = "panel6";
            panel6.Size = new Size(81, 206);
            panel6.TabIndex = 9;
            // 
            // lblLow
            // 
            lblLow.AutoSize = true;
            lblLow.Location = new Point(28, 187);
            lblLow.Name = "lblLow";
            lblLow.Size = new Size(29, 15);
            lblLow.TabIndex = 7;
            lblLow.Text = "Low";
            // 
            // lblMid
            // 
            lblMid.AutoSize = true;
            lblMid.Location = new Point(28, 136);
            lblMid.Name = "lblMid";
            lblMid.Size = new Size(28, 15);
            lblMid.TabIndex = 6;
            lblMid.Text = "Mid";
            // 
            // lblHi
            // 
            lblHi.AutoSize = true;
            lblHi.Location = new Point(31, 85);
            lblHi.Name = "lblHi";
            lblHi.Size = new Size(19, 15);
            lblHi.TabIndex = 5;
            lblHi.Text = "Hi";
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(18, 35);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(47, 15);
            lblVolume.TabIndex = 4;
            lblVolume.Text = "Volume";
            // 
            // sliderHi1
            // 
            sliderHi1.Location = new Point(3, 55);
            sliderHi1.Name = "sliderHi1";
            sliderHi1.Size = new Size(75, 45);
            sliderHi1.TabIndex = 3;
            // 
            // sliderMid1
            // 
            sliderMid1.Location = new Point(3, 106);
            sliderMid1.Name = "sliderMid1";
            sliderMid1.Size = new Size(75, 45);
            sliderMid1.TabIndex = 2;
            // 
            // sliderLow1
            // 
            sliderLow1.Location = new Point(3, 157);
            sliderLow1.Name = "sliderLow1";
            sliderLow1.Size = new Size(75, 45);
            sliderLow1.TabIndex = 1;
            // 
            // sliderVolume1
            // 
            sliderVolume1.Location = new Point(3, 5);
            sliderVolume1.Name = "sliderVolume1";
            sliderVolume1.Size = new Size(75, 45);
            sliderVolume1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(sliderHi2);
            panel7.Controls.Add(sliderMid2);
            panel7.Controls.Add(sliderLow2);
            panel7.Controls.Add(sliderVolume2);
            panel7.Location = new Point(633, 184);
            panel7.Name = "panel7";
            panel7.Size = new Size(81, 206);
            panel7.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 187);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 11;
            label2.Text = "Low";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 136);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 10;
            label3.Text = "Mid";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 85);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 9;
            label4.Text = "Hi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 35);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 8;
            label5.Text = "Volume";
            // 
            // sliderHi2
            // 
            sliderHi2.Location = new Point(3, 55);
            sliderHi2.Name = "sliderHi2";
            sliderHi2.RightToLeft = RightToLeft.No;
            sliderHi2.Size = new Size(75, 45);
            sliderHi2.TabIndex = 7;
            // 
            // sliderMid2
            // 
            sliderMid2.Location = new Point(3, 106);
            sliderMid2.Name = "sliderMid2";
            sliderMid2.RightToLeft = RightToLeft.No;
            sliderMid2.Size = new Size(75, 45);
            sliderMid2.TabIndex = 6;
            // 
            // sliderLow2
            // 
            sliderLow2.Location = new Point(3, 157);
            sliderLow2.Name = "sliderLow2";
            sliderLow2.RightToLeft = RightToLeft.No;
            sliderLow2.Size = new Size(75, 45);
            sliderLow2.TabIndex = 5;
            // 
            // sliderVolume2
            // 
            sliderVolume2.Location = new Point(3, 5);
            sliderVolume2.Name = "sliderVolume2";
            sliderVolume2.Size = new Size(75, 45);
            sliderVolume2.TabIndex = 4;
            // 
            // panelTrack2
            // 
            panelTrack2.AutoSize = true;
            panelTrack2.Controls.Add(trackPlayer2);
            panelTrack2.Controls.Add(panelTrackControls2);
            panelTrack2.Location = new Point(714, 184);
            panelTrack2.Name = "panelTrack2";
            panelTrack2.Size = new Size(550, 206);
            panelTrack2.TabIndex = 8;
            // 
            // trackPlayer2
            // 
            trackPlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackPlayer2.Enabled = true;
            trackPlayer2.Location = new Point(12, 3);
            trackPlayer2.Name = "trackPlayer2";
            trackPlayer2.OcxState = (AxHost.State)resources.GetObject("trackPlayer2.OcxState");
            trackPlayer2.Size = new Size(528, 131);
            trackPlayer2.TabIndex = 7;
            // 
            // panelTrackControls2
            // 
            panelTrackControls2.AutoSize = true;
            panelTrackControls2.Controls.Add(btnPause2);
            panelTrackControls2.Controls.Add(lblTrackEnd2);
            panelTrackControls2.Controls.Add(labelTrackStart2);
            panelTrackControls2.Controls.Add(progressBar2);
            panelTrackControls2.Controls.Add(btnPlay2);
            panelTrackControls2.Dock = DockStyle.Bottom;
            panelTrackControls2.Location = new Point(0, 147);
            panelTrackControls2.Name = "panelTrackControls2";
            panelTrackControls2.Size = new Size(550, 59);
            panelTrackControls2.TabIndex = 6;
            // 
            // btnPause2
            // 
            btnPause2.AutoSize = true;
            btnPause2.Location = new Point(263, 31);
            btnPause2.Name = "btnPause2";
            btnPause2.Size = new Size(75, 25);
            btnPause2.TabIndex = 7;
            btnPause2.Text = "Pause";
            btnPause2.UseVisualStyleBackColor = true;
            btnPause2.Click += btnPause2_Click;
            // 
            // lblTrackEnd2
            // 
            lblTrackEnd2.AutoSize = true;
            lblTrackEnd2.Location = new Point(512, 7);
            lblTrackEnd2.Name = "lblTrackEnd2";
            lblTrackEnd2.Size = new Size(28, 15);
            lblTrackEnd2.TabIndex = 5;
            lblTrackEnd2.Text = "0.00";
            // 
            // labelTrackStart2
            // 
            labelTrackStart2.AutoSize = true;
            labelTrackStart2.Location = new Point(12, 6);
            labelTrackStart2.Name = "labelTrackStart2";
            labelTrackStart2.Size = new Size(28, 15);
            labelTrackStart2.TabIndex = 4;
            labelTrackStart2.Text = "0.00";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(46, 11);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(453, 10);
            progressBar2.TabIndex = 3;
            // 
            // btnPlay2
            // 
            btnPlay2.AutoSize = true;
            btnPlay2.Location = new Point(182, 31);
            btnPlay2.Name = "btnPlay2";
            btnPlay2.Size = new Size(75, 25);
            btnPlay2.TabIndex = 2;
            btnPlay2.Text = "Play";
            btnPlay2.UseVisualStyleBackColor = true;
            btnPlay2.Click += btnPlay2_Click;
            // 
            // lblAnalysis
            // 
            lblAnalysis.AutoSize = true;
            lblAnalysis.Location = new Point(631, 115);
            lblAnalysis.Name = "lblAnalysis";
            lblAnalysis.Size = new Size(0, 15);
            lblAnalysis.TabIndex = 3;
            // 
            // Music_App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panelTrack2);
            Controls.Add(panelTrack1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1280, 720);
            Name = "Music_App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music App";
            Load += Music_App_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panelTrack1.ResumeLayout(false);
            panelTrack1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackPlayer).EndInit();
            panelTrackControls1.ResumeLayout(false);
            panelTrackControls1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sliderHi1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderMid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderLow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderVolume1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sliderHi2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderMid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderLow2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderVolume2).EndInit();
            panelTrack2.ResumeLayout(false);
            panelTrack2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackPlayer2).EndInit();
            panelTrackControls2.ResumeLayout(false);
            panelTrackControls2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem importMenuItem;
        private ToolStripMenuItem viewItem;
        private ToolStripMenuItem trackMenuItem;
        private ToolStripMenuItem folderMenuItem;
        private ToolStripMenuItem fullscreenMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panelTrack1;
        private ListBox listSongs;
        private Button btnPlay1;
        private Panel panelTrackControls1;
        private Panel panel6;
        private TrackBar sliderVolume1;
        private Panel panel7;
        private TrackBar sliderHi1;
        private TrackBar sliderMid1;
        private TrackBar sliderLow1;
        private TrackBar sliderHi2;
        private TrackBar sliderMid2;
        private TrackBar sliderLow2;
        private TrackBar sliderVolume2;
        private Label lblTrackEnd1;
        private Label labelTrackStart1;
        private ProgressBar progressBar1;
        private AxWMPLib.AxWindowsMediaPlayer trackPlayer;
        private Label lblHi;
        private Label lblVolume;
        private Label lblLow;
        private Label lblMid;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panelTrack2;
        private AxWMPLib.AxWindowsMediaPlayer trackPlayer2;
        private Panel panelTrackControls2;
        private Label lblTrackEnd2;
        private Label labelTrackStart2;
        private ProgressBar progressBar2;
        private Button btnPlay2;
        private Button btnPause1;
        private Button btnPause2;
        private ListBox listRecommendations;
        private Button refreshBtn;
        private Label lblAnalysis;
    }
}
