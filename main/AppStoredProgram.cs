using System;
using System.Collections;
using System.Collections.Generic;
using BOOSE;

namespace main
{
    /// <summary>
    /// Represents a stored program with custom logic for handling command execution, including a stack for conditional commands.
    /// Inherits from <see cref="StoredProgram"/> and overrides relevant methods for program control.
    /// </summary>
    public class AppStoredProgram : StoredProgram
    {
        /// <summary>
        /// A stack that holds conditional commands, allowing the program to manage and execute commands in a specific order.
        /// </summary>
        private Stack commandStack = new Stack();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppStoredProgram"/> class.
        /// This constructor passes the canvas to the base class and sets up the program for execution.
        /// </summary>
        /// <param name="canvas">The canvas where drawing and other operations will take place.</param>
        public AppStoredProgram(ICanvas canvas) : base(canvas) { }

        /// <summary>
        /// Pushes a conditional command onto the command stack.
        /// This allows for tracking and execution of commands in a specific sequence.
        /// </summary>
        /// <param name="command">The conditional command to push onto the stack.</param>
        public override void Push(ConditionalCommand command)
        {
            commandStack.Push(command);
        }

        /// <summary>
        /// Pops a conditional command from the command stack.
        /// If the stack is empty, an exception is thrown.
        /// </summary>
        /// <returns>The conditional command popped from the stack.</returns>
        /// <exception cref="StoredProgramException">Thrown when the stack is empty.</exception>
        public override ConditionalCommand Pop()
        {
            if (commandStack.Count == 0)
            {
                throw new StoredProgramException("Command stack is empty.");
            }
            return commandStack.Pop() as ConditionalCommand ?? throw new StoredProgramException("Popped command is not a ConditionalCommand.");
        }

        /// <summary>
        /// Resets the program, clearing the command stack and resetting the program's state.
        /// </summary>
        public override void ResetProgram()
        {
            base.ResetProgram();
            commandStack.Clear();
        }

        /// <summary>
        /// Runs the stored program by iterating through commands and executing them.
        /// It includes logic for error handling and preventing infinite loops.
        /// </summary>
        public override void Run()
        {
            int num = 0;

            while (Commandsleft())
            {
                ICommand command = (ICommand)NextCommand();
                try
                {
                    num++;
                    command.Execute();
                }
                catch (BOOSEException ex)
                {
                    SyntaxOk = false;
                    throw new StoredProgramException(ex.Message + " Error at line " + PC);
                }

                if (num > 50000 && PC < 20)
                {
                    throw new StoredProgramException("Program has faced an infinite loop.");
                }
            }

            if (commandStack.Count != 0)
            {
                Pop();
                SyntaxOk = false;
                throw new StoredProgramException("Error popping.");
            }
        }
    }
}
