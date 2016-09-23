namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="FinalizeAllScriptsExecuteScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class FinalizeAllScriptsExecuteScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// The finalize all scripts execute message
        /// </summary>
        private const string FinalizeAllScriptsExecuteMessage = "Finished executing scripts.";

        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            return new Message
            {
                Text = FinalizeAllScriptsExecuteScriptingStatusInterpretationStrategy.FinalizeAllScriptsExecuteMessage
            };
        }
    }
}