namespace XDev.ScriptingTool.ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters
{
    using System;
    using Models;
    using ScriptingStatusInterpreters;

    /// <summary>
    /// Represents a interface contract for a file discovery status interpreter that issues
    /// human-readable messages for a given state.
    /// </summary>
    internal interface IFileDiscoveryStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the file discovery status.
        /// </summary>
        /// <param name="fileDiscoveryStatus">The file discovery status.</param>
        /// <returns></returns>
        Message InterpretFileDiscoveryStatus(FileDiscoveryStatus fileDiscoveryStatus);
    }
}