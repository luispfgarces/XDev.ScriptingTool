namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.FSharp.Compiler;
    using Microsoft.FSharp.Compiler.SimpleSourceCodeServices;
    using Microsoft.FSharp.Core;
    using Models;

    /// <summary>
    /// Represents the implementation of a script compiler services that is able to compile F# scripts.
    /// </summary>
    /// <seealso cref="IScriptCompilerService"/>
    internal class FSharpScriptCompilerService : IScriptCompilerService
    {
        /// <summary>
        /// The assembly file extension
        /// </summary>
        private const string AssemblyFileExtension = ".dll";

        /// <summary>
        /// The f sharp compiler
        /// </summary>
        private const string FSharpCompiler = "fsc.exe";

        /// <summary>
        /// The script file extension
        /// </summary>
        private const string ScriptFileExtension = ".fsx";

        /// <summary>
        /// The simple source code services
        /// </summary>
        private readonly SimpleSourceCodeServices simpleSourceCodeServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="FSharpScriptCompilerService"/> class.
        /// </summary>
        /// <param name="simpleSourceCodeServices">The simple source code services.</param>
        public FSharpScriptCompilerService(SimpleSourceCodeServices simpleSourceCodeServices)
        {
            this.simpleSourceCodeServices = simpleSourceCodeServices;
        }

        /// <summary>
        /// Compiles the script asynchronously.
        /// </summary>
        /// <param name="scriptFileDiscoveryInfo">The script file discovery information.</param>
        /// <returns></returns>
        public async Task<ScriptCompileResult> CompileScriptAsync(FileDiscoveryInfo scriptFileDiscoveryInfo)
        {
            return await Task.Factory.StartNew(() =>
            {
                string scriptFullFileName = Path.ChangeExtension(scriptFileDiscoveryInfo.FullFileName, FSharpScriptCompilerService.ScriptFileExtension);
                string assemblyFullFileName = Path.ChangeExtension(scriptFileDiscoveryInfo.FullFileName, FSharpScriptCompilerService.AssemblyFileExtension);
                var fsharpOption = FSharpOption<Tuple<TextWriter, TextWriter>>.None;
                var result = simpleSourceCodeServices.CompileToDynamicAssembly(
                    new[] { FSharpScriptCompilerService.FSharpCompiler, "-o", assemblyFullFileName, "-a", scriptFullFileName },
                    fsharpOption);

                string fileName = Path.GetFileName(scriptFullFileName);
                ScriptCompileResult scriptCompileResult;
                if (result.Item2 == 1)
                {
                    // Has errors.
                    scriptCompileResult = new ScriptCompileResult(false, null);

                    foreach (FSharpErrorInfo fsharpErrorInfo in result.Item1)
                    {
                        scriptCompileResult.AddError(fsharpErrorInfo.Message);
                    }
                }
                else
                {
                    // Compilation Successful.
                    CompiledScript compiledScript = new CompiledScript
                    {
                        CompiledAssembly = result.Item3.Value,
                        FileDiscoveryInfo = scriptFileDiscoveryInfo
                    };

                    scriptCompileResult = new ScriptCompileResult(true, compiledScript);
                }

                return scriptCompileResult;
            }, TaskCreationOptions.LongRunning).ConfigureAwait(false);
        }
    }
}