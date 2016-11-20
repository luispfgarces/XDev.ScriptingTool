namespace XDev.ScriptingTool.ConsoleOutputs.Observers.ScriptingStatusInterpreters.Implementations
{
    using System;
    using Models;

    /// <summary>
    /// <see cref="BeginScriptCompileCompileScriptingStatusInterpretationStrategy"/>
    /// </summary>
    /// <seealso cref="IScriptingStatusInterpretationStrategy"/>
    internal class BeginScriptCompileCompileScriptingStatusInterpretationStrategy : IScriptingStatusInterpretationStrategy
    {
        /// <summary>
        /// Interprets the scripting status.
        /// </summary>
        /// <param name="scriptingStatus">The scripting status.</param>
        /// <returns></returns>
        public Message InterpretScriptingStatus(ScriptingStatus scriptingStatus)
        {
            FileDiscoveryInfo fileDiscoveryInfo = scriptingStatus.AditionalData as FileDiscoveryInfo;

            return new Message
            {
                Color = ConsoleOutputColor.Blue,
                Text = $"[{ fileDiscoveryInfo.FileName }]: Compiling file..."
            };
        }
    }
}