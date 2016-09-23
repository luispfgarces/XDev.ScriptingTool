namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    /// <summary>
    /// <see cref="FileDiscoveryService"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryService"/>
    internal class FileDiscoveryService : IFileDiscoveryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileDiscoveryService"/> class.
        /// </summary>
        /// <param name="fileSearchPattern">The file search pattern.</param>
        public FileDiscoveryService(string fileSearchPattern)
        {
            this.FileSearchPattern = fileSearchPattern;
        }

        /// <summary>
        /// Gets the file search pattern.
        /// </summary>
        /// <value>The file search pattern.</value>
        protected string FileSearchPattern { get; private set; }

        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="pathToDiscover">The path to discover.</param>
        /// <returns></returns>
        public IEnumerable<FileDiscoveryInfo> DiscoverFiles(string pathToDiscover)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToDiscover);
            return this.DiscoverFiles(directory);
        }

        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns></returns>
        private IEnumerable<FileDiscoveryInfo> DiscoverFiles(DirectoryInfo directoryInfo)
        {
            IEnumerable<FileDiscoveryInfo> fileDiscoveryInfos = new List<FileDiscoveryInfo>(0);
            IEnumerable<DirectoryInfo> subdirectories = directoryInfo.EnumerateDirectories();

            // Invoke discovery on subdirectories.
            foreach (var subdirectory in subdirectories)
            {
                IEnumerable<FileDiscoveryInfo> subdirectoryFileDiscoveryInfos = this.DiscoverFiles(subdirectory);
                fileDiscoveryInfos = fileDiscoveryInfos.Concat(subdirectoryFileDiscoveryInfos);
            }

            IEnumerable<FileInfo> files = directoryInfo.EnumerateFiles(this.FileSearchPattern);
            List<FileDiscoveryInfo> currentFileDiscoveryInfos = new List<FileDiscoveryInfo>(0);

            // Discover files.
            foreach (var file in files)
            {
                var fileDiscoveryInfo = new FileDiscoveryInfo
                {
                    FullFileName = file.FullName,
                    FileName = file.Name
                };
                currentFileDiscoveryInfos.Add(fileDiscoveryInfo);
            }

            // Concat file paths to return if any.
            if (currentFileDiscoveryInfos.Any())
            {
                fileDiscoveryInfos = fileDiscoveryInfos.Concat(currentFileDiscoveryInfos);
            }

            return fileDiscoveryInfos;
        }
    }
}