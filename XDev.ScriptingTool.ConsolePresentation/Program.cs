namespace XDev.ScriptingTool.ConsolePresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DependencyInjection;
    using Models;
    using Services;

    internal class Program
    {
        /// <summary>
        /// Executes the program with the specified path parameter.
        /// </summary>
        /// <param name="pathParam">The path parameter.</param>
        private static void Execute(string pathParam)
        {
            if (pathParam == null)
            {
                Console.WriteLine(Consts.UsageMessage);
                return;
            }

            string[] pathParamSplit = pathParam.Split(Consts.ParamValueSeparator);

            if (pathParam == null || pathParamSplit.Length != 2)
            {
                Console.WriteLine(Consts.UsageMessage);
                return;
            }

            if (!string.Equals(pathParamSplit[0], Consts.PathParamName, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine(Consts.UsageMessage);
                return;
            }

            ConsoleBootrapper consoleBootstrapper = new ConsoleBootrapper();
            consoleBootstrapper.Bootstrap();

            IDependencyInjectionContainer dependencyInjectionContainer = consoleBootstrapper.DependencyInjectionContainer;

            string specifiedPath = pathParamSplit[1];
            PathResolver pathResolver = new PathResolver();
            string resolvedPath = pathResolver.ResolvePath(specifiedPath);

            IFileDiscoveryService filePathDiscoveryService = dependencyInjectionContainer.Resolve<IFileDiscoveryService>();
            IEnumerable<FileDiscoveryInfo> scriptFiles = filePathDiscoveryService.DiscoverFiles(resolvedPath);

            IScriptingService scriptingService = dependencyInjectionContainer.Resolve<IScriptingService>();
            scriptingService.ExecuteScriptsAsync(scriptFiles).Wait();
        }

        /// <summary>
        /// Main (entry point).
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine(Consts.StartMessage);
            Console.WriteLine();
            string pathToDiscover = args.FirstOrDefault();
            Program.Execute(pathToDiscover);
            Console.WriteLine(Consts.ExitMessage);
            Console.ReadLine();
        }
    }
}