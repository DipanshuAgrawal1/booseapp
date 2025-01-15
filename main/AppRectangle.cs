using BOOSE;
using System;
using System.Diagnostics;

namespace main
{
    /// <summary>
    /// Command to draw a rectangle on the canvas with optional filled status.
    /// </summary>
    public class AppRectangle : CommandThreeParameters
    {
        private int width;
        private int height;
        private bool filled;

        /// <summary>
        /// Default constructor for the AppRectangle command.
        /// </summary>
        public AppRectangle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AppRectangle command with the specified canvas, width, height, and filled status.
        /// </summary>
        /// <param name="canvas">The canvas on which the rectangle will be drawn.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Specifies whether the rectangle should be filled.</param>
        public AppRectangle(Canvas canvas, int width, int height, bool filled)
            : base(canvas)
        {
            this.width = width;
            this.height = height;
            this.filled = filled;
        }

        /// <summary>
        /// Executes the rectangle drawing command on the canvas.
        /// It checks if the dimensions of the rectangle are valid (greater than zero) and then draws the rectangle.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            width = base.Paramsint[0];
            height = base.Paramsint[1];

            // Validate dimensions of the rectangle
            if (width <= 0 || height <= 0)
            {
                throw new Exception("Width and height of the rectangle must be greater than zero.");
            }

            // Call the Rect method on the canvas with the dimensions and filled status
            base.Canvas.Rect(width, height, filled);
        }

        /// <summary>
        /// Validates the parameters provided for the rectangle command.
        /// It checks if the parameters are correctly provided and validates the filled status if provided.
        /// </summary>
        /// <param name="parameterList">The list of parameters provided in the command. The first two are the width and height, and the third one is an optional filled status.</param>
        /// <exception cref="CommandException">Thrown when the filled status is invalid or the wrong number of parameters is provided.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            Debug.WriteLine(parameterList.Length);
            Debug.WriteLine("APPRECTANGLE");

            // If only two parameters are provided, assume the rectangle is not filled
            if (parameterList.Length == 2)
            {
                this.filled = false;
            }
            // If three parameters are provided, the third parameter must be the filled status
            else if (parameterList.Length == 3)
            {
                // Validate the filled status (true or false)
                if (!bool.TryParse(parameterList[2], out bool parsedFilled))
                {
                    throw new CommandException($"Invalid filled status: {parameterList[1]}. It should be 'true' or 'false'.");
                }
                this.filled = parsedFilled;
            }
            // If the number of parameters is not 2 or 3, throw an exception
            else
            {
                throw new Exception("Rectangle command requires exactly two or three parameters: height, width, and optionally filled status.");
            }
        }
    }
}