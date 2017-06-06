using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace SPBrowser.Utils
{
    public class ProductUtil
    {
        private const string RELEASE_PREFIX = "Released:";

#if !DEBUG
        private const string RELEASE_RSS_FEED_URL = "https://spcb.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fspcb";
#else
        private const string RELEASE_RSS_FEED_URL = "https://spcb.codeplex.com/project/feeds/rss?ProjectRSSFeed=codeplex%3a%2f%2frelease%2fspcb";
        //private const string RELEASE_RSS_FEED_URL = @"C:\Sources\Codeplex\spcb\SPCB2013\Resources\SPCB-Releases-RSS.xml";
#endif

        /// <summary>
        /// Checks if new version is available.
        /// </summary>
        /// <returns></returns>
        public static bool IsNewUpdateAvailable(out Version currentReleaseVersion, out Uri downloadUrl, out string currentReleaseTitle)
        {
            Regex regVersion = new Regex(@"v([0-9]|\.)+");

            currentReleaseVersion = null;
            downloadUrl = null;
            currentReleaseTitle = null;

            try
            {
                currentReleaseVersion = GetLatestRelease(out currentReleaseTitle, out downloadUrl);

                if (currentReleaseVersion > GetCurrentProductVersion())
                    return true;
            }
            catch (Exception ex)
            {
                LogUtil.LogException(ex);
            }

            return false;
        }

        /// <summary>
        /// Gets the latest release from the Internet
        /// </summary>
        /// <param name="releaseTitle"></param>
        /// <param name="downloadUrl"></param>
        /// <returns></returns>
        private static Version GetLatestRelease(out string releaseTitle, out Uri downloadUrl)
        {
            Regex regVersion = new Regex(@"v([0-9]|\.)+");
            Version version = new Version();

            releaseTitle = null;
            downloadUrl = null;

            try
            {
                if (NetworkUtil.IsConnectedToInternet())
                {
                    foreach (var feedItem in GetReleases())
                    {
                        Match result = regVersion.Match(feedItem.Title.Text);

                        if (result.Success)
                        {
                            Version release = new Version(result.Value.Replace('v', ' '));
                            if (release > version)
                            {
                                version = release;
                                releaseTitle = feedItem.Title.Text.Substring(feedItem.Title.Text.IndexOf(':') + 1).Trim();
                                downloadUrl = feedItem.Links[0].Uri;
                            }
                        }
                    }
                }
                else
                {
                    LogUtil.LogMessage("No internet connection: skipped checking for new releases.");
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogException(ex);
            }

            return version;
        }

        /// <summary>
        /// Gets the list of releases for this product from Codeplex.
        /// </summary>
        /// <returns></returns>
        private static List<SyndicationItem> GetReleases()
        {
            string releaseName = GetProductVersionInfo().FileDescription;

            var feedUrl = RELEASE_RSS_FEED_URL;
            var reader = XmlReader.Create(feedUrl);
            var feed = SyndicationFeed.Load(reader);

            return feed.Items.Where(f =>
                    f.Title.Text.StartsWith(RELEASE_PREFIX) &&
                    f.Title.Text.Contains(releaseName))
                .ToList();
        }

        /// <summary>
        /// Gets the current product version.
        /// </summary>
        /// <returns></returns>
        public static Version GetCurrentProductVersion()
        {
            FileVersionInfo fvi = GetProductVersionInfo();

            return new Version(fvi.FileVersion);
        }

        /// <summary>
        /// Gets the File Version Information for the current assembly.
        /// </summary>
        /// <returns></returns>
        public static FileVersionInfo GetProductVersionInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi;
        }

        /// <summary>
        /// Gets the release notes.
        /// </summary>
        /// <returns>Returns the release notes for the current version.</returns>
        public static string GetReleaseNotes()
        {
            string releaseNotes = string.Empty;

#if CLIENTSDKV150
            releaseNotes = Properties.Resources.ReleaseNotes15_0;
#elif CLIENTSDKV160
            releaseNotes = Properties.Resources.ReleaseNotes16_0;
#elif CLIENTSDKV161
            releaseNotes = Properties.Resources.ReleaseNotes16_1;
#endif

            return releaseNotes;
        }

        /// <summary>
        /// Gets the product icon (Bitmap of 32x32 pixels).
        /// </summary>
        /// <returns>Returns the product icon for the current product.</returns>
        public static Bitmap GetProductIcon32x32()
        {
            Bitmap icon;

#if CLIENTSDKV150
            icon = Properties.Resources.SharePoint;
#elif CLIENTSDKV160
            icon = Properties.Resources.SharePoint;
#elif CLIENTSDKV161
            icon = Properties.Resources.Office365_32x32;
#endif

            return icon;
        }

        /// <summary>
        /// Gets the product icon.
        /// </summary>
        /// <returns>Returns the product icon for the current product.</returns>
        public static Icon GetProductIcon()
        {
            Icon icon;

#if CLIENTSDKV150
            icon = Properties.Resources.SharePoint2013;
#elif CLIENTSDKV160
            icon = Properties.Resources.SharePoint2013;
#elif CLIENTSDKV161
            icon = Properties.Resources.Office365;
#endif

            return icon;
        }
    }
}
