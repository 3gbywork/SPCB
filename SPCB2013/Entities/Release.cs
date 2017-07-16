using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPBrowser.Entities
{
    /// <summary>
    /// Represents a release of SharePoint Client Browser.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public Version Version { get; set; }

        /// <summary>
        /// Gets or sets the download URI for the release.
        /// </summary>
        /// <value>
        /// The download URI.
        /// </value>
        public Uri DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the release title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
    }
}
