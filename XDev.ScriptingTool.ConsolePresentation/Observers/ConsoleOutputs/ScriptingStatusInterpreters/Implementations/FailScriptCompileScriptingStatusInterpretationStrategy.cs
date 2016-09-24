namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
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
            throw new NotImplementedException("Script compilation not supported.");
        }
    }
}