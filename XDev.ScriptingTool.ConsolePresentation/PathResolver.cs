namespace XDev.ScriptingTool.ConsolePresentation
{
    using System;
    using System.IO;

    /// <summary>
    /// <see cref="PathResolver"/>
    /// </summary>
    internal class PathResolver
    {
        /// <summary>
        /// Resolves the path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}