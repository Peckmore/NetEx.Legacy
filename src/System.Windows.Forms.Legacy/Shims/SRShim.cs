using System.Resources;

namespace System
{
    /// <summary>
    /// A resource file shim to encapsulate functionality from the `SR` class in `System.Drawing.Common\Special`. This functionality was
    /// implemented as a shim to prevent a name collision with the original methods in WinForms, but the bulk of the code is taken from
    /// the original implementation in the WinForms repo.
    /// </summary>
    internal static class SRShim
    {
        #region Fields

        private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out bool usingResourceKeys)
                                                           && usingResourceKeys;

        #endregion

        #region Methods

        // This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
        // by default it returns the value of System.Resources.UseSystemResourceKeys AppContext switch or false if not specified.
        // Native code generators can replace the value this returns based on user input at the time of native code generation.
        // The Linker is also capable of replacing the value of this method when the application is being trimmed.
        internal static bool UsingResourceKeys()
        {
            return s_usingResourceKeys;
        }
        internal static string GetResourceString(string resourceKey)
        {
            if (UsingResourceKeys())
            {
                return resourceKey;
            }

            string? resourceString = null;
            try
            {
                resourceString = ""; //ResourceManager.GetString(resourceKey);
            }
            catch (MissingManifestResourceException)
            {
                // Swallow exception.
            }

            return resourceString!; // only null if missing resources
        }

        #endregion
    }
}