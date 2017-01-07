namespace XDev.ScriptingTool.WpfPresentation
{
    using System;
    using Controllers;
    using ViewModels;
    using Views;
    using XDev.ScriptingTool.DependencyInjection;

    internal class WpfBootstrapper
    {
        /// <summary>
        /// Gets the dependency injection container.
        /// </summary>
        /// <value>The dependency injection container.</value>
        public IDependencyInjectionContainer DependencyInjectionContainer { get; private set; }

        /// <summary>
        /// Bootstraps this instance.
        /// </summary>
        public void Bootstrap()
        {
            this.DependencyInjectionContainer = new UnityDependencyInjectionContainer();

            this.DependencyInjectionContainer.ConfigureScriptingTool();

            this.DependencyInjectionContainer.ConfigureConsoleOutputs();

            this.DependencyInjectionContainer.Register<IScriptingController, ScriptingController>();
            this.DependencyInjectionContainer.Register<ScriptingToolViewModel>();
            this.DependencyInjectionContainer.Register<MainView>();
        }
    }
}