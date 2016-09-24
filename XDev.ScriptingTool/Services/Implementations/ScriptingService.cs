namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Models;
    using Observers;

    /// <summary>
    /// <see cref="ScriptingService"/>
    /// </summary>
    /// <seealso cref="IScriptingService"/>
    internal class ScriptingService : IScriptingService
    {
        /// <summary>
        /// The observers
        /// </summary>
        private readonly IEnumerable<IScriptingStatusObserver> observers;

        /// <summary>
        /// The script loader service
        /// </summary>
        private readonly IScriptLoaderService scriptLoaderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingService"/> class.
        /// </summary>
        /// <param name="scriptLoaderService">The script loader service.</param>
        /// <param name="observers">The observers.</param>
        public ScriptingService(
            IScriptLoaderService scriptLoaderService,
            IScriptingStatusObserver[] observers)
        {
            this.observers = observers;
            this.scriptLoaderService = scriptLoaderService;
        }

        /// <summary>
        /// Executes the scripts asynchronously.
        /// </summary>
        /// <param name="scriptFileDiscoveryInfo">The script files discovery information.</param>
        /// <returns></returns>
        public async Task ExecuteScriptAsync(FileDiscoveryInfo scriptFileDiscoveryInfo)
        {
            Script script = await this.scriptLoaderService.LoadScript(scriptFileDiscoveryInfo.FullFileName).ConfigureAwait(false);

            this.NotifyObservers(ScriptingStatusDescription.BeginScriptExecute, script.GetScriptExecuteInfo());

            try
            {
                await CSharpScript.EvaluateAsync(script.Content).ConfigureAwait(false);
                this.NotifyObservers(ScriptingStatusDescription.SuccessScriptExecute, script.GetScriptExecuteInfo());
            }
            catch (Exception ex)
            {
                ScriptExecuteInfo otherErrorScriptExecuteInfo = script.GetScriptExecuteInfo();
                otherErrorScriptExecuteInfo.ThrownException = ex;

                this.NotifyObservers(ScriptingStatusDescription.FailScriptExecute, otherErrorScriptExecuteInfo);
            }

            this.NotifyObservers(ScriptingStatusDescription.FinalizeScriptExecute, script.GetScriptExecuteInfo());
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <param name="scriptingStatusDescription">The scripting status description.</param>
        private void NotifyObservers(ScriptingStatusDescription scriptingStatusDescription)
        {
            this.NotifyObservers(scriptingStatusDescription, null);
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <param name="scriptingStatusDescription">The scripting status description.</param>
        /// <param name="aditionalData">The aditional data.</param>
        private void NotifyObservers(ScriptingStatusDescription scriptingStatusDescription, object aditionalData)
        {
            ScriptingStatus scriptingStatus = new ScriptingStatus
            {
                AditionalData = aditionalData,
                ScriptingStatusDescription = scriptingStatusDescription
            };

            foreach (IScriptingStatusObserver observer in this.observers)
            {
                observer.ReceiveMessage(this, scriptingStatus);
            }
        }
    }
}