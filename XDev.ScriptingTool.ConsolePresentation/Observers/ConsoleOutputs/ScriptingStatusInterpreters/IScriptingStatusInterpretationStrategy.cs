namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters
{
    using System;
    using ScriptingTool.Models;

    /// <summary>
    /// Represents a interface contract for a scripting status interpreter that issues human-readable
    /// messages for a given state.
    /// </summary>
    internal interface IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        Message InterpretScriptingStatus(ScriptingStatus scriptingStatus);
    }
}