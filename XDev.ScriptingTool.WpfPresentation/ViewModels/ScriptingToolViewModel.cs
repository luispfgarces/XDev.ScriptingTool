namespace XDev.ScriptingTool.WpfPresentation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Models;
    using PostSharp.Patterns.Model;
    using Services;

    /// <summary>
    /// <see cref="ScriptingToolViewModel"/>
    /// </summary>
    [NotifyPropertyChanged]
    public class ScriptingToolViewModel
    {
        /// <summary>
        /// The file discovery service
        /// </summary>
        private readonly IFileDiscoveryService fileDiscoveryService;

        /// <summary>
        /// The scripting service
        /// </summary>
        private readonly IScriptingService scriptingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingToolViewModel"/> class.
        /// </summary>
        public ScriptingToolViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptingToolViewModel"/> class.
        /// </summary>
        /// <param name="fileDiscoveryService">The file discovery service.</param>
        /// <param name="scriptingService">The scripting service.</param>
        public ScriptingToolViewModel(IFileDiscoveryService fileDiscoveryService, IScriptingService scriptingService)
        {
            this.fileDiscoveryService = fileDiscoveryService;
            this.scriptingService = scriptingService;

            this.FoundScripts = new ObservableCollection<ScriptViewModel>();
        }

        /// <summary>
        /// Gets or sets the found scripts.
        /// </summary>
        /// <value>The found scripts.</value>
        public IEnumerable<ScriptViewModel> FoundScripts { get; set; }

        /// <summary>
        /// Gets the search scripts command.
        /// </summary>
        /// <value>The search scripts command.</value>
        [IgnoreAutoChangeNotification]
        public ICommand SearchScriptsCommand => new DelegateCommand<object>((o) => this.SearchScripts());

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>The selected path.</value>
        public string SelectedPath { get; set; }

        /// <summary>
        /// Executes the scripts asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteScriptsAsync()
        {
            IEnumerable<FileDiscoveryInfo> scriptsToExecute = this.FoundScripts.Where(s => s.Execute).Select(s => new FileDiscoveryInfo
            {
                FileName = s.FileName,
                FullFileName = s.ScriptFilePath
            });

            foreach (var script in scriptsToExecute)
            {
                await this.scriptingService.ExecuteScriptAsync(script);
            }
        }

        /// <summary>
        /// Searches the scripts.
        /// </summary>
        private void SearchScripts()
        {
            IEnumerable<FileDiscoveryInfo> discoveredFiles = this.fileDiscoveryService.DiscoverFiles(this.SelectedPath);

            var discoveredFilesViewModels = discoveredFiles.Select(fdi => new ScriptViewModel
            {
                Execute = true,
                FileName = fdi.FileName,
                ScriptFilePath = fdi.FullFileName
            });

            this.FoundScripts = new ObservableCollection<ScriptViewModel>(discoveredFilesViewModels);
        }
    }
}