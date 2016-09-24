namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// <see cref="ScriptLoaderService"/>
    /// </summary>
    /// <seealso cref="IScriptLoaderService"/>
    internal class ScriptLoaderService : IScriptLoaderService
    {
        /// <summary>
        /// Loads the script.
        /// </summary>
        /// <param name="scriptPath">The script path.</param>
        /// <returns></returns>
        public async Task<Script> LoadScript(string scriptPath)
        {
            string scriptContent;

            using (FileStream fileStream = File.Open(scriptPath, FileMode.Open))
            using (TextReader textReader = new StreamReader(fileStream))
            {
                scriptContent = await textReader.ReadToEndAsync();
            }

            string fileName = Path.GetFileName(scriptPath);

            return Script.Create(scriptPath, fileName, scriptContent);
        }
    }
}