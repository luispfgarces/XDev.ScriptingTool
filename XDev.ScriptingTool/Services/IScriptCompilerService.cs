namespace XDev.ScriptingTool.Services
{
    using System;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents the interface contract for a script compiler service.
    /// </summary>
    internal interface IScriptCompilerService
    {
        /// <summary>
        /// Compiles the script asynchronously.
        /// </summary>
        /// <param name="scriptFileDiscoveryInfo">The script file discovery information.</param>
        /// <returns></returns>
        Task<ScriptCompileResult> CompileScriptAsync(FileDiscoveryInfo scriptFileDiscoveryInfo);
    }
}