namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// <see cref="ScriptingStatus"/>
    /// </summary>
    public class ScriptingStatus
    {
        /// <summary>
        /// Gets or sets the aditional data.
        /// </summary>
        /// <value>The aditional data.</value>
        public object AditionalData { get; set; }

        /// <summary>
        /// Gets or sets the scripting status description.
        /// </summary>
        /// <value>The scripting status description.</value>
        public ScriptingStatusDescription ScriptingStatusDescription { get; set; }
    }
}