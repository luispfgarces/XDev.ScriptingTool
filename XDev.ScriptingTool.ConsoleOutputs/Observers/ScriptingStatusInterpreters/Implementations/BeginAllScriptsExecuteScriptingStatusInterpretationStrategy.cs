namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="BeginAllScriptsExecuteScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class BeginAllScriptsExecuteScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// The begin all scripts execute message
        /// </summary>
        private const string BeginAllScriptsExecuteMessage = "Executing scripts...";

        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            return new Message
            {
                Text = BeginAllScriptsExecuteScriptingStatusInterpretationStrategy.BeginAllScriptsExecuteMessage
            };
        }
    }
}