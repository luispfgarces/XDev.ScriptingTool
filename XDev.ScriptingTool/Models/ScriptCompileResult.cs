namespace XDev.ScriptingTool.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// <see cref="ScriptCompileResult"/>
    /// </summary>
    public class ScriptCompileResult
    {
        /// <summary>
        /// The errors
        /// </summary>
        private readonly List<string> errors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptCompileResult"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="compilationSuccessful">if set to <c>true</c> [compilation successful].</param>
        /// <param name="compiledScript">The compiled script.</param>
        public ScriptCompileResult(bool compilationSuccessful, CompiledScript compiledScript)
        {
            this.CompilationSuccessful = compilationSuccessful;
            this.CompiledScript = compiledScript;
            this.errors = new List<string>(0);
        }

        /// <summary>
        /// Gets a value indicating whether compilation was successful.
        /// </summary>
        /// <value><c>true</c> if compilation was successful; otherwise, <c>false</c>.</value>
        public bool CompilationSuccessful { get; private set; }

        /// <summary>
        /// Gets the compiled script.
        /// </summary>
        /// <value>The compiled script.</value>
        public CompiledScript CompiledScript { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public IEnumerable<string> Errors => this.errors;

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void AddError(string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                throw new ArgumentNullException(nameof(error));
            }

            this.errors.Add(error);
        }
    }
}