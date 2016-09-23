namespace XDev.ScriptingTool.Attributes
{
    using System;

    /// <summary>
    /// Marks a class as a script class.
    /// </summary>
    /// <seealso cref="Attribute"/>
    public class ScriptClassAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptClassAttribute"/> class.
        /// </summary>
        /// <param name="customizationsCollectionName">Name of the customizations collection.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ScriptClassAttribute(string customizationsCollectionName)
        {
            if (string.IsNullOrEmpty(customizationsCollectionName))
            {
                throw new ArgumentNullException(nameof(customizationsCollectionName));
            }

            this.CustomizationsCollectionName = customizationsCollectionName;
        }

        /// <summary>
        /// Gets the name of the customizations collection.
        /// </summary>
        /// <value>The name of the customizations collection.</value>
        public string CustomizationsCollectionName { get; private set; }
    }
}