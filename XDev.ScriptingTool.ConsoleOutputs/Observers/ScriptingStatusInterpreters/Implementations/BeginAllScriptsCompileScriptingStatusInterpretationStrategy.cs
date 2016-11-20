namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="BeginAllScriptsCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class BeginAllScriptsCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// The begin all scripts compile message
        /// </summary>
        private const string BeginAllScriptsCompileMessage = "Compiling scripts...";

        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            return new Message
            {
                Text = BeginAllScriptsCompileScriptingStatusInterpretationStrategy.BeginAllScriptsCompileMessage
            };
        }
    }
}