namespace XDev.ScriptingTool.Observers
{
    using System;

    /// <summary>
    /// <see cref="IObservableInstance{TMessage}"/>
    /// </summary>
    /// <typeparam name="TMessage">The type of the message.</typeparam>
    public interface IObservableInstance<TMessage>
    {
        /// <summary>
        /// Subscribes this instance for updates on its' state.
        /// </summary>
        /// <param name="instanceObserver">The instance observer.</param>
        void Subscribe(IInstanceObserver<TMessage> instanceObserver);
    }
}