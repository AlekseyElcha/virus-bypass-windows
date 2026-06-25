using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusBypass
{
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {

        }
        private readonly char[] _invalidChars = Path.GetInvalidFileNameChars();
        public string NewName => txtNewName.Text.Trim();
        public RenameForm(string currentName)
        {
            InitializeComponent();
            txtNewName.Text = currentName;

            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            txtNewName.TextChanged += TxtNewName_TextChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (DialogResult == DialogResult.OK && string.IsNullOrWhiteSpace(NewName))
            {
                MessageBox.Show("Имя файла не может быть пустым!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void TxtNewName_TextChanged(object sender, EventArgs e)
        {
            string text = txtNewName.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                btnOk.Enabled = false;
                return;
            }

            int invalidIndex = text.IndexOfAny(_invalidChars);

            if (invalidIndex != -1)
            {
                char foundInvalidChar = text[invalidIndex];
                btnOk.Enabled = false;
                MessageBox.Show($"Символ {foundInvalidChar} запрещен для имени файла!");
            }
            else
            {
                btnOk.Enabled = true;
            }
        }
    }
}