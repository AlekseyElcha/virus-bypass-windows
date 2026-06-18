using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirusBypass
{
    internal static class CmdLineManagement
    {
        internal static Dictionary<string, string> GetCmdLineValues()
        {
            var result = new Dictionary<string, string>();

            string setupKeyPath = @"SYSTEM\Setup";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var key = baseKey.OpenSubKey(setupKeyPath, writable: false))
            {
                if (key != null)
                {
                    result["CmdLine"] = key.GetValue("CmdLine")?.ToString() ?? "";
                    result["SetupType"] = key.GetValue("SetupType")?.ToString() ?? "";
                }
            }

            string policyKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var key = baseKey.OpenSubKey(policyKeyPath, writable: false))
            {
                if (key != null)
                    result["EnableCursorSuppression"] = key.GetValue("EnableCursorSuppression")?.ToString() ?? "";
            }

            return result;

        }

        internal static void EnableCursorCmdLine(string isEnabledString)
        {
            int.TryParse(isEnabledString, out int isEnabled);
            try
            {
                int regValue = isEnabled;

                if (regValue != 0 && regValue != 1)
                {
                    MessageBox.Show("Параметр EnableCursorSuppression может принимать значения только 0 и 1!");
                    return;
                }

                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                {
                    if (key != null)
                    {
                        key.SetValue("EnableCursorSuppression", regValue, Microsoft.Win32.RegistryValueKind.DWord);
                        if (isEnabled == 1)
                        {
                            MessageBox.Show("Курсор в CmdLine включен!");
                        }
                        else
                        {
                            MessageBox.Show("Курсор в CmdLine выключен!");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Запустите программу от имени Администратора для изменения этого параметра!", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить параметр: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
