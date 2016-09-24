namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using Models;

    /// <summary>
    /// <see cref="BeginScriptExecuteScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class BeginScriptExecuteScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            ScriptExecuteInfo scriptExecuteInfo = scriptingStatus.AditionalData as ScriptExecuteInfo;

            return new Message
            {
                Color = ConsoleOutputColor.Blue,
                Text = $"[{ scriptExecuteInfo.FileName }]: Script executing..."
            };
        }
    }
}