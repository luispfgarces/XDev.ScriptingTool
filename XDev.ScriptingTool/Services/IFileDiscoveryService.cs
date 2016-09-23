namespace XDev.ScriptingTool.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Represents a interface contract for a file discovery service with the capability to explore
    /// directories and return information about the files found.
    /// </summary>
    public interface IFileDiscoveryService
    {
        /// <summary>
        /// Discovers the files on the given path.
        /// </summary>
        /// <param name="pathToDiscover">The path to discover.</param>
        /// <returns></returns>
        IEnumerable<FileDiscoveryInfo> DiscoverFiles(string pathToDiscover);
    }
}