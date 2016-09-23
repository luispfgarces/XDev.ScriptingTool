namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="IScriptingStatusInterpretationStrategyFactory"/>
    /// </summary>
    internal interface IScriptingStatusInterpretationStrategyFactory
    {
        /// <summary>
        /// Gets the strategy for the given scripting status description.
        /// </summary>
        /// <param name="scriptingStatusDescription">The scripting status description.</param>
        /// <returns></returns>
        IScriptingStatusInterpretationStrategy GetStrategy(ScriptingStatusDescription scriptingStatusDescription);
    }
}