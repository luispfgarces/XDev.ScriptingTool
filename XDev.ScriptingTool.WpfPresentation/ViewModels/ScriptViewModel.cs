namespace XDev.ScriptingTool.WpfPresentation.ViewModels
{
    using System;
    using PropertyChanged;

    /// <summary>
    /// <see cref="ScriptViewModel"/>
    /// </summary>
    [ImplementPropertyChanged]
    public class ScriptViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the script shall execute.
        /// </summary>
        /// <value><c>true</c> if execute; otherwise, <c>false</c>.</value>
        public bool Execute { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the script file path.
        /// </summary>
        /// <value>The script file path.</value>
        public string ScriptFilePath { get; set; }
    }
}