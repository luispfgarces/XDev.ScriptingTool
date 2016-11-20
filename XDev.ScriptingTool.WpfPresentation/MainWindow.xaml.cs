namespace XDev.ScriptingTool.WpfPresentation
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
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The exit message
        /// </summary>
        private static readonly string ExitMessage = "Press any key to exit...";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="scriptingController">The scripting controller.</param>
        public MainWindow(ScriptingToolViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>The view model.</value>
        protected ScriptingToolViewModel ViewModel => this.DataContext as ScriptingToolViewModel;

        private void buttonExecute_Click(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel.FoundScripts.Any(s => s.Execute))
            {
                this.Dispatcher.Invoke(async () =>
                {
                    using (ConsoleWindow.New())
                    {
                        await this.ViewModel.ExecuteScriptsAsync();

                        Console.WriteLine(MainWindow.ExitMessage);
                        Console.ReadLine();
                    }
                });
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(
                    "No scripts were selected to execute.",
                    "No scripts selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void buttonPickPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.ViewModel.SelectedPath = folderBrowserDialog.SelectedPath;
            }
        }
    }
}