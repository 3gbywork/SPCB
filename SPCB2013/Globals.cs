using SPBrowser.Entities;
using SPBrowser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPBrowser
{
    public static class Globals
    {
        /// <summary>
        /// Site collections history loaded previously in the tool.
        /// </summary>
        /// <remarks>
        /// These site collections are stored in the <see cref="Constants.CONFIG_HISTORY_FILENAME"/> (History.xml).
        /// </remarks>
        public static SiteAuthenticationCollection Sites { get; set; }

        /// <summary>
        /// Tenants history loaded previously in the tool.
        /// </summary>
        /// <remarks>
        /// These tenants are stored in the <see cref="Constants.CONFIG_HISTORY_FILENAME"/> (History.xml).
        /// </remarks>
        public static TenantAuthenticationCollection Tenants { get; set; }

        /// <summary>
        /// User defined features used to display friendly names.
        /// </summary>
        /// <remarks>
        /// Allows users to add friendly names to features who are not out-of-the-box. The features are stored in the <see cref="Constants.CUSTOM_FEATURES_FILENAME"/> (FeatureDefinitions.xml).
        /// </remarks>
        public static FeatureCollection CustomFeatureDefinitions { get; set; }

        /// <summary>
        /// Is a new release available for download?
        /// </summary>
        /// <remarks>
        /// Indicates if a new release is available for download, after a check online in Codeplex Releases section for a new release of SharePoint Client Browser.
        /// </remarks>
        public static bool IsNewUpdateAvailable { get; set; }

        /// <summary>
        /// Command-line arguments provided during startup of the application.
        /// </summary>
        public static CommandArguments Arguments { get; set; }

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Globals()
        {
            Sites = new SiteAuthenticationCollection();
            Tenants = new TenantAuthenticationCollection();
            CustomFeatureDefinitions = new FeatureCollection();
        }
    }
}
