namespace XDev.ScriptingTool.WpfPresentation.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// <see cref="IScriptingController"/>
    /// </summary>
    public interface IScriptingController
    {
        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        IEnumerable<FileDiscoveryInfo> DiscoverFiles(string path);

        /// <summary>
        /// Executes the scripts.
        /// </summary>
        /// <param name="scriptsToExecute">The scripts to execute.</param>
        Task ExecuteScriptsAsync(IEnumerable<FileDiscoveryInfo> scriptsToExecute);
    }
}