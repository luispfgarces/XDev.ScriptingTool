namespace XDev.ScriptingTool.ConsolePresentation.Observers.ConsoleOutputs
{
    using System;
    using ConsolePresentation.ConsoleOutputs;
    using FileDiscoveryStatusInterpreters;
    using Models;
    using ScriptingStatusInterpreters;
    using ScriptingTool.Observers;

    /// <summary>
    /// <see cref="ConsoleOutputFileDiscoveryStatusObserver"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryStatusObserver"/>
    internal class ConsoleOutputFileDiscoveryStatusObserver : IFileDiscoveryStatusObserver
    {
        /// <summary>
        /// The console output
        /// </summary>
        private readonly IConsoleOutput consoleOutput;

        /// <summary>
        /// The file discovery status interpretation strategy factory
        /// </summary>
        private readonly IFileDiscoveryStatusInterpretationStrategyFactory fileDiscoveryStatusInterpretationStrategyFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutputFileDiscoveryStatusObserver"/> class.
        /// </summary>
        /// <param name="consoleOutput">The console output.</param>
        /// <param name="fileDiscoveryStatusInterpretationStrategyFactory">
        /// The file discovery status interpretation strategy factory.
        /// </param>
        public ConsoleOutputFileDiscoveryStatusObserver(
            IConsoleOutput consoleOutput,
            IFileDiscoveryStatusInterpretationStrategyFactory fileDiscoveryStatusInterpretationStrategyFactory)
        {
            this.consoleOutput = consoleOutput;
            this.fileDiscoveryStatusInterpretationStrategyFactory = fileDiscoveryStatusInterpretationStrategyFactory;
        }

        /// <summary>
        /// Receives the message.
        /// </summary>
        /// <param name="observedInstance">The observed instance.</param>
        /// <param name="message">The message.</param>
        public void ReceiveMessage(object observedInstance, FileDiscoveryStatus message)
        {
            IFileDiscoveryStatusInterpretationStrategy fileDiscoveryStatusInterpretationStrategy = this.fileDiscoveryStatusInterpretationStrategyFactory
                .GetStrategy(message.FileDiscoveryStatusDescription);

            Message interpretedMessage = fileDiscoveryStatusInterpretationStrategy.InterpretFileDiscoveryStatus(message);

            if (!string.IsNullOrEmpty(interpretedMessage.Text))
            {
                this.consoleOutput.WriteLine(interpretedMessage.Text, interpretedMessage.Color);
            }
        }
    }
}