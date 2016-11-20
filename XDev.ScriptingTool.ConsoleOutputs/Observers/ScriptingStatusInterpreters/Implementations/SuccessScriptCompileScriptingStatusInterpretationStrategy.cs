namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
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
            throw new NotImplementedException("Script compilation not supported.");
        }
    }
}