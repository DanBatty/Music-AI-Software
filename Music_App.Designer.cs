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
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            menuStrip1.SuspendLayout();
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
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 424);
            panel3.Name = "panel3";
            panel3.Size = new Size(1264, 257);
            panel3.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 364);
            panel4.Name = "panel4";
            panel4.Size = new Size(1264, 60);
            panel4.TabIndex = 6;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 184);
            panel5.Name = "panel5";
            panel5.Size = new Size(570, 180);
            panel5.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(694, 184);
            panel6.Name = "panel6";
            panel6.Size = new Size(570, 180);
            panel6.TabIndex = 8;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(570, 184);
            panel7.Name = "panel7";
            panel7.Size = new Size(124, 180);
            panel7.TabIndex = 9;
            // 
            // Music_App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Music_App";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
    }
}
