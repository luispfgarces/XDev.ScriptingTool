namespace XDev.ScriptingTool.ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="IFileDiscoveryStatusInterpretationStrategyFactory"/>
    /// </summary>
    internal interface IFileDiscoveryStatusInterpretationStrategyFactory
    {
        /// <summary>
        /// Gets the strategy for the given file discovery status description.
        /// </summary>
        /// <param name="fileDiscoveryStatusDescription">The file discovery status description.</param>
        /// <returns></returns>
        IFileDiscoveryStatusInterpretationStrategy GetStrategy(FileDiscoveryStatusDescription fileDiscoveryStatusDescription);
    }
}