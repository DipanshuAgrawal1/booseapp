using System;
using System;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Reflection;
using BOOSE;
using System.Diagnostics;
using System.Drawing;

namespace main
{
    /// <summary>
    /// Main form of the application that interacts with the canvas and handles user input.
    /// </summary>
    public partial class Form1 : Form
    {
        private ConsoleInputHandler consoleInputHandler; 

        private ICanvas myCanvas;
        private AppCommandFactory Factory;
        public AppStoredProgram Program;
        public Parser Parser;
        private SoundPlayer player;
        private bool isSoundPlaying;
        private Bitmap drawingBitmap;
        private Graphics g;
        private Bitmap loadedBitmap;
        private bool isDrawing; 
        private bool isCircleMode;
        private bool isEraserMode; 
        private Point lastPoint;
        private Rectangle currentCircle; 
        private Point circleStartPoint; 


        /// <summary>
        /// Initializes the form and sets up the canvas and related components.
        /// The sound will play if isSoundPlaying is true.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(AboutBOOSE.about());

            StartConsoleInput();

            player = new SoundPlayer();
            isSoundPlaying = false;

            myCanvas = new AppCanvas();
            myCanvas.SetColour(255, 0, 0); // Set initial drawing color (red)

            Refresh();

            Factory = new AppCommandFactory();
            Program = new AppStoredProgram(myCanvas);
            Parser = new Parser(Factory, Program);

            // Attach the mouse event handlers to the OutputWindow
            OutputWindow.MouseDown += OutputWindow_MouseDown;
            OutputWindow.MouseMove += OutputWindow_MouseMove;
            OutputWindow.MouseUp += OutputWindow_MouseUp;

            // Play sound if it's enabled
            if (isSoundPlaying)
            {
                StartSound();
                UpdateSoundButtonImage("sound.png");
            }
            else
            {
                UpdateSoundButtonImage("mute.png");
            }
            // Attach the KeyDown event handler to handle the Enter key
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;  // Make sure the form receives key events even when a control has focus
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Stop the console input handler thread when the form closes
            if (consoleInputHandler != null)
            {
                consoleInputHandler.Stop();
            }
        }

        public void StartConsoleInput()
        {
            Task.Run(() =>  // Start a new task (background thread)
            {
                while (true)
                {
                    Console.WriteLine("Enter a command:");

                    // Read input from the console
                    string command = Console.ReadLine();

                    if (!string.IsNullOrEmpty(command))
                    {
                        // Process the command and run the program
                        ProcessConsoleCommand(command);
                    }
                }
            });
        }

        private void ProcessConsoleCommand(string command)
        {
            try
            {
                // You can directly pass the command to the parser
                Parser.ParseProgram(command);
                Program.Run();
                Refresh();
            }
            catch (Exception ex)
            {
                // Handle errors
                UpdateErrorWindow($"Error processing command: {ex.Message}\n");
            }
        }

        // Existing method to update error window if necessary
        private void UpdateErrorWindow(string errorMessage)
        {
            // Check if we are already on the UI thread
            if (InvokeRequired)
            {
                // If we're not on the UI thread, invoke this method on the UI thread
                Invoke(new Action<string>(UpdateErrorWindow), errorMessage);
            }
            else
            {
                // We're on the UI thread, so we can update the UI directly
                ErrorWindow.AppendText(errorMessage);
            }
        }


