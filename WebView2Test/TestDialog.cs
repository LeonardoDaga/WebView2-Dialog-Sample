using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebView2Test
{
    public partial class TestDialog : Form
    {
        public TestDialog()
        {
            InitializeComponent();
        }

        private void TestDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.userControl11.Dispose();
        }
    }
}
