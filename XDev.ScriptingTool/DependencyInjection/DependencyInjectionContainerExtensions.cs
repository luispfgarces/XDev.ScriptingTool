namespace XDev.ScriptingTool.DependencyInjection
{
    using System;
    using Services;
    using Services.Implementations;

    /// <summary>
    /// <see cref="DependencyInjectionContainerExtensions"/>
    /// </summary>
    public static class DependencyInjectionContainerExtensions
    {
        /// <summary>
        /// Configures the windows system customizations dependency injection.
        /// </summary>
        /// <param name="dependencyInjectionContainer">The dependency injection container.</param>
        public static void ConfigureWindowsSystemCustomizations(this IDependencyInjectionContainer dependencyInjectionContainer)
        {
            dependencyInjectionContainer.Register<IFileDiscoveryService, FileDiscoveryService>(new { fileSearchPattern = "*.csx" });
            dependencyInjectionContainer.Register<IScriptLoaderService, ScriptLoaderService>();
            dependencyInjectionContainer.Register<IScriptingService, ScriptingService>();
        }
    }
}