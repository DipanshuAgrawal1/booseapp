using System;
using System.Threading;

namespace main
{
    /// <summary>
    /// Handles console input on a separate thread, passing commands to a parser for execution.
    /// </summary>
    public class ConsoleInputHandler
    {
        private Thread consoleThread; // Thread for handling console input
        private Form1 form;  // Reference to the Form1 instance (where Parser exists)

        /// <summary>
        /// Constructor to initialize the console input handler with a reference to Form1.
        /// </summary>
        /// <param name="formInstance">Instance of Form1, used to access the parser.</param>
        public ConsoleInputHandler(Form1 formInstance)
        {
            form = formInstance;
        }

        /// <summary>
        /// Starts the console input handler on a separate thread.
        /// </summary>
        public void Start()
        {
            // Initialize and start the thread for handling console input
            consoleThread = new Thread(new ThreadStart(RunConsole));
            consoleThread.Start();
        }

        /// <summary>
        /// Continuously runs the console application, reading input commands and sending them to the parser for processing.
        /// </summary>
        private void RunConsole()
        {
            while (true)
            {
                // Read input from the console
                string input = Console.ReadLine();

                // If the input is empty, continue to the next iteration
                if (string.IsNullOrEmpty(input))
                    continue;

                // Process the command entered by the user
                ProcessCommand(input);
            }
        }

        /// <summary>
        /// Processes the console command and sends it to the parser for execution.
        /// </summary>
        /// <param name="command">The command entered in the console by the user.</param>
        public void ProcessCommand(string command)
        {
            // Log the command for debugging purposes
            Console.WriteLine("Processing command: " + command);

            // Pass the command to the form's parser for processing
            form.Parser.ParseProgram(command); // Parse the command

            // Execute the program logic
            form.Program.Run();

            // Refresh the form (or any UI updates if needed)
            form.Refresh();
        }

        /// <summary>
        /// Stops the console thread when the form is closed or the application exits.
        /// </summary>
        public void Stop()
        {
            if (consoleThread != null && consoleThread.IsAlive)
            {
                // Abort the thread (consider implementing a more graceful shutdown method)
                consoleThread.Abort();
            }
        }
    }
}
