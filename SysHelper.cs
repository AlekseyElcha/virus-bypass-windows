using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VirusBypass
{
    public partial class SysHelper : UserControl
    {
        public SysHelper()
        {
            InitializeComponent();
        }

        private void checkDisksButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    Arguments = "/k chkdsk C: /f",
                    UseShellExecute = true,

                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process process = Process.Start(startInfo))
                {
                    // 
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для проверки диска необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить проверку диска: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void defragDisksButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "dfrgui.exe",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть Оптимизацию дисков: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearDisksButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cleanmgr.exe",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить Очистку дисков: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void serviceManagementButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "services.msc",
                    UseShellExecute = true,
                    // Для изменения состояния служб (запуск/остановка) 
                    // пользователю понадобятся права Администратора
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    Process.Start(new ProcessStartInfo("services.msc") { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть Службы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить утилиту: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DNSCacheButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c ipconfig /flushdns",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        process.WaitForExit();

                        MessageBox.Show("Кэш сопоставителя DNS успешно очищен.",
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось очистить кэш DNS: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetHostsButton_Click(object sender, EventArgs e)
        {
            string defaultHostsContent =
        "# Copyright (c) 1993-2009 Microsoft Corp.\n" +
        "#\n" +
        "# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.\n" +
        "#\n" +
        "# This file contains the mappings of IP addresses to host names. Each\n" +
        "# entry should be kept on an individual line. The IP address should\n" +
        "# be placed in the first column followed by the corresponding host name.\n" +
        "# The IP address and the host name should be separated by at least one\n" +
        "# space.\n" +
        "#\n" +
        "# Additionally, comments (such as these) may be inserted on individual\n" +
        "# lines or following the machine name denoted by a '#' symbol.\n" +
        "#\n" +
        "# For example:\n" +
        "#\n" +
        "#      102.54.94.97     ://acme.com          # source server\n" +
        "#       38.25.63.10     ://acme.com              # x client host\n" +
        "\n" +
        "# localhost name resolution is handled within DNS itself.\n" +
        "#\t127.0.0.1       localhost\n" +
        "#\t::1             localhost\n";

            try
            {
                string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string hostsPath = Path.Combine(system32Path, @"drivers\etc\hosts");

                if (File.Exists(hostsPath))
                {
                    File.SetAttributes(hostsPath, FileAttributes.Normal);
                }

                File.WriteAllText(hostsPath, defaultHostsContent);

                MessageBox.Show("Файл Hosts успешно сброшен до начального состояния.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка доступа! Перезапустите утилиту от имени Администратора,\n" +
                                "чтобы получить права на изменение системных файлов.",
                                "Ошибка прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сбросить файл Hosts: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deviceManagerButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "devmgmt.msc",
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    Process.Start(new ProcessStartInfo("devmgmt.msc") { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть Диспетчер устройств: {ex.Message}",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить утилиту: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupPoliciesButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "gpedit.msc",
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для полноценного использования Групповых политик необходимы права Администратора.",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("не найден") || ex.Message.Contains("find"))
                {
                    MessageBox.Show("Редактор групповых политик (gpedit.msc) не найден в этой системе.\n\n",
                                    "Компонент недоступен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Не удалось запустить Групповые политики: {ex.Message}",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void unblockRegeditButton_Click(object sender, EventArgs e)
        {
            bool isUnblockedAnywhere = false;

            try
            {
                string userPolicyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(userPolicyPath, true))
                {
                    if (key != null && key.GetValue("DisableRegistryTools") != null)
                    {
                        key.DeleteValue("DisableRegistryTools");
                        isUnblockedAnywhere = true;
                    }
                }

                string machinePolicyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(machinePolicyPath, true))
                {
                    if (key != null && key.GetValue("DisableRegistryTools") != null)
                    {
                        key.DeleteValue("DisableRegistryTools");
                        isUnblockedAnywhere = true;
                    }
                }

                if (isUnblockedAnywhere)
                {
                    MessageBox.Show("Ограничения успешно сняты! Редактор реестра (regedit) разблокирован.",
                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Блокировка не обнаружена. Редактор реестра и так доступен в штатном режиме.",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка доступа! Запустите программу от имени Администратора,\n" +
                                "иначе операционная система блокирует восстановление реестра.",
                                "Ошибка прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при разблокировке: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void unblockTaskmgrButton_Click(object sender, EventArgs e)
        {
            bool isUnblockedAnywhere = false;

            try
            {
                string userPolicyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(userPolicyPath, true))
                {
                    if (key != null && key.GetValue("DisableTaskMgr") != null)
                    {
                        key.DeleteValue("DisableTaskMgr");
                        isUnblockedAnywhere = true;
                    }
                }

                string machinePolicyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(machinePolicyPath, true))
                {
                    if (key != null && key.GetValue("DisableTaskMgr") != null)
                    {
                        key.DeleteValue("DisableTaskMgr");
                        isUnblockedAnywhere = true;
                    }
                }

                if (isUnblockedAnywhere)
                {
                    MessageBox.Show("Ограничения успешно сняты! Диспетчер задач снова работает.",
                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Блокировка не обнаружена. Диспетчер задач работает в штатном режиме.",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Ошибка доступа! Запустите утилиту от имени Администратора,\n" +
                                "чтобы программа могла восстановить системные параметры.",
                                "Ошибка прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при разблокировке: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetAssociationsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string exeFileExtsPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.exe";
                string lnkFileExtsPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.lnk";

                bool fixedAny = false;

                using (RegistryKey exeKey = Registry.CurrentUser.OpenSubKey(exeFileExtsPath, true))
                {
                    if (exeKey != null)
                    {
                        if (exeKey.OpenSubKey("UserChoice") != null)
                        {
                            exeKey.DeleteSubKeyTree("UserChoice");
                            fixedAny = true;
                        }
                    }
                }

                using (RegistryKey lnkKey = Registry.CurrentUser.OpenSubKey(lnkFileExtsPath, true))
                {
                    if (lnkKey != null)
                    {
                        if (lnkKey.OpenSubKey("UserChoice") != null)
                        {
                            lnkKey.DeleteSubKeyTree("UserChoice");
                            fixedAny = true;
                        }
                    }
                }

                if (fixedAny)
                {
                    MessageBox.Show("Ассоциации .exe и .lnk успешно восстановлены!\n\n" +
                                    "Для того чтобы изменения полностью вступили в силу, " +
                                    "рекомендуется перезагрузить компьютер или перезапустить Проводник.",
                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Пользовательские подмены не обнаружены.\n" +
                                    "Система использует стандартные параметры запуска файлов.",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сбросить ассоциации файлов: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pcManagerButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "compmgmt.msc",
                    UseShellExecute = true,
                    // Для полноценного управления (разметка дисков, создание задач)
                    // обязательно требуются права Администратора
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                try
                {
                    Process.Start(new ProcessStartInfo("compmgmt.msc") { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть Управление компьютером: {ex.Message}",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить утилиту: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetUpdateCenterButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c net stop wuauserv & net stop bits & net stop cryptsvc & " +
                                "ren %systemroot%\\SoftwareDistribution SoftwareDistribution.bak & " +
                                "ren %systemroot%\\System32\\catroot2 catroot2.bak & " +
                                "net start cryptsvc & net start bits & net start wuauserv",
                    UseShellExecute = true,
                    Verb = "runas",
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process process = Process.Start(startInfo))
                {
                    if (process != null)
                    {
                        process.WaitForExit();
                        MessageBox.Show("Центр обновлений успешно сброшен!\nВременный кэш очищен, службы перезапущены.",
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для сброса Центра обновлений необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сбросе: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void restartExplorerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] explorerProcesses = Process.GetProcessesByName("explorer");

                foreach (Process process in explorerProcesses)
                {
                    process.Kill();
                    process.WaitForExit();
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось перезапустить Проводник: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void safeModeBootButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Компьютер будет перезагружен в Безопасный режим с поддержкой сети.\n\n" +
        "Сохраните все открытые документы перед продолжением. Вы уверены?",
        "Запрос на перезагрузку",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c bcdedit /set {current} safeboot network && shutdown /r /t 0",
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для настройки безопасного режима необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запланировать перезагрузку: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void normalBootButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo clearSafeBoot = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c bcdedit /deletevalue {current} safeboot",
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(clearSafeBoot);
            }
            catch
            {
                //
            }
        }

        private void openExplorerPPButton_Click(object sender, EventArgs e)
        {
            try
            {
                string resourceName = "VirusBypass.explpp.exe";
                string tempPath = Path.Combine(Path.GetTempPath(), "explpp.exe");

                if (!File.Exists(tempPath))
                {
                    var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream == null)
                        {
                            MessageBox.Show($"Ресурс '{resourceName}' не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Запуск отменен: требуются права Администратора.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openEverythingButton_Click(object sender, EventArgs e)
        {
            try
            {
                string resourceName = "VirusBypass.everyt.exe";
                string tempPath = Path.Combine(Path.GetTempPath(), "everyt.exe");

                if (!File.Exists(tempPath))
                {
                    var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (stream == null)
                        {
                            MessageBox.Show($"Ресурс '{resourceName}' не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        using (FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Запуск отменен: требуются права Администратора.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activateWindowsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "irm https://get.activated.win | iex";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoExit -Command \"{command}\"",
                    UseShellExecute = true,

                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process process = Process.Start(startInfo))
                {
                    // 
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для выполнения активации необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить скрипт активации: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

