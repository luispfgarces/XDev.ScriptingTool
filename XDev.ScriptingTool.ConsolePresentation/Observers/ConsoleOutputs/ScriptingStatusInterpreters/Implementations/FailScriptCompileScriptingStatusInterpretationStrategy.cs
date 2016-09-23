namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using System.Text;
    using ConsolePresentation.ConsoleOutputs;
    using Models;

    /// <summary>
    /// <see cref="FailScriptCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class FailScriptCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            ScriptCompileResult scriptCompileResult = scriptingStatus.AditionalData as ScriptCompileResult;

            StringBuilder interpretedStatusMessage = new StringBuilder($"[{ scriptCompileResult.CompiledScript.FileDiscoveryInfo.FileName }]: FAIL");

            foreach (var error in scriptCompileResult.Errors)
            {
                interpretedStatusMessage.AppendLine();
                interpretedStatusMessage.Append(error);
            }

            return new Message
            {
                Color = ConsoleOutputColor.Red,
                Text = interpretedStatusMessage.ToString()
            };
        }
    }
}