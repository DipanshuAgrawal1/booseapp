using BOOSE;
using System;
using System.Diagnostics;

namespace main
{
    /// <summary>
    /// Represents a command to draw a circle on the canvas.
    /// Inherits from <see cref="CommandTwoParameters"/> to handle a canvas, a radius, and a filled status.
    /// </summary>
    public class AppCircle : CommandTwoParameters
    {
        private int radius;
        private bool filled;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCircle"/> class.
        /// This default constructor allows the object to be instantiated without parameters.
        /// </summary>
        public AppCircle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCircle"/> class with specified parameters.
        /// </summary>
        /// <param name="canvas">The canvas where the circle will be drawn.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Indicates whether the circle should be filled.</param>
        public AppCircle(Canvas canvas, int radius, bool filled)
            : base(canvas)
        {
            this.radius = radius;
            this.filled = filled;
        }

        /// <summary>
        /// Executes the circle drawing command on the canvas.
        /// This method draws a circle with the specified radius and filled status.
        /// </summary>
        public override void Execute()
        {
            base.Execute();

            radius = base.Paramsint[0];

            if (radius <= 0)
            {
                throw new Exception("Radius of the circle must be greater than zero.");
            }

            base.Canvas.Circle(radius, filled);
        }

        /// <summary>
        /// Validates the parameters provided for the circle command.
        /// </summary>
        /// <param name="parameterList">The list of parameters provided in the command.</param>
        /// <exception cref="CommandException">Thrown if the filled status is invalid or if the parameters are incorrect.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length == 1)
            {
                this.filled = false;
            }
            else if (parameterList.Length == 2)
            {
                if (!bool.TryParse(parameterList[1], out bool parsedFilled))
                {
                    throw new CommandException($"Invalid filled status: {parameterList[1]}. It should be 'true' or 'false'.");
                }
                this.filled = parsedFilled;
            }
            else
            {
                throw new Exception("Circle command requires exactly one or two parameters: radius and optionally filled status.");
            }
        }
    }
}