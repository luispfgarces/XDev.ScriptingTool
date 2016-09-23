namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using Models;

    /// <summary>
    /// <see cref="FinalizeScriptCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class FinalizeScriptCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            FileDiscoveryInfo fileDiscoveryInfo = scriptingStatus.AditionalData as FileDiscoveryInfo;

            return new Message
            {
                Color = ConsoleOutputColor.Blue,
                Text = $"[{ fileDiscoveryInfo.FileName }]: Finished compiling file."
            };
        }
    }
}