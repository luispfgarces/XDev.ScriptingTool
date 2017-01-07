namespace XDev.ScriptingTool.WpfPresentation.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Commander;
    using Models;
    using PropertyChanged;
    using Services;

    /// <summary>
    /// <see cref="ScriptingToolViewModel"/>
    /// </summary>
    [ImplementPropertyChanged]
    public class ScriptingToolViewModel : INotifyPropertyChanged
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

            this.FoundScripts = new BindingList<ScriptViewModel>();
        }

        /// <summary>
        /// Occurs when [begin execute scripts].
        /// </summary>
        public event EventHandler BeginExecuteScripts;

        /// <summary>
        /// Occurs when [finish execute scripts].
        /// </summary>
        public event EventHandler FinishExecuteScripts;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether [any scripts selected for execution].
        /// </summary>
        /// <value><c>true</c> if [any scripts selected for execution]; otherwise, <c>false</c>.</value>
        public bool AnyScriptsSelectedForExecution => this.FoundScripts?.Any(s => s.Execute) ?? false;

        /// <summary>
        /// Gets or sets the found scripts.
        /// </summary>
        /// <value>The found scripts.</value>
        public BindingList<ScriptViewModel> FoundScripts { get; set; }

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>The selected path.</value>
        public string SelectedPath { get; set; }

        /// <summary>
        /// Executes the scripts asynchronous.
        /// </summary>
        [OnCommand("ExecuteScriptsCommand")]
        private void ExecuteScriptsAsync()
        {
            this.BeginExecuteScripts?.Invoke(this, new EventArgs());
            Task.Run(async () =>
            {
                IEnumerable<FileDiscoveryInfo> scriptsToExecute = this.FoundScripts.Where(s => s.Execute).Select(s => new FileDiscoveryInfo
                {
                    FileName = s.FileName,
                    FullFileName = s.ScriptFilePath
                });

                foreach (var script in scriptsToExecute)
                {
                    await this.scriptingService.ExecuteScriptAsync(script)
                        .ConfigureAwait(false);
                }
            }).ConfigureAwait(false).GetAwaiter().GetResult();
            this.FinishExecuteScripts?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Searches the scripts.
        /// </summary>
        [OnCommand("SearchScriptsCommand")]
        private void SearchScripts()
        {
            IEnumerable<FileDiscoveryInfo> discoveredFiles = this.fileDiscoveryService.DiscoverFiles(this.SelectedPath);

            var discoveredFilesViewModels = discoveredFiles.Select(fdi => new ScriptViewModel
            {
                Execute = true,
                FileName = fdi.FileName,
                ScriptFilePath = fdi.FullFileName
            }).ToList();

            this.FoundScripts = new BindingList<ScriptViewModel>(discoveredFilesViewModels);
            this.FoundScripts.ListChanged += (s, e) =>
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.AnyScriptsSelectedForExecution)));
            };
        }
    }
}