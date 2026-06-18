using Microsoft.Win32;
using System.Diagnostics;
using System.Management;

namespace VirusBypass
{
    public partial class w : Form
    {
        public w()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            programVersionLabel.Text = "1.1 (beta)";

            string osName = GetWindowsInfoViaWmi();
            if (osName.Contains("Windows Vista") || osName.Contains("Windows 7") || osName.Contains("Windows 8"))
            {
                MessageBox.Show("Программа предназначена для полее поздних версий Windows :(\r\n" +
                    "Некоторые функции могут работать некоррекно.",
                    "Проблемы с совместимостью",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                // Application.Exit();
            }

            else if (osName.Contains("32"))
            {
                MessageBox.Show(" :(\r\n" +
                    "Часть функций программы МОЖЕТ не работать на 32-битной версии Windows",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                // Application.Exit();
            }

            else if (osName.Contains("Windows XP"))
            {
                MessageBox.Show(" :(\r\n" +
                    "Вы смогли запустить эту прогу на XP?) Моё почтение Вам!",
                    "Оппаааа",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                // Application.Exit();
            }

            OSVersionLabel.Text = osName;
        }

        private void autoStartupButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            UserControlAutostartup myControl = new UserControlAutostartup();

            myControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(myControl);
        }

        private void processesButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            ProcessManagement myControl = new ProcessManagement();

            myControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(myControl);
        }

        private void cmdLineButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            CmdLineManager myControl = new CmdLineManager();

            myControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(myControl);
        }

        private void utilsButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            SysHelper myControl = new SysHelper();

            myControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(myControl);
        }

        private void diskButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            DiskHelper myControl = new DiskHelper();

            myControl.Dock = DockStyle.Fill;

            panel1.Controls.Add(myControl);
        }

        private void aboutProgramButton_Click(object sender, EventArgs e)
        {
            AboutProgram aboutWin = new AboutProgram(programVersionLabel.Text);

            aboutWin.ShowDialog();
        }

        private void accessibilityToolSubstButton_Click(object sender, EventArgs e)
        {
            string currentExe = Application.ExecutablePath;

            var confirm = MessageBox.Show(
                "Заменить sethc.exe и utilman.exe текущей программой?\nЭто позволит запускать программу с экрана блокировки.",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            bool success = AccessibilitySubst.SubstituteWithCurrentApp(currentExe);

            if (success)
                MessageBox.Show("Файлы успешно подменены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void accessibilityToolRestoreButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
        "Восстановить оригинальные sethc.exe и utilman.exe?",
        "Подтверждение",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            bool success = AccessibilitySubst.RestoreOriginals();

            if (success)
                MessageBox.Show("Файлы успешно восстановлены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sfcScannowButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    Arguments = "/k sfc /scannow",
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
                MessageBox.Show("Для выполнения проверки системы необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить проверку: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreDISMButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/k dism.exe /Online /Cleanup-Image /RestoreHealth",
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
                MessageBox.Show("Для восстановления образа системы необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось запустить утилиту DISM: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restoreFontsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fontsRegistryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(fontsRegistryPath, true))
                {
                    if (key != null)
                    {
                        key.SetValue("Segoe UI (TrueType)", "segoeui.ttf");
                        key.SetValue("Segoe UI Bold (TrueType)", "segoeuib.ttf");
                        key.SetValue("Segoe UI Italic (TrueType)", "segoeuii.ttf");
                        key.SetValue("Arial (TrueType)", "arial.ttf");
                        key.SetValue("Arial Bold (TrueType)", "arialbd.ttf");
                        key.SetValue("Times New Roman (TrueType)", "times.ttf");
                        key.SetValue("Courier New (TrueType)", "cour.ttf");
                    }
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c fontview.exe /p",
                    UseShellExecute = true,
                    Verb = "runas",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(startInfo);

                MessageBox.Show("Регистрация системных шрифтов успешно восстановлена!\n\n" +
                                "Чтобы изменения полностью вступили в силу, обязательно перезагрузите компьютер.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Для восстановления системных шрифтов необходимы права Администратора.",
                                "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось восстановить шрифты: {ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetLimitsButton_Click(object sender, EventArgs e)
        {
            VirusRestrictionResetter.ResetAllSystemRestrictions();
        }

        private void restoreUACButton_Click(object sender, EventArgs e)
        {
            try
            {
                string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";

                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        key.SetValue("EnableLUA", 1, RegistryValueKind.DWord);

                        key.SetValue("ConsentPromptBehaviorAdmin", 5, RegistryValueKind.DWord);

                        key.SetValue("ConsentPromptBehaviorUser", 3, RegistryValueKind.DWord);

                        key.SetValue("PromptOnSecureDesktop", 1, RegistryValueKind.DWord);

                        MessageBox.Show(
                            "Настройки UAC успешно изменены на стандартные!\n\n" +
                            "Внимание: Чтобы изменения вступили в силу, необходимо перезагрузить компьютер.",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show("Не удалось получить доступ к системной ветке реестра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Недостаточно прав для изменения реестра. Запустите программу от Администратора!", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при восстановлении UAC: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetWindowsInfoViaWmi()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption, OSArchitecture FROM Win32_OperatingSystem"))
                {
                    foreach (ManagementObject os in searcher.Get())
                    {
                        string caption = os["Caption"]?.ToString() ?? "Windows";
                        string architecture = os["OSArchitecture"]?.ToString() ?? "";

                        return $"{caption} ({architecture})".Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка WMI: {ex.Message}";
            }
            return "Неизвестная ОС";
        }
    }
}
