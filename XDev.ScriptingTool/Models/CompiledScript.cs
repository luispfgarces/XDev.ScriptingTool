namespace XDev.ScriptingTool.Models
{
    using System;
    using System.Reflection;

    /// <summary>
    /// <see cref="CompiledScript"/>
    /// </summary>
    public class CompiledScript
    {
        /// <summary>
        /// Gets or sets the compiled assembly.
        /// </summary>
        /// <value>The compiled assembly.</value>
        public Assembly CompiledAssembly { get; set; }

        /// <summary>
        /// Gets or sets the file discovery information.
        /// </summary>
        /// <value>The file discovery information.</value>
        public FileDiscoveryInfo FileDiscoveryInfo { get; set; }
    }
}