namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.FileDiscoveryStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="BeginFileDiscoveryFileDiscoveryStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusInterpretationStrategy"/>
    internal class BeginFileDiscoveryFileDiscoveryStatusInterpretationStrategy : IFileDiscoveryStatusInterpretationStrategy
    {
        /// <summary>
        /// The begin file discovery message
        /// </summary>
        private const string BeginFileDiscoveryMessage = "Finding files...";

        /// <summary>
        /// Interprets the file discovery status.
        /// </summary>
        /// <param name="fileDiscoveryStatus">The file discovery status.</param>
        /// <returns></returns>
        public Message InterpretFileDiscoveryStatus(FileDiscoveryStatus fileDiscoveryStatus)
        {
            return new Message
            {
                Text = BeginFileDiscoveryFileDiscoveryStatusInterpretationStrategy.BeginFileDiscoveryMessage
            };
        }
    }
}