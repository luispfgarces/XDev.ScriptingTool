namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="ScriptingStatusInterpretationStrategyFactory"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategyFactory"/>
    internal class ScriptingStatusInterpretationStrategyFactory : IScriptingStatusInterpretationStrategyFactory
    {
        /// <summary>
        /// Gets the strategy for the given scripting status description.
        /// </summary>
        /// <param name="scriptingStatusDescription">The scripting status description.</param>
        /// <returns></returns>
        public IScriptingStatusInterpretationStrategy GetStrategy(ScriptingStatusDescription scriptingStatusDescription)
        {
            switch (scriptingStatusDescription)
            {
                case ScriptingStatusDescription.BeginAllScriptsCompile:
                    return new BeginAllScriptsCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FinalizeAllScriptsCompile:
                    return new FinalizeAllScriptsCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.BeginScriptCompile:
                    return new BeginScriptCompileCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FinalizeScriptCompile:
                    return new FinalizeScriptCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.SuccessScriptCompile:
                    return new SuccessScriptCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FailScriptCompile:
                    return new FailScriptCompileScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.BeginAllScriptsExecute:
                    return new BeginAllScriptsExecuteScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FinalizeAllScriptsExecute:
                    return new FinalizeAllScriptsExecuteScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.BeginScriptExecute:
                    return new BeginScriptExecuteScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FinalizeScriptExecute:
                    return new FinalizeScriptExecuteScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.SuccessScriptExecute:
                    return new SuccessScriptExecuteScriptingStatusInterpretationStrategy();

                case ScriptingStatusDescription.FailScriptExecute:
                    return new FailScriptExecuteScriptingStatusInterpretationStrategy();

                default:
                    return new EmptyScriptingStatusInterpretationStrategy();
            }
        }
    }
}