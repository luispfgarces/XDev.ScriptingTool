namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// <see cref="FileDiscoveryStatus"/>
    /// </summary>
    public class FileDiscoveryStatus
    {
        /// <summary>
        /// Gets or sets the aditional data.
        /// </summary>
        /// <value>The aditional data.</value>
        public object AditionalData { get; set; }

        /// <summary>
        /// Gets or sets the file discovery status description.
        /// </summary>
        /// <value>The file discovery status description.</value>
        public FileDiscoveryStatusDescription FileDiscoveryStatusDescription { get; set; }
    }
}