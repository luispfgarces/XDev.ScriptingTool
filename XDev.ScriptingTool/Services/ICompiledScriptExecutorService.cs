namespace XDev.ScriptingTool.Services
{
    using System;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents a interface contract for compiled script executor service.
    /// </summary>
    internal interface ICompiledScriptExecutorService
    {
        /// <summary>
        /// Executes the compiled script asynchronously.
        /// </summary>
        /// <param name="compiledScript">The compiled script.</param>
        /// <returns></returns>
        Task ExecuteCompiledScriptAsync(CompiledScript compiledScript);
    }
}