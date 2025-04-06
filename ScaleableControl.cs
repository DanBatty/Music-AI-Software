using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_AI_Software.UI
{
    using Music_AI_Software.Interfaces;

    // Base scalable control
    public class ScalableControl : Control, IScalableControl
    {
        protected Rectangle originalBounds;
        protected float originalFontSize;

        public void StoreOriginalDimensions()
        {
            originalBounds = new Rectangle(Left, Top, Width, Height);
            if (Font != null)
            {
                originalFontSize = Font.Size;
            }
        }

        public void Scale(float widthRatio, float heightRatio)
        {
            this.Left = (int)(originalBounds.Left * widthRatio);
            this.Top = (int)(originalBounds.Top * heightRatio);
            this.Width = (int)(originalBounds.Width * widthRatio);
            this.Height = (int)(originalBounds.Height * heightRatio);

            if (Font != null)
            {
                float scaleFactor = Math.Min(widthRatio, heightRatio);
                float newSize = originalFontSize * scaleFactor;
                newSize = Math.Max(8.0f, newSize);
                this.Font = new Font(Font.FontFamily, newSize, Font.Style);
            }
        }
    }

    public class ScalableContainer : Panel, IScalableControl
    {
        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        public void StoreOriginalDimensions()
        {
            foreach (Control control in Controls)
            {
                originalControls[control] = new Rectangle(
                    control.Left, control.Top, control.Width, control.Height);

                if (control.Font != null)
                {
                    originalFontSizes[control] = control.Font.Size;
                }

                if (control is ScalableContainer container)
                {
                    container.StoreOriginalDimensions();
                }
            }
        }

        public void Scale(float widthRatio, float heightRatio)
        {
            foreach (Control control in Controls)
            {
                if (originalControls.ContainsKey(control))
                {
                    Rectangle original = originalControls[control];

                    control.Left = (int)(original.Left * widthRatio);
                    control.Top = (int)(original.Top * heightRatio);
                    control.Width = (int)(original.Width * widthRatio);
                    control.Height = (int)(original.Height * heightRatio);

                    if (originalFontSizes.ContainsKey(control) && control.Font != null)
                    {
                        float originalSize = originalFontSizes[control];
                        float scaleFactor = Math.Min(widthRatio, heightRatio);
                        float newSize = originalSize * scaleFactor;

                        // Set minimum font size
                        newSize = Math.Max(8.0f, newSize);

                        control.Font = new Font(control.Font.FontFamily, newSize, control.Font.Style);
                    }
                }

                if (control is ScalableContainer container)
                {
                    container.Scale(widthRatio, heightRatio);
                }
            }
        }
    }

    public class VolumeControl : ScalableContainer
    {
        public TrackBar VolumeSlider { get; private set; }

        public event EventHandler<VolumeChangedEventArgs> VolumeChanged;

        public class VolumeChangedEventArgs : EventArgs
        {
            public int Volume { get; set; }
        }

        public VolumeControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            VolumeSlider = new TrackBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                TickFrequency = 10,
                Orientation = Orientation.Horizontal,
                Dock = DockStyle.Fill
            };

            Label volumeLabel = new Label
            {
                Text = "Volume",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(VolumeSlider);
            Controls.Add(volumeLabel);

            VolumeSlider.ValueChanged += VolumeSlider_ValueChanged;
        }

        private void VolumeSlider_ValueChanged(object sender, EventArgs e)
        {
            VolumeChanged?.Invoke(this, new VolumeChangedEventArgs
            {
                Volume = VolumeSlider.Value
            });
        }
    }
}