namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// Represents a script loaded in memory.
    /// </summary>
    public class Script
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Script"/> class.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Script(string fullPath, string fileName, string content)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentNullException(nameof(fullPath));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.FullPath = fullPath;
            this.FileName = fileName;
            this.Content = content;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <value>The full path.</value>
        public string FullPath { get; private set; }

        /// <summary>
        /// Creates the specified full path.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static Script Create(string fullPath, string fileName, string content)
        {
            return new Script(fullPath, fileName, content);
        }

        /// <summary>
        /// Gets the script execute information.
        /// </summary>
        /// <returns></returns>
        public ScriptExecuteInfo GetScriptExecuteInfo()
        {
            return new ScriptExecuteInfo(this.FileName);
        }
    }
}