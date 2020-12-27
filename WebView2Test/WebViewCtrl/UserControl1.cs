using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            await webBrowser.EnsureCoreWebView2Async(null);

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
