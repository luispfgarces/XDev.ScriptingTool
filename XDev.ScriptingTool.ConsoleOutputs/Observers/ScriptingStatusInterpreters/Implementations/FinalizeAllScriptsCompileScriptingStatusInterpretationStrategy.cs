namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="FinalizeAllScriptsCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class FinalizeAllScriptsCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// The finalize all scripts compile message
        /// </summary>
        private const string FinalizeAllScriptsCompileMessage = "Finished compiling scripts.";

        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            return new Message
            {
                Text = FinalizeAllScriptsCompileScriptingStatusInterpretationStrategy.FinalizeAllScriptsCompileMessage
            };
        }
    }
}