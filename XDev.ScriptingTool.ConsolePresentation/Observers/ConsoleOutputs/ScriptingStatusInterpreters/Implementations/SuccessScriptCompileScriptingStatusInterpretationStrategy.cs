namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using Models;

    /// <summary>
    /// <see cref="SuccessScriptCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class SuccessScriptCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            ScriptCompileResult scriptCompileResult = scriptingStatus.AditionalData as ScriptCompileResult;

            return new Message
            {
                Color = ConsoleOutputColor.Green,
                Text = $"[{ scriptCompileResult.CompiledScript.FileDiscoveryInfo.FileName }]: SUCCESS"
            };
        }
    }
}