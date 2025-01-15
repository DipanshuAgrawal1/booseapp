using System;
using System.Drawing; // Add reference for Bitmap
using System.Windows.Forms; // Add reference for OpenFileDialog, MessageBox, etc.

namespace main
{
    /// <summary>
    /// Provides functionality to load an image (canvas) from the file system.
    /// </summary>
    public class CanvasLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasLoader"/> class.
        /// </summary>
        public CanvasLoader() { }

        /// <summary>
        /// Opens a file dialog to allow the user to select and load an image as a Bitmap (canvas).
        /// </summary>
        /// <returns>A Bitmap containing the loaded image if successful, otherwise null.</returns>
        public Bitmap LoadCanvas()
        {
            // Create a new file dialog to select the image file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter for file types
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|All Files (*.*)|*.*";

            // Show the dialog and check if a file was selected
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path of the selected image
                string filePath = openFileDialog.FileName;
                try
                {
                    // Try to load the selected image as a Bitmap
                    return new Bitmap(filePath);
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs
                    MessageBox.Show("Error loading canvas: " + ex.Message, "Load Canvas Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Return null if the operation was canceled or if an error occurred
            return null;
        }
    }
}
