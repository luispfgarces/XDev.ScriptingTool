namespace XDev.ScriptingTool.Models
{
    using System;

    /// <summary>
    /// <see cref="ScriptingStatusDescription"/>
    /// </summary>
    public enum ScriptingStatusDescription
    {
        /// <summary>
        /// The begin all scripts compile
        /// </summary>
        BeginAllScriptsCompile = 1,

        /// <summary>
        /// The finalize all scripts compile
        /// </summary>
        FinalizeAllScriptsCompile = 2,

        /// <summary>
        /// The begin script compile
        /// </summary>
        BeginScriptCompile = 3,

        /// <summary>
        /// The finalize script compile
        /// </summary>
        FinalizeScriptCompile = 4,

        /// <summary>
        /// The success script compile
        /// </summary>
        SuccessScriptCompile = 5,

        /// <summary>
        /// The fail script compile
        /// </summary>
        FailScriptCompile = 6,

        /// <summary>
        /// The begin all scripts execute
        /// </summary>
        BeginAllScriptsExecute = 7,

        /// <summary>
        /// The finalize all scripts execute
        /// </summary>
        FinalizeAllScriptsExecute = 8,

        /// <summary>
        /// The begin script execute
        /// </summary>
        BeginScriptExecute = 9,

        /// <summary>
        /// The finalize script execute
        /// </summary>
        FinalizeScriptExecute = 10,

        /// <summary>
        /// The success script execute
        /// </summary>
        SuccessScriptExecute = 11,

        /// <summary>
        /// The fail script execute
        /// </summary>
        FailScriptExecute = 12
    }
}