using BOOSE;
using System;

namespace main
{
    /// <summary>
    /// Represents the triangle drawing command for the canvas, inheriting from <see cref="CommandTwoParameters"/>.
    /// This command draws a triangle based on the provided base width and height, and optionally whether it should be filled.
    /// </summary>
    public class AppTriangle : CommandTwoParameters
    {
        /// <summary>
        /// The base width of the triangle.
        /// </summary>
        private int baseWidth;

        /// <summary>
        /// The height of the triangle.
        /// </summary>
        private int height;

        /// <summary>
        /// Indicates whether the triangle should be filled or not.
        /// </summary>
        private bool filled;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppTriangle"/> class.
        /// This constructor is used when no parameters are provided for the triangle command.
        /// </summary>
        public AppTriangle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppTriangle"/> class with a specified base width and height.
        /// This constructor sets the triangle to be filled by default.
        /// </summary>
        /// <param name="canvas">The canvas where the triangle will be drawn.</param>
        /// <param name="baseWidth">The base width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public AppTriangle(Canvas canvas, int baseWidth, int height)
            : base(canvas)
        {
            this.baseWidth = baseWidth;
            this.height = height;
            this.filled = true;
        }

        /// <summary>
        /// Executes the triangle drawing command on the canvas.
        /// This method retrieves the base width and height from the parameters and draws the triangle.
        /// </summary>
        public override void Execute()
        {
            base.Execute();

            // Ensure Paramsint contains valid data
            if (base.Paramsint.Length < 2)
            {
                throw new CanvasException("Triangle command requires two parameters: base width and height.");
            }

            // Extract baseWidth and height
            baseWidth = base.Paramsint[0];
            height = base.Paramsint[1];

            // Ensure that base width and height are greater than zero
            if (baseWidth <= 0 || height <= 0)
            {
                throw new CanvasException("Base width and height of the triangle must be greater than zero.");
            }

            // Pass the filled flag to the Tri method on the canvas
            base.Canvas.Tri(baseWidth, height);
        }

        /// <summary>
        /// Validates the parameters provided for the triangle command.
        /// It checks that the filled status is a valid boolean value.
        /// </summary>
        /// <param name="parameterList">The list of parameters provided in the command.</param>
        public override void CheckParameters(string[] parameterList)
        {
            // Ensure there are at least 2 parameters (baseWidth, height)
            if (parameterList.Length < 2 || parameterList.Length > 3)
            {
                throw new CanvasException("Triangle command requires exactly two or three parameters: base width, height, and optionally filled status.");
            }

            // Validate baseWidth and height are integers
            if (!int.TryParse(parameterList[0], out int parsedBaseWidth))
            {
                throw new CanvasException($"Invalid base width: {parameterList[0]}. It should be a valid integer.");
            }

            if (!int.TryParse(parameterList[1], out int parsedHeight))
            {
                throw new CanvasException($"Invalid height: {parameterList[1]}. It should be a valid integer.");
            }

            this.baseWidth = parsedBaseWidth;
            this.height = parsedHeight;

            // Check if the triangle is filled and validate it
            if (parameterList.Length == 3)
            {
                if (!bool.TryParse(parameterList[2], out bool parsedFilled))
                {
                    throw new CanvasException($"Invalid filled status: {parameterList[2]}. It should be 'true' or 'false'.");
                }
                // Pass the filled flag to the Tri method on the canvas
                base.Canvas.Tri(baseWidth, height); // Removed the filled parameter
                this.filled = parsedFilled;
            }
            else
            {
                this.filled = true; // Default to filled if no third parameter
            }
        }
    }
}
