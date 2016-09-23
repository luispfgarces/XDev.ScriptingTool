namespace XDev.ScriptingTool.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents the interface contract for a scripting service.
    /// </summary>
    public interface IScriptingService
    {
        /// <summary>
        /// Executes the scripts asynchronously.
        /// </summary>
        /// <param name="scriptFilesDiscoveryInfo">The script files discovery information.</param>
        /// <returns></returns>
        Task ExecuteScriptsAsync(IEnumerable<FileDiscoveryInfo> scriptFilesDiscoveryInfo);
    }
}