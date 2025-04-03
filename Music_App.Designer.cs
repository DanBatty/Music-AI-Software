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
            listSongs = new ListBox();
            panel4 = new Panel();
            panelTrack1 = new Panel();
            trackPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            panel5 = new Panel();
            lblTrackEnd = new Label();
            labelTrackStart = new Label();
            progressBar1 = new ProgressBar();
            btnPlay = new Button();
            panelTrack2 = new Panel();
            panel6 = new Panel();
            lblLow = new Label();
            lblMid = new Label();
            lblHi = new Label();
            lblVolume = new Label();
            trackBar4 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar1 = new TrackBar();
            panel7 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            trackBar5 = new TrackBar();
            trackBar6 = new TrackBar();
            trackBar7 = new TrackBar();
            trackBar8 = new TrackBar();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panelTrack1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackPlayer).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar8).BeginInit();
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 80);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 80);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(listSongs);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 424);
            panel3.Name = "panel3";
            panel3.Size = new Size(1264, 257);
            panel3.TabIndex = 5;
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
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 390);
            panel4.Name = "panel4";
            panel4.Size = new Size(1264, 34);
            panel4.TabIndex = 6;
            // 
            // panelTrack1
            // 
            panelTrack1.Controls.Add(trackPlayer);
            panelTrack1.Controls.Add(panel5);
            panelTrack1.Dock = DockStyle.Left;
            panelTrack1.Location = new Point(0, 184);
            panelTrack1.Name = "panelTrack1";
            panelTrack1.Size = new Size(550, 206);
            panelTrack1.TabIndex = 7;
            // 
            // trackPlayer
            // 
            trackPlayer.Enabled = true;
            trackPlayer.Location = new Point(12, 6);
            trackPlayer.Name = "trackPlayer";
            trackPlayer.OcxState = (AxHost.State)resources.GetObject("trackPlayer.OcxState");
            trackPlayer.Size = new Size(528, 131);
            trackPlayer.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.Controls.Add(lblTrackEnd);
            panel5.Controls.Add(labelTrackStart);
            panel5.Controls.Add(progressBar1);
            panel5.Controls.Add(btnPlay);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 146);
            panel5.Name = "panel5";
            panel5.Size = new Size(550, 60);
            panel5.TabIndex = 4;
            // 
            // lblTrackEnd
            // 
            lblTrackEnd.AutoSize = true;
            lblTrackEnd.Location = new Point(512, 7);
            lblTrackEnd.Name = "lblTrackEnd";
            lblTrackEnd.Size = new Size(28, 15);
            lblTrackEnd.TabIndex = 5;
            lblTrackEnd.Text = "0.00";
            // 
            // labelTrackStart
            // 
            labelTrackStart.AutoSize = true;
            labelTrackStart.Location = new Point(12, 6);
            labelTrackStart.Name = "labelTrackStart";
            labelTrackStart.Size = new Size(28, 15);
            labelTrackStart.TabIndex = 4;
            labelTrackStart.Text = "0.00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(46, 11);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(453, 10);
            progressBar1.TabIndex = 3;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(234, 31);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // panelTrack2
            // 
            panelTrack2.Dock = DockStyle.Right;
            panelTrack2.Location = new Point(714, 184);
            panelTrack2.Name = "panelTrack2";
            panelTrack2.Size = new Size(550, 206);
            panelTrack2.TabIndex = 8;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblLow);
            panel6.Controls.Add(lblMid);
            panel6.Controls.Add(lblHi);
            panel6.Controls.Add(lblVolume);
            panel6.Controls.Add(trackBar4);
            panel6.Controls.Add(trackBar3);
            panel6.Controls.Add(trackBar2);
            panel6.Controls.Add(trackBar1);
            panel6.Dock = DockStyle.Left;
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
            // trackBar4
            // 
            trackBar4.Location = new Point(3, 55);
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(75, 45);
            trackBar4.TabIndex = 3;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(3, 106);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(75, 45);
            trackBar3.TabIndex = 2;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(3, 157);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(75, 45);
            trackBar2.TabIndex = 1;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(3, 5);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(75, 45);
            trackBar1.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(trackBar5);
            panel7.Controls.Add(trackBar6);
            panel7.Controls.Add(trackBar7);
            panel7.Controls.Add(trackBar8);
            panel7.Dock = DockStyle.Right;
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
            // trackBar5
            // 
            trackBar5.Location = new Point(3, 55);
            trackBar5.Name = "trackBar5";
            trackBar5.RightToLeft = RightToLeft.Yes;
            trackBar5.Size = new Size(75, 45);
            trackBar5.TabIndex = 7;
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(3, 106);
            trackBar6.Name = "trackBar6";
            trackBar6.RightToLeft = RightToLeft.Yes;
            trackBar6.Size = new Size(75, 45);
            trackBar6.TabIndex = 6;
            // 
            // trackBar7
            // 
            trackBar7.Location = new Point(3, 157);
            trackBar7.Name = "trackBar7";
            trackBar7.RightToLeft = RightToLeft.Yes;
            trackBar7.Size = new Size(75, 45);
            trackBar7.TabIndex = 5;
            // 
            // trackBar8
            // 
            trackBar8.Location = new Point(3, 5);
            trackBar8.Name = "trackBar8";
            trackBar8.RightToLeft = RightToLeft.Yes;
            trackBar8.Size = new Size(75, 45);
            trackBar8.TabIndex = 4;
            // 
            // Music_App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
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
            Name = "Music_App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music App";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panelTrack1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackPlayer).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar8).EndInit();
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
        private Panel panelTrack2;
        private ListBox listSongs;
        private Button btnPlay;
        private Panel panel5;
        private Panel panel6;
        private TrackBar trackBar1;
        private Panel panel7;
        private TrackBar trackBar4;
        private TrackBar trackBar3;
        private TrackBar trackBar2;
        private TrackBar trackBar5;
        private TrackBar trackBar6;
        private TrackBar trackBar7;
        private TrackBar trackBar8;
        private Label lblTrackEnd;
        private Label labelTrackStart;
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
    }
}
