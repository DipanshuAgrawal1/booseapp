using System;
using System.Drawing; // For Bitmap and Image
using System.Drawing.Imaging; // For ImageFormat
using System.Windows.Forms; // For SaveFileDialog, MessageBox

namespace main
{
    /// <summary>
    /// Provides functionality to save the canvas (bitmap) to a file.
    /// </summary>
    public class CanvasSaver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasSaver"/> class.
        /// </summary>
        public CanvasSaver()
        {
        }

        /// <summary>
        /// Opens a save file dialog to save the canvas (bitmap) to a file.
        /// </summary>
        /// <param name="canvasBitmap">The bitmap representing the canvas to be saved.</param>
        public void SaveCanvas(Bitmap canvasBitmap)
        {
            // Create a new SaveFileDialog to allow the user to choose where to save the image
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the filter for the file types to save (PNG, JPG, BMP, and All Files)
            saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|All Files (*.*)|*.*";

            // Show the dialog to the user and check if a file was selected
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path from the dialog
                string filePath = saveFileDialog.FileName;

                // Default to saving as PNG format
                ImageFormat format = ImageFormat.Png;

                // Check file extension to determine the correct image format
                if (filePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Jpeg;
                }
                else if (filePath.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Bmp;
                }

                try
                {
                    // Attempt to save the bitmap to the selected file path with the chosen format
                    canvasBitmap.Save(filePath, format);

                    // Show a success message if the file was saved successfully
                    MessageBox.Show("Canvas saved successfully!", "Save Canvas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Show an error message if an exception occurs while saving the file
                    MessageBox.Show("Error saving canvas: " + ex.Message, "Save Canvas Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
