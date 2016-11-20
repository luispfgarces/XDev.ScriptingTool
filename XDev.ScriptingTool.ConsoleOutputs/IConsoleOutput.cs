namespace XDev.ScriptingTool.ConsoleOutputs
{
    using System;

    /// <summary>
    /// Represents the interface contract for an object capable of producing console outputs.
    /// </summary>
    internal interface IConsoleOutput
    {
        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        void Write(string text);

        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="consoleOutputColor">Color of the console output.</param>
        void Write(string text, ConsoleOutputColor consoleOutputColor);

        /// <summary>
        /// Writes the specified text, breaking the line at the end of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        void WriteLine(string text);

        /// <summary>
        /// Writes the specified text, breaking the line at the end of the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="consoleOutputColor">Color of the console output.</param>
        void WriteLine(string text, ConsoleOutputColor consoleOutputColor);
    }
}