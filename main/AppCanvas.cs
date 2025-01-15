using BOOSE;
using System;
using System.Drawing;

namespace main
{
    /// <summary>
    /// Custom exception for handling errors specific to the AppCanvas.
    /// </summary>
    public class CanvasException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasException"/> class.
        /// </summary>
        public CanvasException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CanvasException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasException"/> class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public CanvasException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Represents a canvas for drawing shapes, lines, and text.
    /// </summary>
    public class AppCanvas : ICanvas
    {
        private int xPos, yPos;
        private Color penColour;

        private int XCanvasSize, YCanvasSize;
        private Pen Pen;

        private const int XSIZE = 680;
        private const int YSIZE = 384;

        private Bitmap bm = new Bitmap(XSIZE, YSIZE);
        private Graphics g;
        private int penSize = 5;

        /// <summary>
        /// Initializes a new instance of the AppCanvas class with default size.
        /// </summary>
        public AppCanvas()
        {
            Pen = new Pen(Color.Black, penSize); // Initialize Pen with a default value
            g = Graphics.FromImage(bm); // Initialize g with a default value
            Set(XSIZE, YSIZE);
        }

        /// <summary>
        /// Gets or sets the X position of the pen.
        /// </summary>
        public int Xpos
        {
            get => xPos;
            set => xPos = value;
        }

        /// <summary>
        /// Gets or sets the Y position of the pen.
        /// </summary>
        public int Ypos
        {
            get => yPos;
            set => yPos = value;
        }

        /// <summary>
        /// Gets or sets the pen color.
        /// </summary>
        public object PenColour
        {
            get => penColour;
            set => penColour = (Color)value;
        }