        /// <summary>
        /// Handles the Enter key press to trigger program run.
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Trigger the same functionality as clicking the Play button
                PlayBtn_Click(sender, e);
            }

        }

        /// <summary>
        /// Handles the MouseDown event to start drawing or to start a circle or eraser.
        /// </summary>
        private void OutputWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isCircleMode) // If we're in circle mode
                {
                    // Start drawing the circle (store initial point)
                    circleStartPoint = e.Location;
                    currentCircle = new Rectangle(circleStartPoint.X, circleStartPoint.Y, 0, 0); // Initialize an empty circle
                }
                else if (isEraserMode) // If we're in eraser mode
                {
                    // Erasing starts when the mouse is clicked
                }
                else
                {
                    // In pen mode: start drawing
                    isDrawing = true;
                    lastPoint = e.Location; // Store the current mouse position
                }
            }
        }

        private void OutputWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCircleMode && currentCircle != null)
            {
                // Adjust the size of the circle based on mouse drag only if the mouse is pressed
                if (e.Button == MouseButtons.Left)
                {
                    int width = e.X - circleStartPoint.X;
                    int height = e.Y - circleStartPoint.Y;

                    // Update the current circle's size and position
                    currentCircle = new Rectangle(circleStartPoint.X, circleStartPoint.Y, width, height);
                }
            }
            else if (isDrawing)
            {
                // In pen mode: draw a line from the last point to the current mouse position
                using (Graphics g = Graphics.FromImage((Bitmap)myCanvas.getBitmap()))
                {
                    g.DrawLine(new Pen((Color)myCanvas.PenColour), lastPoint, e.Location);
                    lastPoint = e.Location; // Update last point
                }
            }
            else if (isEraserMode && e.Button == MouseButtons.Left) // Erase only when mouse is pressed
            {
                // In eraser mode: erase the part of the canvas under the mouse
                using (Graphics g = Graphics.FromImage((Bitmap)myCanvas.getBitmap()))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(239, 216, 183)), e.X - 10, e.Y - 10, 20, 20); // Erase in a 20x20 area with new color
                }
            }

            OutputWindow.Invalidate(); // Redraw the canvas
        }


        /// <summary>
        /// Handles the MouseUp event to stop drawing, finalize the circle, or stop erasing.
        /// </summary>
        private void OutputWindow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isCircleMode && currentCircle.Width > 0 && currentCircle.Height > 0)
                {
                    // Finalize the circle drawing when mouse is released
                    using (Graphics g = Graphics.FromImage((Bitmap)myCanvas.getBitmap()))
                    {
                        g.DrawEllipse(new Pen((Color)myCanvas.PenColour), currentCircle);
                    }
                    currentCircle = Rectangle.Empty; // Reset the current circle
                }
                else
                {
                    // In pen mode or eraser mode: stop drawing or stop erasing
                    isDrawing = false;
                }
            }
        }

        /// <summary>
        /// Switches between drawing modes (pen, circle, or eraser).
        /// </summary>
        private void ToggleDrawingMode(string mode)
        {
            switch (mode)
            {
                case "pen":
                    isCircleMode = false;
                    isEraserMode = false;
                    break;
                case "circle":
                    isCircleMode = true;
                    isEraserMode = false;
                    break;
                case "eraser":
                    isCircleMode = false;
                    isEraserMode = true;
                    break;
            }
        }

        /// <summary>
        /// Plays or stops the background music based on the current state.
        /// Changes the button image between sound and no sound.
        /// </summary>
        private void SoundBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSoundPlaying)
                {
                    StopSound();
                    UpdateSoundButtonImage("mute.png"); // Change to mute image
                }
                else
                {
                    StartSound();
                    UpdateSoundButtonImage("sound.png"); // Change to sound image
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling sound: " + ex.Message);
            }
        }

        /// <summary>
        /// Stops the background sound.
        /// </summary>
        private void StopSound()
        {
            player.Stop();
            isSoundPlaying = false; // Set the state to stopped
        }

        /// <summary>
        /// Starts playing the background sound.
        /// </summary>
        private void StartSound()
        {
            using (Stream? soundStream = GetEmbeddedResourceStream("main.Resources.bgmusic1.wav"))
            {
                if (soundStream == null)
                {
                    MessageBox.Show("Sound resource not found.");
                    return;
                }
                player = new SoundPlayer(soundStream);
                player.PlayLooping();
            }
            isSoundPlaying = true; // Set the state to playing
        }

        /// <summary>
        /// Updates the background image of the Sound button.
        /// </summary>
        /// <param name="imageName">The name of the image to set (e.g., "mute.png" or "sound.png").</param>
        private void UpdateSoundButtonImage(string imageName)
        {
            Stream? imageStream = GetEmbeddedResourceStream($"main.Resources.{imageName}");
            if (imageStream == null)
            {
                MessageBox.Show($"{imageName} resource not found.");
                return;
            }

            Image image = Image.FromStream(imageStream);
            SoundBtn.BackgroundImage = image;
        }

        /// <summary>
        /// Retrieves an embedded resource stream.
        /// </summary>
        /// <param name="resourceName">The full resource path (e.g., "main.Resources.bgmusic1.wav").</param>
        /// <returns>The resource stream.</returns>
        private Stream? GetEmbeddedResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }

        /// <summary>
        /// Clears the canvas, resets positions, and refreshes the form.
        /// </summary>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myCanvas.Clear();
                myCanvas.Reset();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting canvas: " + ex.Message);
            }
        }

        /// <summary>
        /// Paints the canvas onto the form's output window.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The paint event arguments.</param>
        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap b = (Bitmap)myCanvas.getBitmap();
            g.DrawImageUnscaled(b, 0, 0);

            // If we're in circle mode, draw the current circle as a preview while dragging
            if (isCircleMode && currentCircle != Rectangle.Empty)
            {
                g.DrawEllipse(new Pen((Color)myCanvas.PenColour), currentCircle);
            }

            if (loadedBitmap != null)
            {
                g.DrawImageUnscaled(loadedBitmap, 0, 0);
                loadedBitmap = null;
            }
        }

        /// <summary>
        /// Executes the program when the panel is clicked, similar to the button click functionality.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void PlayBtn_Click(object sender, EventArgs e)
        {
            ErrorWindow.Clear();

            try
            {
                string ProgramText = ProgramWindow.Text;
                Parser.ParseProgram(ProgramText);
                Program.Run();
                Refresh();
            }
            catch (CanvasException ex)
            {
                ErrorWindow.AppendText($"Canvas Error: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                ErrorWindow.AppendText($"Error: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Saves the current canvas as an image.
        /// </summary>
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap canvas = (Bitmap)myCanvas.getBitmap();
            CanvasSaver writer = new CanvasSaver();
            writer.SaveCanvas(canvas);
        }

        /// <summary>
        /// Loads an image onto the canvas.
        /// </summary>
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasLoader loader = new CanvasLoader();
            loadedBitmap = loader.LoadCanvas();
            if (loadedBitmap != null)
            {
                OutputWindow.Invalidate();
            }
        }

        /// <summary>
        /// Switches to the pen mode when the "Pen" menu item is clicked.
        /// </summary>
        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleDrawingMode("pen"); // Enable pen mode
        }

        /// <summary>
        /// Switches to the circle mode when the "Circle" menu item is clicked.
        /// </summary>
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleDrawingMode("circle"); // Enable circle mode
        }

        /// <summary>
        /// Switches to the eraser mode when the "Eraser" menu item is clicked.
        /// </summary>
        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleDrawingMode("eraser"); // Enable eraser mode
        }

        // Change the access modifier of ProgramWindow to public
        public string ProgramText
        {
            get
            {
                return ProgramWindow.Text; // Read the text from ProgramWindow
            }
        }

    }
}
