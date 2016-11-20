namespace XDev.ScriptingTool.WpfPresentation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Services;

    /// <summary>
    /// <see cref="ScriptingController"/>
    /// </summary>
    internal class ScriptingController : IScriptingController
    {
        /// <summary>
        /// The file discovery service
        /// </summary>
        private readonly IFileDiscoveryService fileDiscoveryService;

        /// <summary>
        /// The scripting service
        /// </summary>
        private readonly IScriptingService scriptingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingController"/> class.
        /// </summary>
        /// <param name="fileDiscoveryService">The file discovery service.</param>
        public ScriptingController(IFileDiscoveryService fileDiscoveryService, IScriptingService scriptingService)
        {
            this.fileDiscoveryService = fileDiscoveryService;
            this.scriptingService = scriptingService;
        }

        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public IEnumerable<FileDiscoveryInfo> DiscoverFiles(string path)
        {
            return this.fileDiscoveryService.DiscoverFiles(path);
        }

        /// <summary>
        /// Executes the scripts.
        /// </summary>
        /// <param name="scriptsToExecute">The scripts to execute.</param>
        public async Task ExecuteScriptsAsync(IEnumerable<FileDiscoveryInfo> scriptsToExecute)
        {
            foreach (var script in scriptsToExecute)
            {
                await this.scriptingService.ExecuteScriptAsync(script);
            }
        }
    }
}