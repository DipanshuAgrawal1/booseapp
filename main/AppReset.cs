using BOOSE;
using System;

namespace main
{
    /// <summary>
    /// Command to reset the pen position to the origin on the canvas.
    /// </summary>
    public class AppReset : CommandOneParameter
    {
        /// <summary>
        /// Default constructor for the AppReset command.
        /// </summary>
        public AppReset()
        {
        }

        /// <summary>
        /// Constructor that accepts a canvas to reset the pen on.
        /// </summary>
        /// <param name="canvas">The canvas where the pen will be reset.</param>
        public AppReset(Canvas canvas)
            : base(canvas)
        {
        }

        /// <summary>
        /// Executes the reset command. It resets the pen position to the origin (0, 0).
        /// </summary>
        public override void Execute()
        {
            base.Execute();

            // Call the Reset method on the canvas (assuming it has the Reset function)
            base.Canvas.Reset(); // Resets the pen position to the origin (0, 0)
        }
    }
}
