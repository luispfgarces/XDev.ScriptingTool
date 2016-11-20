namespace XDev.ScriptingTool.WpfPresentation
{
    using System.Windows;
    using DependencyInjection;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The dependency injection container
        /// </summary>
        private readonly IDependencyInjectionContainer dependencyInjectionContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            WpfBootstrapper wpfBootstrapper = new WpfBootstrapper();
            wpfBootstrapper.Bootstrap();

            this.dependencyInjectionContainer = wpfBootstrapper.DependencyInjectionContainer;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            this.MainWindow = this.dependencyInjectionContainer.Resolve<MainWindow>();
            this.MainWindow.Show();
        }
    }
}