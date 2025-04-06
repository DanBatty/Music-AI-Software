namespace Music_AI_Software
{
    public partial class Music_App : Form
    {
        private float originalWidth;
        private float originalHeight;
        private Dictionary<Control, Rectangle> originalControls;
        private Dictionary<Control, float> originalFontSizes;

        public Music_App()
        {
            InitializeComponent();

            this.Load += new EventHandler(Music_App_Load);
            this.Resize += new EventHandler(Music_App_Resize);
        }

        string[] paths, files;

        private void Music_App_Load(object sender, EventArgs e)
        {
            originalWidth = this.Width;
            originalHeight = this.Height;

            originalControls = new Dictionary<Control, Rectangle>();
            originalFontSizes = new Dictionary<Control, float>();
            StoreControlProperties(this);
        }

        private void StoreControlProperties(Control container)
        {
            foreach (Control control in container.Controls)
            {
                originalControls.Add(control, new Rectangle(
                    control.Left, control.Top, control.Width, control.Height));

                if (control.Font != null)
                {
                    originalFontSizes.Add(control, control.Font.Size);
                }

                if (control.Controls.Count > 0)
                {
                    StoreControlProperties(control);
                }
            }
        }

        private void Music_App_Resize(object sender, EventArgs e)
        {
            if (originalControls == null || originalWidth == 0 || originalHeight == 0)
                return;

            float widthRatio = (float)this.Width / originalWidth;
            float heightRatio = (float)this.Height / originalHeight;

            ResizeControls(this, widthRatio, heightRatio);
        }

        private void ResizeControls(Control container, float widthRatio, float heightRatio)
        {
            foreach (Control control in container.Controls)
            {
                if (originalControls.ContainsKey(control))
                {
                    Rectangle original = originalControls[control];

                    control.Left = (int)(original.Left * widthRatio);
                    control.Top = (int)(original.Top * heightRatio);
                    control.Width = (int)(original.Width * widthRatio);
                    control.Height = (int)(original.Height * heightRatio);

                    if (originalFontSizes.ContainsKey(control))
                    {
                        float originalSize = originalFontSizes[control];
                        float scaleFactor = Math.Min(widthRatio, heightRatio);
                        float newSize = originalSize * scaleFactor;

                        newSize = Math.Max(8.0f, newSize);

                        control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
                    }
                }

                if (control.Controls.Count > 0)
                {
                    ResizeControls(control, widthRatio, heightRatio);
                }
            }
        }

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

        private void listSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackPlayer.URL = paths[listSongs.SelectedIndex];
            trackPlayer.Ctlcontrols.play();
        }
    }
}