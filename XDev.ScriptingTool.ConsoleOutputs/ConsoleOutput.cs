namespace XDev.ScriptingTool.ConsoleOutputs
{
    using System;

    /// <summary>
    /// <see cref="ConsoleOutput"/>
    /// </summary>
    /// <seealso cref="IConsoleOutput"/>
    internal class ConsoleOutput : IConsoleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        /// <param name="consoleOutput">The console output.</param>
        public ConsoleOutput()
        {
        }

        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Write(string text)
        {
            Console.Write(text);
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
            Console.Write(text);
            Console.ForegroundColor = currentConsoleColor;
        }

        /// <summary>
        /// Writes the specified text, breaking the line at the end of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
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
            Console.WriteLine(text);
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}