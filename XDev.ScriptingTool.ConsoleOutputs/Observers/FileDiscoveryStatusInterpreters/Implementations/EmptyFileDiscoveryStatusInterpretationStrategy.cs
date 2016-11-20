namespace XDev.ScriptingTool.ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="EmptyFileDiscoveryStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusInterpretationStrategy"/>
    internal class EmptyFileDiscoveryStatusInterpretationStrategy : IFileDiscoveryStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the file discovery status.
        /// </summary>
        /// <param name="fileDiscoveryStatus">The file discovery status.</param>
        /// <returns></returns>
        public Message InterpretFileDiscoveryStatus(FileDiscoveryStatus fileDiscoveryStatus)
        {
            return new Message
            {
                Text = string.Empty
            };
        }
    }
}