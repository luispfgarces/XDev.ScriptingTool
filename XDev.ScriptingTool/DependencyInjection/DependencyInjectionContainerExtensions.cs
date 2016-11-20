namespace XDev.ScriptingTool.DependencyInjection
{
    using System;
    using System.Linq;
    using Observers;
    using Services;
    using Services.Implementations;

    /// <summary>
    /// <see cref="DependencyInjectionContainerExtensions"/>
    /// </summary>
    public static class DependencyInjectionContainerExtensions
    {
        /// <summary>
        /// Configures the scripting tool.
        /// </summary>
        /// <param name="dependencyInjectionContainer">The dependency injection container.</param>
        public static void ConfigureScriptingTool(this IDependencyInjectionContainer dependencyInjectionContainer)
        {
            dependencyInjectionContainer.Register<IFileDiscoveryService, FileDiscoveryService>((dic) => new FileDiscoveryService("*.csx", dic.ResolveAll<IFileDiscoveryStatusObserver>().ToArray()));
            dependencyInjectionContainer.Register<IScriptLoaderService, ScriptLoaderService>();
            dependencyInjectionContainer.Register<IScriptingService, ScriptingService>();
        }
    }
}