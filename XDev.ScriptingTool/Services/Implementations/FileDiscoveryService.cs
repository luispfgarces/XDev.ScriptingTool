namespace XDev.ScriptingTool.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;
    using Observers;

    /// <summary>
    /// <see cref="FileDiscoveryService"/>
    /// </summary>
    /// <seealso cref="IFileDiscoveryService"/>
    internal class FileDiscoveryService : IFileDiscoveryService
    {
        /// <summary>
        /// The file search pattern
        /// </summary>
        private readonly string fileSearchPattern;

        /// <summary>
        /// The observers
        /// </summary>
        private readonly IEnumerable<IFileDiscoveryStatusObserver> observers;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDiscoveryService"/> class.
        /// </summary>
        /// <param name="fileSearchPattern">The file search pattern.</param>
        /// <param name="observers">The observers.</param>
        public FileDiscoveryService(
            string fileSearchPattern,
            IFileDiscoveryStatusObserver[] observers)
        {
            this.fileSearchPattern = fileSearchPattern;
            this.observers = observers;
        }

        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="pathToDiscover">The path to discover.</param>
        /// <returns></returns>
        public IEnumerable<FileDiscoveryInfo> DiscoverFiles(string pathToDiscover)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToDiscover);

            this.NotifyObservers(FileDiscoveryStatusDescription.BeginFileDiscovery);
            IEnumerable<FileDiscoveryInfo> results = this.DiscoverFiles(directory);
            this.NotifyObservers(FileDiscoveryStatusDescription.FinalizeFileDiscovery);

            return results;
        }

        /// <summary>
        /// Discovers the files.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <returns></returns>
        private IEnumerable<FileDiscoveryInfo> DiscoverFiles(DirectoryInfo directoryInfo)
        {
            IEnumerable<FileDiscoveryInfo> fileDiscoveryInfos = new List<FileDiscoveryInfo>(0);
            IEnumerable<FileInfo> files = directoryInfo.EnumerateFiles(this.fileSearchPattern);
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

                this.NotifyObservers(FileDiscoveryStatusDescription.FoundFile, fileDiscoveryInfo);
            }

            // Concat file paths to return if any.
            if (currentFileDiscoveryInfos.Any())
            {
                fileDiscoveryInfos = fileDiscoveryInfos.Concat(currentFileDiscoveryInfos);
            }

            IEnumerable<DirectoryInfo> subdirectories = directoryInfo.EnumerateDirectories();

            // Invoke discovery on subdirectories.
            foreach (var subdirectory in subdirectories)
            {
                IEnumerable<FileDiscoveryInfo> subdirectoryFileDiscoveryInfos = this.DiscoverFiles(subdirectory);
                fileDiscoveryInfos = fileDiscoveryInfos.Concat(subdirectoryFileDiscoveryInfos);
            }

            return fileDiscoveryInfos;
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <param name="fileDiscoveryStatusDescription">The file discovery status description.</param>
        private void NotifyObservers(FileDiscoveryStatusDescription fileDiscoveryStatusDescription)
        {
            this.NotifyObservers(fileDiscoveryStatusDescription, null);
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        /// <param name="fileDiscoveryStatusDescription">The file discovery status description.</param>
        /// <param name="aditionalData">The aditional data.</param>
        private void NotifyObservers(FileDiscoveryStatusDescription fileDiscoveryStatusDescription, object aditionalData)
        {
            FileDiscoveryStatus fileDiscoveryStatus = new FileDiscoveryStatus
            {
                AditionalData = aditionalData,
                FileDiscoveryStatusDescription = fileDiscoveryStatusDescription
            };

            foreach (IFileDiscoveryStatusObserver observer in this.observers)
            {
                observer.ReceiveMessage(this, fileDiscoveryStatus);
            }
        }
    }
}