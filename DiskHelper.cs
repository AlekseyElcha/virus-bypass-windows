using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;

using ListView = System.Windows.Forms.ListView;

namespace VirusBypass
{
    public partial class DiskHelper : UserControl
    {
        public DiskHelper()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Буква диска", 90);
            listView1.Columns.Add("Имя раздела", 130);
            listView1.Columns.Add("Размер (МБ)", 100);
            listView1.Columns.Add("Загрузочный", 95);
            listView1.Columns.Add("Индекс диска", 100);
        }

        private void DiskHelper_Load(object sender, EventArgs e)
        {
            WmiScanner.ScanAllDisks(targetListView: listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WmiScanner.ScanAllDisks(targetListView: listView1);
        }

        private void deletePartitionButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите диск/раздел из списка для удаления.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            string driveLetter = selectedItem.Text;
            string partitionId = selectedItem.Tag?.ToString();

            if (driveLetter.Contains("C:") || driveLetter.Contains("c:"))
            {
                MessageBox.Show("Удаление системного диска C: заблокировано ради безопасности системы!", "Защита", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Вы уверены, что хотите ПОЛНОСТЬЮ И БЕЗВОЗВРАТНО удалить раздел [{driveLetter}] ({partitionId})?\nВсе данные на нем будут уничтожены!",
                "Вот тут аккуратно!!!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bool success = WmiScanner.DeletePartitionViaDiskpart(driveLetter, partitionId);

                    if (success)
                    {
                        MessageBox.Show(
                            "Раздел успешно удален со всеми данными.",
                            "Надеюсь, ничего не сломалось",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        WmiScanner.ScanAllDisks(listView1);
                    }
                    else
                    {
                        MessageBox.Show("Diskpart вернул ошибку при удалении раздела. Возможно, утилита запущена не от Администратора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить раздел: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    class WmiScanner
    {
        public static void ScanAllDisks(System.Windows.Forms.ListView targetListView)
        {
            targetListView.Items.Clear();

            if (targetListView.Columns.Count == 0)
            {
                targetListView.View = View.Details;
                targetListView.FullRowSelect = true;
                targetListView.GridLines = true;

                targetListView.Columns.Add("Буква диска", 90);
                targetListView.Columns.Add("Имя раздела", 130);
                targetListView.Columns.Add("Размер (МБ)", 100);
                targetListView.Columns.Add("Загрузочный", 95);
                targetListView.Columns.Add("Индекс диска", 100);
            }

            ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition");

            foreach (ManagementObject partition in partitionSearcher.Get())
            {
                string partitionName = partition["Name"]?.ToString() ?? "Неизвестно";
                string deviceId = partition["DeviceID"]?.ToString();

                ulong sizeInBytes = Convert.ToUInt64(partition["Size"]);
                string sizeInMb = (sizeInBytes / 1024 / 1024).ToString("N0") + " МБ";
                string isBootable = partition["Bootable"]?.ToString() ?? "Нет";
                string diskIndex = partition["DiskIndex"]?.ToString() ?? "0";

                string driveLetter = "Нет (Скрыт)";
                if (!string.IsNullOrEmpty(deviceId))
                {
                    string escapedId = deviceId.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    string assocQuery = $"ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{escapedId}'}} WHERE AssocClass = Win32_LogicalDiskToPartition";

                    using (ManagementObjectSearcher assocSearcher = new ManagementObjectSearcher(assocQuery))
                    {
                        foreach (ManagementObject logicalDisk in assocSearcher.Get())
                        {
                            driveLetter = logicalDisk["Name"]?.ToString() ?? "Нет";
                        }
                    }
                }

                ListViewItem item = new ListViewItem(driveLetter);

                item.SubItems.Add(partitionName);
                item.SubItems.Add(sizeInMb);
                item.SubItems.Add(isBootable);
                item.SubItems.Add(diskIndex);

                item.Tag = deviceId;

                targetListView.Items.Add(item);
            }
        }

        public static bool DeletePartitionViaDiskpart(string letter, string partitionId)
        {
            if (string.IsNullOrEmpty(partitionId)) return false;

            int diskNum = 0;
            int partNum = 0;

            try
            {
                string[] parts = partitionId.Split(',');
                diskNum = int.Parse(parts[0].Replace("Disk #", "").Trim());
                partNum = int.Parse(parts[1].Replace("Partition #", "").Trim());

                partNum += 1;
            }
            catch
            {
                MessageBox.Show("Не удалось получить индекс раздела для утилиты Diskpart.");
                return false;
            }

            string scriptPath = Path.Combine(Path.GetTempPath(), "delete_part_script.txt");
            string scriptContent = "";

            if (!string.IsNullOrEmpty(letter) && !letter.StartsWith("Нет"))
            {
                string cleanLetter = letter.Replace(":", "").Trim();
                scriptContent = $"select volume {cleanLetter}\ndelete volume override\nexit";
            }
            else
            {
                scriptContent = $"select disk {diskNum}\nselect partition {partNum}\ndelete partition override\nexit";
            }

            File.WriteAllText(scriptPath, scriptContent);

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "diskpart.exe",
                Arguments = $"/s \"{scriptPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();

                if (File.Exists(scriptPath))
                    File.Delete(scriptPath);

                return process.ExitCode == 0;
            }
        }
    }
}
