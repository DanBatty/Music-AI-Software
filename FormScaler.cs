using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Music_AI_Software.UI
{
    /// <summary>
    /// Provides form scaling functionality to automatically resize and reposition controls when the parent form is resized, maintaining proportions
    /// </summary>
    public class FormScaler
    {
        /// <summary>
        /// Stores the original width of the form.
        /// </summary>
        private float originalWidth;

        /// <summary>
        /// Stores the original height of the form.
        /// </summary>
        private float originalHeight;

        /// <summary>
        /// Dictionary which maps controls to their original position and size.
        /// </summary>
        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();

        /// <summary>
        /// Dictionary which maps controls to their original font sizes.
        /// </summary>
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        /// <summary>
        /// Refers to the form which is being scaled.
        /// </summary>
        private readonly Form targetForm;

        /// <summary>
        /// Creates a new FormScaler for the given form.
        /// </summary>
        /// <param name="form">The form to be scaled. Cannot be null.</param>
        /// <exception cref="ArgumentNullException">Thrown if form is null.</exception>
        public FormScaler(Form form)
        {
            targetForm = form ?? throw new ArgumentNullException(nameof(form));
            targetForm.Load += TargetForm_Load;
            targetForm.Resize += TargetForm_Resize;
        }

        /// <summary>
        /// Initializes the form scaler by storing original dimensions.
        /// </summary>
        public void Initialize()
        {
            originalWidth = targetForm.ClientSize.Width;
            originalHeight = targetForm.ClientSize.Height;

            originalControls.Clear();
            originalFontSizes.Clear();

            StoreAllControlDimensions();
        }

        /// <summary>
        /// Handles the form Load event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void TargetForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// Handles the form Resize event.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void TargetForm_Resize(object sender, EventArgs e)
        {
            if (originalControls.Count == 0 || originalWidth == 0 || originalHeight == 0)
                return;

            float widthRatio = (float)targetForm.ClientSize.Width / originalWidth;
            float heightRatio = (float)targetForm.ClientSize.Height / originalHeight;

            ScaleAllControls(targetForm, widthRatio, heightRatio);
        }

        /// <summary>
        /// Stores the original dimensions of all controls on the form.
        /// </summary>
        private void StoreAllControlDimensions()
        {
            StoreControlDimensions(targetForm);
        }

        /// <summary>
        /// Recursively stores the original dimensions of all controls within a container.
        /// </summary>
        /// <param name="container">The container which is being processed.</param>
        private void StoreControlDimensions(Control container)
        {
            foreach (Control control in container.Controls)
            {
                // Store dimensions for all controls
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

        /// <summary>
        /// Recursively scales all controls within a container based on the given ratios.
        /// </summary>
        /// <param name="container">The container which is being processed.</param>
        /// <param name="widthRatio">The width scaling ratio.</param>
        /// <param name="heightRatio">The height scaling ratio.</param>
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

        /// <summary>
        /// Updates the scaling for all controls after the form has been modified.
        /// </summary>
        public void UpdateControlList()
        {
            originalControls.Clear();
            originalFontSizes.Clear();
            StoreAllControlDimensions();
        }
    }
}