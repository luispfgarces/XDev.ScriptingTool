namespace XDev.ScriptingTool.ConsolePresentation.ConsoleOutputs
{
    using System;
    using System.IO;

    /// <summary>
    /// <see cref="ConsoleOutput"/>
    /// </summary>
    /// <seealso cref="IConsoleOutput"/>
    internal class ConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// The console output
        /// </summary>
        private readonly TextWriter consoleOutput;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        /// <param name="consoleOutput">The console output.</param>
        public ConsoleOutput(TextWriter consoleOutput)
        {
            this.consoleOutput = consoleOutput;
        }

        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Write(string text)
        {
            this.consoleOutput.Write(text);
        }

        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="consoleOutputColor">Color of the console output.</param>
        public void Write(string text, ConsoleOutputColor consoleOutputColor)
        {
            // Gets current console color to properly restore it after writting text.
            ConsoleColor currentConsoleColor = Console.ForegroundColor;

            Console.ForegroundColor = consoleOutputColor.ToConsoleColor();
            this.consoleOutput.Write(text);
            Console.ForegroundColor = currentConsoleColor;
        }

        /// <summary>
        /// Writes the specified text, breaking the line at the end of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteLine(string text)
        {
            this.consoleOutput.WriteLine(text);
        }

        /// <summary>
        /// Writes the specified text, breaking the line at the end of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="consoleOutputColor">Color of the console output.</param>
        public void WriteLine(string text, ConsoleOutputColor consoleOutputColor)
        {
            // Gets current console color to properly restore it after writting text.
            ConsoleColor currentConsoleColor = Console.ForegroundColor;

            Console.ForegroundColor = consoleOutputColor.ToConsoleColor();
            this.consoleOutput.WriteLine(text);
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}