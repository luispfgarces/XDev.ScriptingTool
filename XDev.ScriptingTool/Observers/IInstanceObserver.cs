namespace XDev.ScriptingTool.Observers
{
    using System;

    /// <summary>
    /// <see cref="IInstanceObserver{TMessage}"/>
    /// </summary>
    /// <typeparam name="TMessage">The type of the message.</typeparam>
    public interface IInstanceObserver<TMessage>
    {
        /// <summary>
        /// Receives a message from a observed instance.
        /// </summary>
        /// <param name="observedInstance">The observed instance.</param>
        /// <param name="message">The message.</param>
        void ReceiveMessage(object observedInstance, TMessage message);
    }
}