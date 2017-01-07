namespace XDev.ScriptingTool.WpfPresentation.Views
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Forms;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <seealso cref="Window"/>
    /// <seealso cref="System.Windows.Markup.IComponentConnector"/>
    public partial class MainView : Window
    {
        /// <summary>
        /// The exit message
        /// </summary>
        private static readonly string ExitMessage = "Press any key to exit...";

        /// <summary>
        /// The console view
        /// </summary>
        private ConsoleView consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        /// <param name="scriptingController">The scripting controller.</param>
        public MainView(ScriptingToolViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;

            viewModel.BeginExecuteScripts += ViewModel_BeginExecuteScripts;
            viewModel.FinishExecuteScripts += ViewModel_FinishExecuteScripts;
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>The view model.</value>
        protected ScriptingToolViewModel ViewModel => this.DataContext as ScriptingToolViewModel;

        private void buttonPickPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ViewModel.SelectedPath = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the BeginExecuteScripts event of the ViewModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ViewModel_BeginExecuteScripts(object sender, EventArgs e)
        {
            this.consoleView = ConsoleView.New();
        }

        /// <summary>
        /// Handles the FinishExecuteScripts event of the ViewModel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ViewModel_FinishExecuteScripts(object sender, EventArgs e)
        {
            Console.WriteLine(MainView.ExitMessage);
            Console.ReadLine();

            this.consoleView.Dispose();
        }
    }
}