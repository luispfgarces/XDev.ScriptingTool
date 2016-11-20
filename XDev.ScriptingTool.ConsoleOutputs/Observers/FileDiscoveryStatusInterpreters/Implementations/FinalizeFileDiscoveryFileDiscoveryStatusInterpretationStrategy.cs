namespace XDev.ScriptingTool.ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="FinalizeFileDiscoveryFileDiscoveryStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusInterpretationStrategy"/>
    internal class FinalizeFileDiscoveryFileDiscoveryStatusInterpretationStrategy : IFileDiscoveryStatusInterpretationStrategy
    {
        /// <summary>
        /// The finalize file discovery message
        /// </summary>
        private const string FinalizeFileDiscoveryMessage = "Finished finding files...";

        /// <summary>
        /// Interprets the file discovery status.
        /// </summary>
        /// <param name="fileDiscoveryStatus">The file discovery status.</param>
        /// <returns></returns>
        public Message InterpretFileDiscoveryStatus(FileDiscoveryStatus fileDiscoveryStatus)
        {
            return new Message
            {
                Text = FinalizeFileDiscoveryFileDiscoveryStatusInterpretationStrategy.FinalizeFileDiscoveryMessage
            };
        }
    }
}