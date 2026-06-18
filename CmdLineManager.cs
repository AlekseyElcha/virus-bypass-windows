using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VirusBypass
{
    internal partial class CmdLineManager : UserControl
    {

        int _enableCursorCurrentValue = 0;
        internal CmdLineManager()
        {
            InitializeComponent();
            LoadAndShowCmdLine();
            var contextMenu = new ContextMenuStrip();

            var changeItem = contextMenu.Items.Add("Изменить значение");
            var copyItem = contextMenu.Items.Add("Копировать значение");

            int _selectedRow = -1;
            string _name = string.Empty;
            string _currentValue = string.Empty;

            copyItem.Click += (s, e) =>
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var selectedItem = listView1.SelectedItems[0];
                    if (selectedItem.SubItems.Count > 1)
                    {
                        string valueText = selectedItem.SubItems[1].Text;
                        Clipboard.SetText(valueText ?? "");
                    }
                }
            };


            changeItem.Click += (s, e) =>
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var selectedItemName = listView1.SelectedItems[0];
                    var selectedItemValue = listView1.SelectedItems[0];

                    if (selectedItemName.SubItems.Count > 1)
                    {
                        using var form = new InputForm();

                        form.ShowDialog();

                        if (!form.Confirmed) return;

                        var updatedValue = form.Value;

                        string itemName = selectedItemName.Text;

                        if (itemName == "CmdLine")
                        {
                            AutoStartups.SetCmdlineValue(valueName: "CmdLine", newValue: updatedValue);
                        }
                        else if (itemName == "SetupType")
                        {
                            AutoStartups.SetCmdlineValue(valueName: "SetupType", newValue: updatedValue);
                        }
                        else if (itemName == "EnableCursorSuppression")
                        {
                            CmdLineManagement.EnableCursorCmdLine(updatedValue);
                        }
                    }
                }
            };

            void AttachContextMenu(System.Windows.Forms.ListView ltw)
            {
                ltw.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var hitTest = ltw.HitTest(e.Location);

                        if (hitTest.Item != null)
                        {
                            int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                            if (columnIndex == 1)
                            {
                                hitTest.Item.Selected = true;

                                _name = hitTest.Item.SubItems[0].Text ?? "";
                                _currentValue = hitTest.Item.SubItems[1].Text ?? "";
                                _selectedRow = hitTest.Item.Index;

                                contextMenu.Show(ltw, e.Location);
                            }
                        }
                    }
                };
            }

            AttachContextMenu(listView1);
        }

        private void CmdLineManager_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            var results = CmdLineManagement.GetCmdLineValues();
            if (results == null) return;

            listView1.Items.Clear();

            foreach (var res in results)
            {
                string[] row = { res.Key?.ToString(), res.Value?.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void LoadAndShowCmdLine()
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;

            var results1 = CmdLineManagement.GetCmdLineValues();
            if (results1 == null) return;

            listView1.Items.Clear();

            foreach (var res in results1)
            {
                if (res.Key == "EnableCursorSuppression")
                {
                    _enableCursorCurrentValue = int.Parse(res.Value);
                }
                string[] row = { res.Key.ToString(), res.Value.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            var results2 = AutoStartups.GetWinlogonSettings();
            if (results2 == null) return;

            listView2.Items.Clear();

            foreach (var res in results2)
            {
                string[] row = { res.Key.ToString(), res.Value.ToString() };
                listView2.Items.Add(new ListViewItem(row));
            }

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void enableCursorButton_Click(object sender, EventArgs e)
        {
            if (_enableCursorCurrentValue == 0)
            {
                CmdLineManagement.EnableCursorCmdLine("1");
            }
            else
            {
                CmdLineManagement.EnableCursorCmdLine("0");
            }
            LoadAndShowCmdLine();

        }

        private void restoreCmdLineButton_Click(object sender, EventArgs e)
        {
            AutoStartups.SetCmdlineValue(valueName: "CmdLine", newValue: "");
            AutoStartups.SetCmdlineValue(valueName: "SetupType", newValue: "0");
            CmdLineManagement.EnableCursorCmdLine("0");
            LoadAndShowCmdLine();
        }

        private void addExplppToCmdLine_Click(object sender, EventArgs e)
        {
            try
            {
                string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string targetPath = Path.Combine(system32Path, "explpp.exe");

                string resourceName = "VirusBypass.explpp.exe";
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        MessageBox.Show($"Ресурс '{resourceName}' не найден!\nПроверьте правильность имени проекта в свойствах.",
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (FileStream fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                string finalCommand = $@"cmd.exe /c start /b {targetPath}";

                AutoStartups.SetCmdlineValue(valueName: "CmdLine", newValue: finalCommand);
                AutoStartups.SetCmdlineValue(valueName: "SetupType", newValue: "1");

                LoadAndShowCmdLine();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с ресурсами: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreWinlogonUserinitButton_Click(object sender, EventArgs e)
        {
            AutoStartups.SetWinlogonValue(valueName: "Userinit", newValue: @"C:\WINDOWS\system32\userinit.exe,");
        }

        private void restoreWinlogonShellButton_Click(object sender, EventArgs e)
        {
            AutoStartups.SetWinlogonValue(valueName: "Shell", newValue: @"explorer.exe");
            LoadAndShowCmdLine();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
