namespace XDev.ScriptingTool.ConsolePresentation
{
    using System;
    using System.Reflection;

    /// <summary>
    /// <see cref="Consts"/>
    /// </summary>
    internal static class Consts
    {
        /// <summary>
        /// The exit message
        /// </summary>
        public static readonly string ExitMessage = "Press any key to exit...";

        /// <summary>
        /// The parameter value separator
        /// </summary>
        public static readonly char ParamValueSeparator = '=';

        /// <summary>
        /// The path parameter name
        /// </summary>
        public static readonly string PathParamName = "ScriptsPath";

        /// <summary>
        /// The start message
        /// </summary>
        public static readonly string StartMessage = $@"{ Assembly.GetCallingAssembly().GetName().Name } - XDev Scripting Tool © Luís Garcês";

        /// <summary>
        /// The usage message constant
        /// </summary>
        public static readonly string UsageMessage = $@"
    USAGE: wsc.exe {Consts.PathParamName}{ParamValueSeparator}<scriptsPath>";
    }
}