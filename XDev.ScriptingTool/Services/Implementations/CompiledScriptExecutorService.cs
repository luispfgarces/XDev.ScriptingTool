namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Attributes;
    using Models;
    using Observers;

    /// <summary>
    /// <see cref="CompiledScriptExecutorService"/>
    /// </summary>
    /// <seealso cref="ICompiledScriptExecutorService"/>
    internal class CompiledScriptExecutorService : ICompiledScriptExecutorService
    {
        /// <summary>
        /// The script class attribute type
        /// </summary>
        private static readonly Type ScriptClassAttributeType = typeof(ScriptClassAttribute);

        /// <summary>
        /// The script method attribute type
        /// </summary>
        private static readonly Type ScriptMethodAttributeType = typeof(ScriptMethodAttribute);

        /// <summary>
        /// The observers
        /// </summary>
        private readonly IEnumerable<IScriptingStatusObserver> observers;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompiledScriptExecutorService"/> class.
        /// </summary>
        /// <param name="observers">The observers.</param>
        public CompiledScriptExecutorService(IScriptingStatusObserver[] observers)
        {
            this.observers = observers;
        }

        /// <summary>
        /// Executes the compiled script asynchronously.
        /// </summary>
        /// <param name="compiledScriptAssembly">The compiled script assembly.</param>
        /// <returns></returns>
        public Task ExecuteCompiledScriptAsync(CompiledScript compiledScript)
        {
            IEnumerable<Type> scriptClasses = this.GetAllAssemblyScriptClasses(compiledScript.CompiledAssembly);

            foreach (Type scriptClass in scriptClasses)
            {
                this.ProcessAndExecuteScriptClass(compiledScript.FileDiscoveryInfo, scriptClass);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets all assembly script classes.
        /// </summary>
        /// <param name="compiledScriptAssembly">The compiled script assembly.</param>
        /// <returns></returns>
        private IEnumerable<Type> GetAllAssemblyScriptClasses(Assembly compiledScriptAssembly)
        {
            return compiledScriptAssembly.GetTypes()
                .Where(t => t.IsDefined(CompiledScriptExecutorService.ScriptClassAttributeType));
        }

        /// <summary>
        /// Gets all script class script methods.
        /// </summary>
        /// <param name="scriptClass">The script class.</param>
        /// <returns></returns>
        private IEnumerable<MethodInfo> GetAllScriptClassScriptMethods(Type scriptClass)
        {
            return scriptClass.GetMethods()
                .Where(t => t.IsDefined(CompiledScriptExecutorService.ScriptMethodAttributeType));
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

        /// <summary>
        /// Processes and executes all the script methods available on the script class.
        /// </summary>
        /// <param name="scriptClass">The script class.</param>
        private void ProcessAndExecuteScriptClass(FileDiscoveryInfo scriptFileDiscoveryInfo, Type scriptClass)
        {
            IEnumerable<MethodInfo> scriptMethods = this.GetAllScriptClassScriptMethods(scriptClass);

            object scriptClassInstance = Activator.CreateInstance(scriptClass);

            foreach (MethodInfo scriptMethod in scriptMethods)
            {
                ScriptExecuteInfo scriptExecuteInfo = new ScriptExecuteInfo(scriptFileDiscoveryInfo.FileName, scriptClass.Name, scriptMethod.Name);

                this.NotifyObservers(new ScriptingStatus
                {
                    AditionalData = scriptExecuteInfo.CreateCopy(),
                    ScriptingStatusDescription = ScriptingStatusDescription.BeginScriptExecute
                });

                try
                {
                    scriptMethod.Invoke(scriptClassInstance, null);

                    this.NotifyObservers(new ScriptingStatus
                    {
                        AditionalData = scriptMethod,
                        ScriptingStatusDescription = ScriptingStatusDescription.SuccessScriptExecute
                    });
                }
                catch (TargetInvocationException tie)
                {
                    ScriptExecuteInfo errorOnScriptScriptExecuteInfo = scriptExecuteInfo.CreateCopy();
                    errorOnScriptScriptExecuteInfo.ThrownException = tie.InnerException;

                    this.NotifyObservers(new ScriptingStatus
                    {
                        AditionalData = errorOnScriptScriptExecuteInfo,
                        ScriptingStatusDescription = ScriptingStatusDescription.FailScriptExecute
                    });
                }
                catch (Exception ex)
                {
                    ScriptExecuteInfo otherErrorScriptExecuteInfo = scriptExecuteInfo.CreateCopy();
                    otherErrorScriptExecuteInfo.ThrownException = ex;

                    this.NotifyObservers(new ScriptingStatus
                    {
                        AditionalData = otherErrorScriptExecuteInfo,
                        ScriptingStatusDescription = ScriptingStatusDescription.FailScriptExecute
                    });
                }

                this.NotifyObservers(new ScriptingStatus
                {
                    AditionalData = scriptExecuteInfo.CreateCopy(),
                    ScriptingStatusDescription = ScriptingStatusDescription.FinalizeScriptExecute
                });
            }
        }
    }
}