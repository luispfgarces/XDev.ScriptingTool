namespace XDev.ScriptingTool.ConsolePresentation
{
    using System;
    using System.IO;
    using ConsoleOutputs;
    using DependencyInjection;
    using Observers.ConsoleOutputs;
    using Observers.ConsoleOutputs.FileDiscoveryStatusInterpreters;
    using Observers.ConsoleOutputs.FileDiscoveryStatusInterpreters.Implementations;
    using Observers.ConsoleOutputs.ScriptingStatusInterpreters;
    using Observers.ConsoleOutputs.ScriptingStatusInterpreters.Implementations;
    using ScriptingTool.Observers;

    /// <summary>
    /// <see cref="ConsoleBootrapper"/>
    /// </summary>
    internal class ConsoleBootrapper
    {
        /// <summary>
        /// Gets the dependency injection container.
        /// </summary>
        /// <value>The dependency injection container.</value>
        public IDependencyInjectionContainer DependencyInjectionContainer { get; private set; }

        /// <summary>
        /// Bootstraps the console application.
        /// </summary>
        public void Bootstrap()
        {
            this.DependencyInjectionContainer = new UnityDependencyInjectionContainer();

            this.DependencyInjectionContainer.ConfigureWindowsSystemCustomizations();

            this.DependencyInjectionContainer.Register<TextWriter>((dic) => Console.Out);
            this.DependencyInjectionContainer.Register<IConsoleOutput, ConsoleOutput>();
            this.DependencyInjectionContainer.Register<IScriptingStatusInterpretationStrategyFactory, ScriptingStatusInterpretationStrategyFactory>();
            this.DependencyInjectionContainer.Register<IScriptingStatusObserver, ConsoleOutputScriptingStatusObserver>("a");
            this.DependencyInjectionContainer.Register<IFileDiscoveryStatusInterpretationStrategyFactory, FileDiscoveryStatusInterpretationStrategyFactory>();
            this.DependencyInjectionContainer.Register<IFileDiscoveryStatusObserver, ConsoleOutputFileDiscoveryStatusObserver>("a");
        }
    }
}