        /// <summary>
        /// Draws a circle at the current position.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Indicates whether the circle is filled.</param>
        /// <exception cref="CanvasException">Thrown when the radius is invalid.</exception>
        public void Circle(int radius, bool filled)
        {
            if (radius < 0)
                throw new CanvasException($"Invalid circle radius: {radius}. Radius must be non-negative.");

            try
            {
                if (g != null)
                {
                    if (filled)
                        g.FillEllipse(new SolidBrush(penColour), xPos - radius, yPos - radius, radius * 2, radius * 2);
                    else
                        g.DrawEllipse(Pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
                else
                {
                    throw new CanvasException("Graphics object is not initialized. Cannot draw circle.");
                }
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while drawing circle.", ex);
            }
        }

        /// <summary>
        /// Clears the canvas to a white background.
        /// </summary>
        public void Clear()
        {
            try
            {
                // Clear the canvas with the new color (239, 216, 183)
                g?.Clear(Color.FromArgb(239, 216, 183));
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while clearing the canvas.", ex);
            }
        }


        /// <summary>
        /// Draws a line from the current position to the specified position.
        /// </summary>
        /// <param name="toX">The X coordinate to draw to.</param>
        /// <param name="toY">The Y coordinate to draw to.</param>
        /// <exception cref="CanvasException">Thrown when the coordinates are out of bounds.</exception>
        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                throw new CanvasException($"Invalid screen position: DrawTo({toX}, {toY}). Coordinates must be within the canvas bounds.");

            try
            {
                g?.DrawLine(Pen, xPos, yPos, toX, toY);
                xPos = toX;
                yPos = toY;
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while drawing line.", ex);
            }
        }

        /// <summary>
        /// Returns the current bitmap of the canvas.
        /// </summary>
        /// <returns>The bitmap object.</returns>
        public object getBitmap()
        {
            return bm;
        }

        /// <summary>
        /// Moves the pen to the specified position.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <exception cref="CanvasException">Thrown when the coordinates are out of bounds.</exception>
        public void MoveTo(int x, int y)
        {
            if (x < 0 || x > XCanvasSize || y < 0 || y > YCanvasSize)
                throw new CanvasException($"Invalid screen position: MoveTo({x}, {y}). Coordinates must be within the canvas bounds.");

            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// Draws a rectangle at the current position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Indicates whether the rectangle is filled.</param>
        /// <exception cref="CanvasException">Thrown when the width or height are invalid.</exception>
        public void Rect(int width, int height, bool filled)
        {
            if (width < 0 || height < 0)
                throw new CanvasException($"Invalid rectangle dimensions: width={width}, height={height}. Both must be non-negative.");

            try
            {
                if (g != null)
                {
                    if (filled)
                        g.FillRectangle(new SolidBrush(penColour), xPos, yPos, width, height);
                    else
                        g.DrawRectangle(Pen, xPos, yPos, width, height);
                }
                else
                {
                    throw new CanvasException("Graphics object is not initialized. Cannot draw rectangle.");
                }
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while drawing rectangle.", ex);
            }
        }

        /// <summary>
        /// Resets the pen position to the origin.
        /// </summary>
        public void Reset()
        {
            xPos = 0;
            yPos = 0;
        }

        /// <summary>
        /// Sets the canvas size and initializes the graphics object.
        /// </summary>
        /// <param name="xsize">The width of the canvas.</param>
        /// <param name="ysize">The height of the canvas.</param>
        public void Set(int xsize, int ysize)
        {
            XCanvasSize = xsize;
            YCanvasSize = ysize;
            xPos = yPos = 0;

            try
            {
                g = Graphics.FromImage(bm);
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error initializing graphics object for the canvas.", ex);
            }
        }

        /// <summary>
        /// Sets the pen color.
        /// </summary>
        /// <param name="red">Red component (0-255).</param>
        /// <param name="green">Green component (0-255).</param>
        /// <param name="blue">Blue component (0-255).</param>
        /// <exception cref="CanvasException">Thrown when the color components are out of range.</exception>
        public void SetColour(int red, int green, int blue)
        {
            if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
                throw new CanvasException($"Invalid color: ({red}, {green}, {blue}). Each component must be in the range [0, 255].");

            try
            {
                penColour = Color.FromArgb(255, red, green, blue);
                Pen = new Pen(penColour, penSize);
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while setting pen color.", ex);
            }
        }

        /// <summary>
        /// Draws a triangle at the current position.
        /// </summary>
        /// <param name="width">The base width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        /// <exception cref="CanvasException">Thrown when the width or height are invalid.</exception>
        public void Tri(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new CanvasException($"Invalid triangle dimensions: width = {width}, height = {height}. Both must be non-negative.");

            try
            {
                if (g != null)
                {
                    // Define the points of the triangle
                    Point[] points = new Point[]
                    {
                new Point(xPos, yPos - height / 2), // Top point
                new Point(xPos - width / 2, yPos + height / 2), // Bottom-left point
                new Point(xPos + width / 2, yPos + height / 2)  // Bottom-right point
                    };

                    // Draw only the outline of the triangle
                    g.DrawPolygon(Pen, points);
                }
                else
                {
                    throw new CanvasException("Graphics object is not initialized. Cannot draw triangle.");
                }
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while drawing triangle.", ex);
            }
        }


        /// <summary>
        /// Draws a triangle at the current position.
        /// </summary>
        /// <param name="width">The base width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        /// <param name="filled">Flag to determine if the triangle should be filled or outlined.</param>
        /// <exception cref="CanvasException">Thrown when the width or height are invalid.</exception>
        public void Tri(int width, int height, bool filled)
        {
            if (width < 0 || height < 0)
                throw new CanvasException($"Invalid triangle dimensions: width = {width}, height = {height}. Both must be non-negative.");

            try
            {
                if (g != null)
                {
                    // Define the points of the triangle
                    Point[] points = new Point[]
                    {
                new Point(xPos, yPos - height / 2), // Top point
                new Point(xPos - width / 2, yPos + height / 2), // Bottom-left point
                new Point(xPos + width / 2, yPos + height / 2)  // Bottom-right point
                    };

                    if (filled)
                        g.FillPolygon(new SolidBrush(penColour), points); // Fill the triangle
                    else
                        g.DrawPolygon(Pen, points); // Draw only the outline of the triangle
                }
                else
                {
                    throw new CanvasException("Graphics object is not initialized. Cannot draw triangle.");
                }
            }
            catch (Exception ex)
            {
                throw new CanvasException("Error while drawing triangle.", ex);
            }
        }



        /// <summary>
        /// Writes text at the current position.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <exception cref="CanvasException">Thrown when the text is null or empty, or if the graphics object is not initialized.</exception>
        public void WriteText(string text)
        {
            // Ensure the text is not null or empty
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new CanvasException("Text cannot be null, empty, or whitespace.");
            }

            try
            {
                // Check if the Graphics object is initialized
                if (g != null)
                {
                    // Ensure the font and brush resources are managed properly
                    using (Font font = new Font("Arial", 12))
                    using (Brush brush = new SolidBrush(penColour))
                    {
                        // Draw the text at the current position
                        g.DrawString(text, font, brush, xPos, yPos);
                    }
                }
                else
                {
                    throw new CanvasException("Graphics object is not initialized. Cannot write text.");
                }
            }
            catch (Exception ex)
            {
                // Log or rethrow any exception related to drawing
                throw new CanvasException("Error while writing text.", ex);
            }
        }



    }
}
