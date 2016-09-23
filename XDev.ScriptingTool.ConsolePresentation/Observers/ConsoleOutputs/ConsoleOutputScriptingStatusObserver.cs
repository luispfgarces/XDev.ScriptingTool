namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using Models;
    using ScriptingStatusInterpreters;
    using ScriptingTool.Observers;

    /// <summary>
    /// <see cref="ConsoleOutputScriptingStatusObserver"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusObserver"/>
    internal class ConsoleOutputScriptingStatusObserver : IScriptingStatusObserver
    {
        /// <summary>
        /// The console output
        /// </summary>
        private readonly IConsoleOutput consoleOutput;

        /// <summary>
        /// The scripting status interpretation strategy factory
        /// </summary>
        private readonly IScriptingStatusInterpretationStrategyFactory scriptingStatusInterpretationStrategyFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutputScriptingStatusObserver"/> class.
        /// </summary>
        /// <param name="consoleOutput">The console output.</param>
        /// <param name="scriptingStatusInterpretationStrategyFactory">
        /// The scripting status interpretation strategy factory.
        /// </param>
        public ConsoleOutputScriptingStatusObserver(
            IConsoleOutput consoleOutput,
            IScriptingStatusInterpretationStrategyFactory scriptingStatusInterpretationStrategyFactory)
        {
            this.consoleOutput = consoleOutput;
            this.scriptingStatusInterpretationStrategyFactory = scriptingStatusInterpretationStrategyFactory;
        }

        /// <summary>
        /// Receives a message from a observed instance.
        /// </summary>
        /// <param name="observedInstance">The observed instance.</param>
        /// <param name="message">The message.</param>
        public void ReceiveMessage(object observedInstance, ScriptingStatus message)
        {
            IScriptingStatusInterpretationStrategy scriptingStatusInterpretationStrategy = this.scriptingStatusInterpretationStrategyFactory
                .GetStrategy(message.ScriptingStatusDescription);

            Message interpretedMessage = scriptingStatusInterpretationStrategy.InterpretScriptingStatus(message);

            if (!string.IsNullOrEmpty(interpretedMessage.Text))
            {
                this.consoleOutput.WriteLine(interpretedMessage.Text, interpretedMessage.Color);
            }
        }
    }
}