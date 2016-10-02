namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// <see cref="FileDiscoveryStatusDescription"/>
    /// </summary>
    public enum FileDiscoveryStatusDescription
    {
        /// <summary>
        /// The begin file discovery
        /// </summary>
        BeginFileDiscovery = 1,

        /// <summary>
        /// The finalize file discovery
        /// </summary>
        FinalizeFileDiscovery = 2,

        /// <summary>
        /// The found file
        /// </summary>
        FoundFile = 3
    }
}