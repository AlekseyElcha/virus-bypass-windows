using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VirusBypass
{
    public partial class UserControlAutostartup : UserControl
    {
        public UserControlAutostartup()
        {
            InitializeComponent();
            var contextMenu = new ContextMenuStrip();

            var changeItem = contextMenu.Items.Add("Изменить значение");
            var copyItem = contextMenu.Items.Add("Копировать значение");

            int _selectedRow = -1;
            string _name = string.Empty;
            string _currentValue = string.Empty;
            DataGridView? _activeGrid = null;

            changeItem.Click += (s, e) =>
            {
                if (_selectedRow < 0 || _activeGrid == null) return;

                using var form = new InputForm(_currentValue);
                form.ShowDialog();

                if (!form.Confirmed) return;

                string newValue = form.Value;

                _activeGrid[1, _selectedRow].Value = newValue;

                if (_activeGrid == dataGridView3)
                {
                    AutoStartups.SetWinlogonValue(_name, newValue);
                }   
                else if (_activeGrid == dataGridView4)
                {
                    AutoStartups.SetCmdlineValue(_name, newValue);
                }
                    
            };

            copyItem.Click += (s, e) =>
            {
                if (_activeGrid?.CurrentCell != null)
                    Clipboard.SetText(_activeGrid.CurrentCell.Value?.ToString() ?? "");
            };

            void AttachContextMenu(DataGridView dgv)
            {
                dgv.CellMouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex == 1)
                    {
                        _activeGrid = dgv;
                        _selectedRow = e.RowIndex;
                        _name = dgv[0, e.RowIndex].Value?.ToString() ?? "";
                        _currentValue = dgv[1, e.RowIndex].Value?.ToString() ?? "";
                        dgv.CurrentCell = dgv[e.ColumnIndex, e.RowIndex];
                        contextMenu.Show(dgv, dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    }
                };
            }

            var contextMenuScheduler = new ContextMenuStrip();
            var deleteItem = contextMenuScheduler.Items.Add("Удалить задачу");

            deleteItem.Click += (s, e) =>
            {
                if (_selectedRow < 0) return;

                string taskPath = dataGridView2[1, _selectedRow].Value?.ToString() ?? "";

                var confirm = MessageBox.Show(
                    $"Удалить задачу \"{taskPath}\"?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes) return;

                try
                {
                    AutoStartups.DeleteScheduledTask(taskPath);
                    dataGridView2.Rows.RemoveAt(_selectedRow);
                    _selectedRow = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            var contextMenuRun = new ContextMenuStrip();
            var deleteRunItem = contextMenuRun.Items.Add("Удалить из автозапуска");
            var copyRunItem = contextMenuRun.Items.Add("Копировать значение");

            deleteRunItem.Click += (s, e) =>
            {
                if (_selectedRow < 0) return;

                var confirm = MessageBox.Show(
                    $"Удалить \"{_name}\" из автозапуска?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes) return;

                AutoStartups.DeleteRunValue(_name);
                dataGridView1.Rows.RemoveAt(_selectedRow);
                _selectedRow = -1;
            };

            copyRunItem.Click += (s, e) =>
            {
                if (dataGridView1.CurrentCell != null)
                    Clipboard.SetText(dataGridView1.CurrentCell.Value?.ToString() ?? "");
            };

            void AttachContextMenuRun(DataGridView dgv)
            {
                dgv.CellMouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    {
                        _activeGrid = dgv;
                        _selectedRow = e.RowIndex;
                        _name = dgv[0, e.RowIndex].Value?.ToString() ?? "";
                        _currentValue = dgv[1, e.RowIndex].Value?.ToString() ?? "";
                        dgv.CurrentCell = dgv[e.ColumnIndex, e.RowIndex];
                        contextMenuRun.Show(dgv, dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    }
                };
            }

            void AttachContextMenuForScheduler(DataGridView dgv)
            {
                dgv.CellMouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    {
                        _activeGrid = dgv;
                        _selectedRow = e.RowIndex;
                        dgv.CurrentCell = dgv[e.ColumnIndex, e.RowIndex];
                        contextMenuScheduler.Show(dgv, dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                    }
                };
            }

            AttachContextMenuRun(dataGridView1);
            AttachContextMenuForScheduler(dataGridView2);
            AttachContextMenu(dataGridView3);
            AttachContextMenu(dataGridView4);
        }

        private void autoStartupControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            switch (autoStartupControl.SelectedIndex)
            {
                case 1:
                    dataGridView2.Rows.Clear();
                    var resultsScheduler = AutoStartups.GetScheduledTasks();
                    foreach (var task in resultsScheduler)
                    {
                        dataGridView2.Rows.Add(
                            task["Name"],
                            task["Path"],
                            task["Status"],
                            task["LastRun"],
                            task["NextRun"],
                            task["Author"],
                            task["Enabled"]
                        );
                    }
                    break;
                case 2:
                    dataGridView3.Rows.Clear();
                    var resultsWinLogon = AutoStartups.GetWinlogonSettings();
                    foreach (var (name, value) in resultsWinLogon)
                    {
                        if (
                            name == "Userinit" ||
                            name == "UserInit" ||
                            name == "Shell" ||
                            name == "userinit" ||
                            name == "shell" ||
                            name == "AutoAdminLogon" ||
                            name == "DefaultUserName" ||
                            name == "LastUsedUsername"
                            )
                        {
                            dataGridView3.Rows.Add(name, value);
                        }
                        dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
                case 3:
                    dataGridView4.Rows.Clear();
                    var resultsCmdLine = AutoStartups.GetWinlogonCmdLine();
                    foreach (var (name, value) in resultsCmdLine)
                    {
                        dataGridView4.Rows.Add(name, value);
                    }
                    dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                default:
                    var resultsRunRunOnce = AutoStartups.GetRunRunOnce();
                    foreach (var pathKey in resultsRunRunOnce)
                    {
                        var innerDictionary = pathKey.Value;

                        foreach (var (name, value) in innerDictionary)
                        {
                            dataGridView1.Rows.Add(name, value);
                        }
                    }
                    dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
            }

        }

        private void UserControlAutostartup_Load(object sender, EventArgs e)
        {
            var results = AutoStartups.GetRunRunOnce();
            foreach (var pathKey in results)
            {
                foreach (var (name, value) in pathKey.Value)
                {
                    dataGridView1.Rows.Add(name, value);
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string taskPath = e.Row.Cells[1].Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(taskPath))
            {
                e.Cancel = true;
                return;
            }

            var confirm = MessageBox.Show(
                $"Удалить задачу \"{taskPath}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                AutoStartups.DeleteRunValue(taskPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string taskPath = e.Row.Cells[1].Value?.ToString() ?? "";

            if (string.IsNullOrEmpty(taskPath))
            {
                e.Cancel = true;
                return;
            }

            var confirm = MessageBox.Show(
                $"Удалить задачу \"{taskPath}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                AutoStartups.DeleteScheduledTask(taskPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
