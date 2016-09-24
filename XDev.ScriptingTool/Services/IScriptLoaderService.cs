namespace XDev.ScriptingTool.Services
{
    using System;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents a interface contract for a script loader service.
    /// </summary>
    internal interface IScriptLoaderService
    {
        /// <summary>
        /// Loads the script.
        /// </summary>
        /// <param name="scriptPath">The script path.</param>
        /// <returns></returns>
        Task<Script> LoadScript(string scriptPath);
    }
}