namespace XDev.ScriptingTool.DependencyInjection
{
    using System;
    using Microsoft.FSharp.Compiler.SimpleSourceCodeServices;
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
            dependencyInjectionContainer.Register<ICompiledScriptExecutorService, CompiledScriptExecutorService>();
            dependencyInjectionContainer.Register<IFileDiscoveryService, FileDiscoveryService>(new { fileSearchPattern = "*.fsx" });
            dependencyInjectionContainer.Register<SimpleSourceCodeServices>();
            dependencyInjectionContainer.Register<IScriptCompilerService, FSharpScriptCompilerService>();
            dependencyInjectionContainer.Register<IScriptingService, ScriptingService>();
        }
    }
}