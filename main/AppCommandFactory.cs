using BOOSE;
using System;
using System.Collections.Generic;

namespace main
{
    /// <summary>
    /// Factory class for creating command objects based on the provided command type.
    /// This class extends <see cref="CommandFactory"/> to provide specific implementations for different commands.
    /// </summary>
    public class AppCommandFactory : CommandFactory
    {
        // Dictionary that maps command strings to their respective command constructors
        private readonly Dictionary<string, Func<ICommand>> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCommandFactory"/> class.
        /// This constructor sets up a dictionary of command types and their associated command creators.
        /// </summary>
        public AppCommandFactory()
        {
            _commands = new Dictionary<string, Func<ICommand>>
            {
                { "tri", () => new AppTriangle() },
                { "write", () => new AppWrite() },
                { "reset", () => new AppReset() },
                { "clear", () => new AppClear() },
                { "circle", () => new AppCircle() },
                { "rect", () => new AppRectangle() },

                { "int", () => new AppInt() },
                { "real", () => new AppReal() },
                { "array", () => new AppArray() },

                { "if", () => new AppIf() },
                { "end", () => new AppEnd() },
                { "else", () => new AppElse() },
                { "for", () => new AppFor() },
                { "while", () => new AppWhile() },

                { "method", () => new AppMethod() },

            };
        }

        /// <summary>
        /// Creates and returns a command object based on the provided command type.
        /// </summary>
        /// <param name="commandType">The command type as a string (e.g., "tri", "circle").</param>
        /// <returns>An <see cref="ICommand"/> implementation based on the command type.</returns>
        /// <exception cref="ArgumentException">Thrown when the command type is not recognized.</exception>
        public override ICommand MakeCommand(string commandType)
        {
            // Normalize the command type to lower case and remove leading/trailing whitespace
            commandType = commandType.ToLower().Trim();

            // Check if the command type exists in the dictionary
            if (_commands.ContainsKey(commandType))
            {
                return _commands[commandType]();  // Return the corresponding command
            }

            // If the command type is not recognized, call the base class method
            return base.MakeCommand(commandType);
        }
    }
}
