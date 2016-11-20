namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
    using System.Text;
    using Models;

    /// <summary>
    /// <see cref="FailScriptExecuteScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class FailScriptExecuteScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            ScriptExecuteInfo scriptExecuteInfo = scriptingStatus.AditionalData as ScriptExecuteInfo;

            StringBuilder interpretedStatusMessage = new StringBuilder($"[{ scriptExecuteInfo.FileName }]: FAIL");

            interpretedStatusMessage.AppendLine();
            interpretedStatusMessage.Append(scriptExecuteInfo.ThrownException.Message);

            return new Message
            {
                Color = ConsoleOutputColor.Red,
                Text = interpretedStatusMessage.ToString()
            };
        }
    }
}