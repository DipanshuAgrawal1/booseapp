using BOOSE;
using System;
using System.Data;

namespace main
{
    /// <summary>
    /// Command to write evaluated expressions on the canvas.
    /// This command evaluates a string expression and writes the result on the canvas.
    /// </summary>
    public class AppWrite : CommandOneParameter
    {
        /// <summary>
        /// Default constructor for the AppWrite command.
        /// Initializes a new instance of the <see cref="AppWrite"/> class.
        /// </summary>
        public AppWrite()
        {
        }

        /// <summary>
        /// Executes the AppWrite command.
        /// This method evaluates the expression provided as a parameter and writes the result to the canvas.
        /// </summary>
        public override void Execute()
        {
            // Evaluate the expression with the provided string parameter
            var evaluatedExpression = base.Program.EvaluateExpressionWithString(base.Parameters[0]);

            // Write the evaluated result on the canvas
            canvas.WriteText(evaluatedExpression);
        }

        /// <summary>
        /// Checks the validity of the parameters passed to the AppWrite command.
        /// This method ensures that the command receives at least one parameter.
        /// </summary>
        /// <param name="parameter">The list of parameters passed to the command.</param>
        public override void CheckParameters(string[] parameter)
        {
            // Ensure at least one parameter is provided
            if (parameter.Length < 1)
            {
                throw new CommandException("Must have parameter");
            }
        }
    }
}
