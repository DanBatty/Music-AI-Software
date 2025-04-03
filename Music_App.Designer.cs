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
            panel5 = new Panel();
            btnPlay = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            panelTrack2 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            trackBar6 = new TrackBar();
            trackBar7 = new TrackBar();
            trackBar8 = new TrackBar();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panelTrack1.SuspendLayout();
            panel5.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
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
            panelTrack1.Controls.Add(panel5);
            panelTrack1.Controls.Add(toolStrip1);
            panelTrack1.Dock = DockStyle.Left;
            panelTrack1.Location = new Point(0, 184);
            panelTrack1.Name = "panelTrack1";
            panelTrack1.Size = new Size(550, 206);
            panelTrack1.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnPlay);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 146);
            panel5.Name = "panel5";
            panel5.Size = new Size(550, 60);
            panel5.TabIndex = 4;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(234, 16);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(550, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(23, 22);
            toolStripButton3.Text = "toolStripButton3";
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
            // panel7
            // 
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
            // trackBar1
            // 
            trackBar1.Location = new Point(3, 5);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(75, 45);
            trackBar1.TabIndex = 0;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(3, 157);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(75, 45);
            trackBar2.TabIndex = 1;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(3, 106);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(75, 45);
            trackBar3.TabIndex = 2;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(3, 55);
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(75, 45);
            trackBar4.TabIndex = 3;
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
            panelTrack1.PerformLayout();
            panel5.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
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
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
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
    }
}
