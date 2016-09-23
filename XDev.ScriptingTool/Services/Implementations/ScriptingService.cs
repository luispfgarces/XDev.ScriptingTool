namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Observers;

    /// <summary>
    /// <see cref="ScriptingService"/>
    /// </summary>
    /// <seealso cref="IScriptingService"/>
    internal class ScriptingService : IScriptingService
    {
        /// <summary>
        /// The compiled script executor service
        /// </summary>
        private readonly ICompiledScriptExecutorService compiledScriptExecutorService;

        /// <summary>
        /// The observers
        /// </summary>
        private readonly IEnumerable<IScriptingStatusObserver> observers;

        /// <summary>
        /// The script compiler service
        /// </summary>
        private readonly IScriptCompilerService scriptCompilerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingService"/> class.
        /// </summary>
        /// <param name="compiledScriptExecutorService">The compiled script executor service.</param>
        /// <param name="scriptCompilerService">The script compiler service.</param>
        /// <param name="observers">The observers.</param>
        public ScriptingService(
            ICompiledScriptExecutorService compiledScriptExecutorService,
            IScriptCompilerService scriptCompilerService,
            IScriptingStatusObserver[] observers)
        {
            this.compiledScriptExecutorService = compiledScriptExecutorService;
            this.observers = observers;
            this.scriptCompilerService = scriptCompilerService;
        }

        /// <summary>
        /// Executes the scripts asynchronously.
        /// </summary>
        /// <param name="scriptFilesDiscoveryInfo">The script files discovery information.</param>
        /// <returns></returns>
        public async Task ExecuteScriptsAsync(IEnumerable<FileDiscoveryInfo> scriptFilesDiscoveryInfo)
        {
            List<CompiledScript> compiledScripts = new List<CompiledScript>(0);

            // Phase 1: Compile scripts.
            this.NotifyObservers(new ScriptingStatus
            {
                ScriptingStatusDescription = ScriptingStatusDescription.BeginAllScriptsCompile
            });

            foreach (FileDiscoveryInfo scriptFileDiscoveryInfo in scriptFilesDiscoveryInfo)
            {
                this.NotifyObservers(new ScriptingStatus
                {
                    AditionalData = scriptFileDiscoveryInfo,
                    ScriptingStatusDescription = ScriptingStatusDescription.BeginScriptCompile
                });

                ScriptCompileResult scriptCompileResult = await this.scriptCompilerService.CompileScriptAsync(scriptFileDiscoveryInfo);

                if (scriptCompileResult.CompilationSuccessful)
                {
                    CompiledScript compiledScript = scriptCompileResult.CompiledScript;
                    compiledScripts.Add(compiledScript);

                    this.NotifyObservers(new ScriptingStatus
                    {
                        AditionalData = scriptCompileResult,
                        ScriptingStatusDescription = ScriptingStatusDescription.SuccessScriptCompile
                    });
                }
                else
                {
                    this.NotifyObservers(new ScriptingStatus
                    {
                        AditionalData = scriptCompileResult,
                        ScriptingStatusDescription = ScriptingStatusDescription.FailScriptCompile
                    });
                }

                this.NotifyObservers(new ScriptingStatus
                {
                    AditionalData = scriptFileDiscoveryInfo,
                    ScriptingStatusDescription = ScriptingStatusDescription.FinalizeScriptCompile
                });
            }

            this.NotifyObservers(new ScriptingStatus
            {
                ScriptingStatusDescription = ScriptingStatusDescription.FinalizeAllScriptsCompile
            });

            // Phase 2: Execute compiled scripts.
            this.NotifyObservers(new ScriptingStatus
            {
                ScriptingStatusDescription = ScriptingStatusDescription.BeginAllScriptsExecute
            });

            foreach (CompiledScript compiledScript in compiledScripts)
            {
                await this.compiledScriptExecutorService.ExecuteCompiledScriptAsync(compiledScript)
                    .ConfigureAwait(false);
            }

            this.NotifyObservers(new ScriptingStatus
            {
                ScriptingStatusDescription = ScriptingStatusDescription.FinalizeAllScriptsExecute
            });
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        private void NotifyObservers(ScriptingStatus scriptingStatus)
        {
            foreach (IScriptingStatusObserver observer in this.observers)
            {
                observer.ReceiveMessage(this, scriptingStatus);
            }
        }
    }
}