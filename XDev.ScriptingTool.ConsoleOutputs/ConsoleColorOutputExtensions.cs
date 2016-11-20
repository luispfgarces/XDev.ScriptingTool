namespace XDev.ScriptingTool.ConsoleOutputs
{
    using System;

    /// <summary>
    /// <see cref="ConsoleColorOutputExtensions"/>
    /// </summary>
    internal static class ConsoleColorOutputExtensions
    {
        /// <summary>
        /// Converts the console output color to console color.
        /// </summary>
        /// <param name="consoleOutputColor">Color of the console output.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Unrecognized console output color.</exception>
        public static ConsoleColor ToConsoleColor(this ConsoleOutputColor consoleOutputColor)
        {
            switch (consoleOutputColor)
            {
                case ConsoleOutputColor.Gray:
                    return ConsoleColor.Gray;

                case ConsoleOutputColor.Red:
                    return ConsoleColor.Red;

                case ConsoleOutputColor.Green:
                    return ConsoleColor.DarkGreen;

                case ConsoleOutputColor.Yellow:
                    return ConsoleColor.DarkYellow;

                case ConsoleOutputColor.Blue:
                    return ConsoleColor.DarkBlue;

                default:
                    throw new InvalidOperationException("Unrecognized console output color.");
            }
        }
    }
}