namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.FileDiscoveryStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="FileDiscoveryStatusInterpretationStrategyFactory"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusInterpretationStrategyFactory"/>
    internal class FileDiscoveryStatusInterpretationStrategyFactory : IFileDiscoveryStatusInterpretationStrategyFactory
    {
        /// <summary>
        /// Gets the strategy for the given file discovery status description.
        /// </summary>
        /// <param name="fileDiscoveryStatusDescription">The file discovery status description.</param>
        /// <returns></returns>
        public IFileDiscoveryStatusInterpretationStrategy GetStrategy(FileDiscoveryStatusDescription fileDiscoveryStatusDescription)
        {
            switch (fileDiscoveryStatusDescription)
            {
                case FileDiscoveryStatusDescription.BeginFileDiscovery:
                    return new BeginFileDiscoveryFileDiscoveryStatusInterpretationStrategy();

                case FileDiscoveryStatusDescription.FinalizeFileDiscovery:
                    return new FinalizeFileDiscoveryFileDiscoveryStatusInterpretationStrategy();

                case FileDiscoveryStatusDescription.FoundFile:
                    return new FoundFileFileDiscoveryStatusInterpretationStrategy();

                default:
                    return new EmptyFileDiscoveryStatusInterpretationStrategy();
            }
        }
    }
}