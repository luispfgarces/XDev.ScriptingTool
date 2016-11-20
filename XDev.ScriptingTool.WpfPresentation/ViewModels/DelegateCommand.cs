namespace XDev.ScriptingTool.WpfPresentation.ViewModels
{
    using System;

    /// <summary>
    /// <see cref="DelegateCommand{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ViewModels.DelegateCommandTemplate{T, Action{T}, Predicate{T}}"/>
    public class DelegateCommand<T> : DelegateCommandTemplate<T, Action<T>, Predicate<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="execute">The execute.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
            : base(execute, canExecute)
        {
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public override bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            return canExecute((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object
        /// can be set to null.
        /// </param>
        public override void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}