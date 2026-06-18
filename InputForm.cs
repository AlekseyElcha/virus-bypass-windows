using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirusBypass
{
    public partial class InputForm : Form
    {
        public string Value { get; private set; } = string.Empty;
        public bool Confirmed { get; private set; } = false;

        public InputForm(string defaultValue = "")
        {
            InitializeComponent();
            textBox1.Text = defaultValue;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void submitInputFormButton_Click(object sender, EventArgs e)
        {
            Value = textBox1.Text;
            Confirmed = true;
            Close();
        }
    }
}
