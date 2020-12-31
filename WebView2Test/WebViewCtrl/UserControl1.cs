using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WebViewCtrl
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            this.Load += UserControl1_Load;
        }

        private async void UserControl1_Load(object sender, EventArgs e)
        {
            // Select a folder where to host the browser cache
            var userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WebView2Test";

            // Create the environment. The first argument is null to indicate to use To create WebView2 controls that use 
            // the installed version of the WebView2 Runtime that exists on user machines 
            var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);

            // Pass the environment as argument
            await webBrowser.EnsureCoreWebView2Async(env);

            webBrowser.NavigationStarting += WebBrowser_NavigationStarting;
        }

        private void WebBrowser_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            tbTxtAddress.Text = e.Uri;
        }

        private void tbTxtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                webBrowser.CoreWebView2.Navigate(tbTxtAddress.Text);
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
                webBrowser.GoBack();
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            webBrowser.Reload();
        }


    }
}
