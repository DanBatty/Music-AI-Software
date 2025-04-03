namespace Music_AI_Software
{
    public partial class Music_App : Form
    {
        public Music_App()
        {
            InitializeComponent();
        }
        string[] paths, files;

        private void trackMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for (int x = 0; x < paths.Length; x++)
                {
                    listSongs.Items.Add(paths[x]);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void listSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackPlayer.URL=paths[listSongs.SelectedIndex];
            trackPlayer.Ctlcontrols.play();
        }
    }
}
