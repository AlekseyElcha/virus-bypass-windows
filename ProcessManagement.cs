using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusBypass
{
    public partial class ProcessManagement : UserControl
    {
        public ProcessManagement()
        {
            InitializeComponent();

            this.HandleCreated += (s, e) => LoadAndDisplayProcessesAsync();
        }

        private async Task LoadAndDisplayProcessesAsync()
        {
            loadProcessesButton.Enabled = false;
            dataGridView1.SuspendLayout();
            dataGridView1.Rows.Clear();

            try
            {
                var processes = await Task.Run(() => ProcessManager.GetAllProcesses());

                foreach (var p in processes)
                {
                    dataGridView1.Rows.Add(
                        p["Name"], p["PID"], p["Critical"],
                        p["Path"], p["User"], p["Memory"], p["Threads"]
                    );
                }
                infoLabel.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке процессов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataGridView1.ResumeLayout();
                loadProcessesButton.Enabled = true;
            }
        }

        private async void loadProcessesButton_Click(object sender, EventArgs e)
        {
            await LoadAndDisplayProcessesAsync();
        }

        private void terminateProcessButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string name = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? "";
            string pidStr = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "";
            string critical = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? "";

            if (!int.TryParse(pidStr, out int pid)) return;

            if (critical == "Да" && !ConfirmCriticalTermination(name, pid)) return;

            if (KillProcessById(pid))
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row == null) return;

            string name = e.Row.Cells[0].Value?.ToString() ?? "";
            string pidStr = e.Row.Cells[1].Value?.ToString() ?? "";
            string critical = e.Row.Cells[2].Value?.ToString() ?? "";

            if (!int.TryParse(pidStr, out int pid))
            {
                e.Cancel = true;
                return;
            }

            if (critical == "Да" && !ConfirmCriticalTermination(name, pid))
            {
                e.Cancel = true;
                return;
            }

            if (!KillProcessById(pid))
            {
                e.Cancel = true;
            }
        }

        private void makeNotCriticalButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string name = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? "";
            string pidStr = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "";
            string critical = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? "";

            if (critical != "Да" || !int.TryParse(pidStr, out int pid)) return;

            if (ProcessManager.SetProcessCriticality(pid, false))
            {
                dataGridView1.CurrentRow.Cells[2].Value = "Нет";
                MessageBox.Show($"Критичность процесса \"{name}\" снята.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось снять критичность. Требуются права администратора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ConfirmCriticalTermination(string name, int pid)
        {
            var confirm = MessageBox.Show(
                $"Процесс \"{name}\" (PID: {pid}) является критическим!\nЕго завершение может вызвать BSOD.\n\nВсё равно завершить?",
                "Внимание — критический процесс!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );
            return confirm == DialogResult.OK;
        }

        private bool KillProcessById(int pid)
        {
            try
            {
                using (var proc = Process.GetProcessById(pid))
                {
                    proc.Kill();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось завершить процесс: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ProcessManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
