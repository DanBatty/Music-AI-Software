using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Music_AI_Software.UI
{
    public class FormScaler
    {
        private float originalWidth;
        private float originalHeight;
        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        private readonly Form targetForm;

        public FormScaler(Form form)
        {
            targetForm = form;

            targetForm.Load += TargetForm_Load;
            targetForm.Resize += TargetForm_Resize;
        }

        public void Initialize()
        {
            originalWidth = targetForm.ClientSize.Width;
            originalHeight = targetForm.ClientSize.Height;

            StoreAllControlDimensions();
        }

        private void TargetForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void TargetForm_Resize(object sender, EventArgs e)
        {
            if (originalControls.Count == 0 || originalWidth == 0 || originalHeight == 0)
                return;

            float widthRatio = (float)targetForm.ClientSize.Width / originalWidth;
            float heightRatio = (float)targetForm.ClientSize.Height / originalHeight;

            ScaleAllControls(targetForm, widthRatio, heightRatio);
        }

        private void StoreAllControlDimensions()
        {
            StoreControlDimensions(targetForm);
        }

        private void StoreControlDimensions(Control container)
        {
            foreach (Control control in container.Controls)
            {
                originalControls[control] = new Rectangle(
                    control.Left, control.Top, control.Width, control.Height);

                if (control.Font != null)
                {
                    originalFontSizes[control] = control.Font.Size;
                }

                if (control.Controls.Count > 0)
                {
                    StoreControlDimensions(control);
                }
            }
        }

        private void ScaleAllControls(Control container, float widthRatio, float heightRatio)
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

                    if (originalFontSizes.ContainsKey(control) && control.Font != null)
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
                    ScaleAllControls(control, widthRatio, heightRatio);
                }
            }
        }

        public void UpdateControlList()
        {
            originalControls.Clear();
            originalFontSizes.Clear();
            StoreAllControlDimensions();
        }
    }
}