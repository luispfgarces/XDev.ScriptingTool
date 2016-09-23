namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// <see cref="ScriptExecuteInfo"/>
    /// </summary>
    public class ScriptExecuteInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptExecuteInfo"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="scriptClass">The script class.</param>
        /// <param name="scriptMethod">The script method.</param>
        public ScriptExecuteInfo(string fileName, string scriptClass, string scriptMethod)
        {
            this.FileName = fileName;
            this.ScriptClass = scriptClass;
            this.ScriptMethod = scriptMethod;
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the script class.
        /// </summary>
        /// <value>The script class.</value>
        public string ScriptClass { get; private set; }

        /// <summary>
        /// Gets the script method.
        /// </summary>
        /// <value>The script method.</value>
        public string ScriptMethod { get; private set; }

        /// <summary>
        /// Gets the thrown exception.
        /// </summary>
        /// <value>The thrown exception.</value>
        public Exception ThrownException { get; internal set; }

        /// <summary>
        /// Creates a copy.
        /// </summary>
        /// <returns></returns>
        public ScriptExecuteInfo CreateCopy()
        {
            return new ScriptExecuteInfo(this.FileName, this.ScriptClass, this.ScriptMethod);
        }
    }
}