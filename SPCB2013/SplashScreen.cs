using SPBrowser.Properties;
using SPBrowser.Utils;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SPBrowser
{
    /// <summary>
    /// Represents the splash screen launched at the start of the application.
    /// </summary>
    public partial class SplashScreen : Form
    {
        // Delegates for cross thread calls
        private delegate void CloseDelegate();        
        private delegate void UpdateDelegate(string message);

        // The type of form to be displayed as the splash screen.
        private static SplashScreen splashForm;

        /// <summary>
        /// Launch splash screen.
        /// </summary>
        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.
            if (splashForm != null)
                return;

            Thread thread = new Thread(new ThreadStart(SplashScreen.ShowFormInternal));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// Internal <see cref="ShowFormInternal"/> method to support launch in cross thread call.
        /// </summary>
        static private void ShowFormInternal()
        {
            splashForm = new SplashScreen();
            splashForm.MinimumSize = splashForm.Size;
            splashForm.MaximumSize = splashForm.Size;

            Application.Run(splashForm);

            splashForm.Focus();
        }

        /// <summary>
        /// Closes the splash screen.
        /// </summary>
        static public void CloseForm()
        {
            WaitForSplashScreen();

            splashForm.Invoke(new CloseDelegate(SplashScreen.CloseFormInternal));
        }

        /// <summary>
        /// Internal <see cref="CloseFormInternal"/> method to support close in cross thread call.
        /// </summary>
        static private void CloseFormInternal()
        {
            splashForm.Close();
        }

        /// <summary>
        /// Update the status message shown on the splash screen.
        /// </summary>
        /// <param name="message">Status message shown on the splash screen.</param>
        static public void UpdateForm(string message)
        {
            WaitForSplashScreen();

            splashForm.Invoke(new UpdateDelegate(SplashScreen.UpdateFormInternal), message);
        }

        /// <summary>
        /// Internal <see cref="UpdateFormInternal"/> method to support update in cross thread call.
        /// </summary>
        static private void UpdateFormInternal(string message)
        {
            splashForm.lbStatus.Text = message;
        }

        /// <summary>
        /// Wait handle to ensure the splash screen is initialized before making changes to it. 
        /// </summary>
        /// <remarks>
        /// The wait handle will time out after 10 seconds.
        /// </remarks>
        static private void WaitForSplashScreen()
        {
            int step = 1000; // Step = 1 sec
            int timeout = 10000; // Timeout after 10 sec

            for (int i = step; i < timeout; i = i + step)
            {
                if (splashForm != null)
                    break;

                Console.WriteLine("Working on it... (Splashscreen launch - {0} ms)", i);
                Thread.Sleep(i);
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();

            this.Text = string.Format("{0} by Bram de Jager", Application.ProductName);
#if CLIENTSDKV150 || CLIENTSDKV160
            this.BackgroundImage = Resources.SplashScreenSharePoint2013;
            this.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
#elif CLIENTSDKV161
            this.BackgroundImage = Resources.SplashScreenOffice365;
            this.BackColor = System.Drawing.Color.FromArgb(235, 59, 0);
#endif
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            lbProductInfo.Text = string.Format("{0} ({1}) by Bram de Jager",
                Application.ProductName,
                ProductUtil.GetProductVersionInfo().FileVersion);
        }

        private void llWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Constants.PERSONAL_BLOG_URL);
        }

        private void llTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Constants.PERSONAL_TWITTER_URL);
        }
    }
}
