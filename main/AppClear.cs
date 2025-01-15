using BOOSE;
using System;

namespace main
{
    /// <summary>
    /// Command to clear the canvas.
    /// </summary>
    public class AppClear : CommandOneParameter
    {
        /// <summary>
        /// Default constructor for the AppClear command.
        /// </summary>
        public AppClear()
        {
        }

        /// <summary>
        /// Constructor that accepts a canvas to clear.
        /// </summary>
        /// <param name="canvas">The canvas that will be cleared.</param>
        public AppClear(Canvas canvas)
            : base(canvas)
        {
        }

        /// <summary>
        /// Executes the clear command. It clears the entire canvas.
        /// </summary>
        public override void Execute()
        {
            base.Execute();

            // Clear the canvas using the Canvas's Clear method
            base.Canvas.Clear(); // Assumes that Canvas has a Clear method that clears the drawing area
        }
    }
}
