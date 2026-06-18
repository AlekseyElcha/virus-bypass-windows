using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirusBypass
{
    public partial class AboutProgram : Form
    {
        public AboutProgram()
        {
            InitializeComponent();

        }

        public AboutProgram(string versionText)
        {
            InitializeComponent();

            label3.Text = versionText;
        }

        private void AboutProgram_Load(object sender, EventArgs e)
        {   
            //
        }
    }
}
