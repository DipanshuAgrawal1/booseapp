using System;
using BOOSE;

namespace main;

/// <summary>
/// A parser that allows unrestricted parsing of commands and programs.
/// </summary>
public class AppParser : Parser
{
    private readonly CommandFactory factory;
    private readonly StoredProgram program;

    /// <summary>
    /// Initialises a new instance of the <see cref="AppParser"/> class.
    /// </summary>
    /// <param name="factory">The command factory used to create commands.</param>
    /// <param name="program">The stored program to parse and manage commands.</param>
    public AppParser(CommandFactory factory, StoredProgram program) : base(factory, program)
    {
        this.factory = factory ?? throw new ArgumentNullException(nameof(factory), "Factory cannot be null.");
        this.program = program ?? throw new ArgumentNullException(nameof(program), "Program cannot be null.");
    }

    /// <summary>
    /// Parses a program represented as a string of commands.
    /// </summary>
    /// <param name="program">The program string to parse.</param>
    /// <exception cref="ArgumentException">Thrown when the program string is null or empty.</exception>
    public override void ParseProgram(string program)
    {
        if (string.IsNullOrWhiteSpace(program))
        {
            throw new ArgumentException("Program cannot be null or empty.", nameof(program));
        }

        string[] lines = program.Split('\n');
        this.program.SyntaxOk = false; // Reset syntax status

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line))
            {
                continue; // Skip empty lines
            }

            try
            {
                // Parse the line into a command
                ICommand command = ParseCommand(line);

                // Special handling for Method commands
                if (command is Method method)
                {
                    // Parse and remove the method declaration
                    command = ParseCommand($"{method.Type} {method.MethodName}");
                    this.program.Remove(command);

                    // Parse and remove local variables in the method
                    foreach (string variable in method.LocalVariables)
                    {
                        command = ParseCommand(variable);
                        if (command is Evaluation evaluation)
                        {
                            evaluation.Local = true;
                        }
                        this.program.Remove(command);
                    }
                }
            }
            catch (BOOSEException ex)
            {
                // Log and continue processing other lines
                Console.WriteLine($"Error: {ex.Message} at line {i + 1}");
            }
        }

        // Mark syntax as valid if no exceptions were thrown
        this.program.SyntaxOk = true;
    }
}