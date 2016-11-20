namespace XDev.ScriptingTool.DependencyInjection
{
    using System;
    using ConsoleOutputs;
    using ConsoleOutputs.Observers;
    using ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters;
    using ConsoleOutputs.Observers.FileDiscoveryStatusInterpreters.Implementations;
    using ConsoleOutputs.Observers.ScriptingStatusInterpreters;
    using ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations;
    using Observers;

    /// <summary>
    /// <see cref="DependencyInjectionContainerConsoleOutputsExtensions"/>
    /// </summary>
    public static class DependencyInjectionContainerConsoleOutputsExtensions
    {
        /// <summary>
        /// Configures the console outputs.
        /// </summary>
        /// <param name="dependencyInjectionContainer">The dependency injection container.</param>
        public static void ConfigureConsoleOutputs(this IDependencyInjectionContainer dependencyInjectionContainer)
        {
            dependencyInjectionContainer.Register<IConsoleOutput, ConsoleOutput>();
            dependencyInjectionContainer.Register<IScriptingStatusInterpretationStrategyFactory, ScriptingStatusInterpretationStrategyFactory>();
            dependencyInjectionContainer.Register<IScriptingStatusObserver, ConsoleOutputScriptingStatusObserver>("a");
            dependencyInjectionContainer.Register<IFileDiscoveryStatusInterpretationStrategyFactory, FileDiscoveryStatusInterpretationStrategyFactory>();
            dependencyInjectionContainer.Register<IFileDiscoveryStatusObserver, ConsoleOutputFileDiscoveryStatusObserver>("a");
        }
    }
}