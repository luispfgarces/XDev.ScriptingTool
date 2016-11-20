namespace XDev.ScriptingTool.WpfPresentation.ViewModels
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// <see cref="DelegateCommandTemplate{TParam, TExecuteDelegate, TEvaluateDelegate}"/>
    /// </summary>
    /// <typeparam name="TParam">The type of the parameter.</typeparam>
    /// <typeparam name="TExecuteDelegate">The type of the execute delegate.</typeparam>
    /// <typeparam name="TEvaluateDelegate">The type of the evaluate delegate.</typeparam>
    /// <seealso cref="ICommand"/>
    public abstract class DelegateCommandTemplate<TParam, TExecuteDelegate, TEvaluateDelegate> : ICommand
        where TExecuteDelegate : class
        where TEvaluateDelegate : class
    {
        /// <summary>
        /// The can execute
        /// </summary>
        protected readonly TEvaluateDelegate canExecute;

        /// <summary>
        /// The execute
        /// </summary>
        protected readonly TExecuteDelegate execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommandTemplate(TExecuteDelegate execute, TEvaluateDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}