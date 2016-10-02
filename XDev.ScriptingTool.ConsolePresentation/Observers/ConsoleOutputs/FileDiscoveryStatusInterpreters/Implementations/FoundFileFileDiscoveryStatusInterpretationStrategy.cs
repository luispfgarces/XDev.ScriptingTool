namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.FileDiscoveryStatusInterpreters.Implementations
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using Models;

    /// <summary>
    /// <see cref="FoundFileFileDiscoveryStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusInterpretationStrategy"/>
    internal class FoundFileFileDiscoveryStatusInterpretationStrategy : IFileDiscoveryStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the file discovery status.
        /// </summary>
        /// <param name="fileDiscoveryStatus">The file discovery status.</param>
        /// <returns></returns>
        public Message InterpretFileDiscoveryStatus(FileDiscoveryStatus fileDiscoveryStatus)
        {
            FileDiscoveryInfo fileDiscoveryInfo = fileDiscoveryStatus.AditionalData as FileDiscoveryInfo;

            return new Message
            {
                Color = ConsoleOutputColor.Gray,
                Text = $@"Found file: { fileDiscoveryInfo.FileName }"
            };
        }
    }
}