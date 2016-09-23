namespace XDev.ScriptingTool.Attributes
{
    using System;

    /// <summary>
    /// Marks a method as a script method.
    /// </summary>
    /// <seealso cref="Attribute"/>
    public class ScriptMethodAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptMethodAttribute"/> class.
        /// </summary>
        /// <param name="customizationName">Name of the customization.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ScriptMethodAttribute(string customizationName)
        {
            if (string.IsNullOrEmpty(customizationName))
            {
                throw new ArgumentNullException(nameof(customizationName));
            }

            this.CustomizationName = customizationName;
        }

        /// <summary>
        /// Gets the name of the customization.
        /// </summary>
        /// <value>The name of the customization.</value>
        public string CustomizationName { get; private set; }
    }
}