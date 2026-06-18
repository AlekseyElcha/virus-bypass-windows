using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System.Collections.Generic;
using System;
using System.Text;

namespace VirusBypass
{
    internal static class AutoStartups
    {
        internal static Dictionary<string, Dictionary<string, string>> GetRunRunOnce()
        {
            var result = new Dictionary<string, Dictionary<string, string>>();

            string[] keyPaths = new[]
            {
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce",
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run",
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\RunOnce",
    };

            RegistryHive[] hives = { RegistryHive.LocalMachine, RegistryHive.CurrentUser };

            foreach (var hive in hives)
            {
                var view = hive == RegistryHive.LocalMachine ? RegistryView.Registry64 : RegistryView.Default;
                using var baseKey = RegistryKey.OpenBaseKey(hive, view);
                string hiveName = hive == RegistryHive.LocalMachine ? "HKLM" : "HKCU";

                foreach (var keyPath in keyPaths)
                {
                    if (keyPath.Contains("WOW6432Node") && hive != RegistryHive.LocalMachine)
                        continue;

                    using var subKey = baseKey.OpenSubKey(keyPath, writable: false);
                    if (subKey == null) continue;

                    string fullPath = $"{hiveName}\\{keyPath}";
                    var entries = new Dictionary<string, string>();

                    foreach (var valueName in subKey.GetValueNames())
                    {
                        string? value = subKey.GetValue(valueName)?.ToString();
                        entries[valueName] = value ?? string.Empty;
                    }

                    if (entries.Count > 0)
                        result[fullPath] = entries;
                }
            }

            return result;
        }

        internal static List<Dictionary<string, string>> GetScheduledTasks()
        {
            var result = new List<Dictionary<string, string>>();

            using var ts = new TaskService();

            void ScanFolder(TaskFolder folder)
            {
                foreach (var task in folder.Tasks)
                {
                    result.Add(new Dictionary<string, string>
                    {
                        ["Name"] = task.Name,
                        ["Path"] = task.Path,
                        ["Status"] = task.State.ToString(),
                        ["LastRun"] = task.LastRunTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        ["NextRun"] = task.NextRunTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        ["Author"] = task.Definition.RegistrationInfo.Author ?? "",
                        ["Enabled"] = task.Enabled.ToString(),
                    });
                }

                foreach (TaskFolder subFolder in folder.SubFolders)
                    ScanFolder(subFolder);
            }

            ScanFolder(ts.RootFolder);

            return result;
        }

        internal static Dictionary<string, string> GetWinlogonSettings()
        {
            var result = new Dictionary<string, string>();

            string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

            using var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using var key = baseKey.OpenSubKey(keyPath, writable: false);
            if (key == null) return result;

            foreach (var valueName in key.GetValueNames())
            {
                string? value = key.GetValue(valueName)?.ToString();
                result[valueName] = value ?? string.Empty;
            }

            return result;
        }

        internal static Dictionary<string, string> GetWinlogonCmdLine()
        {
            var result = new Dictionary<string, string>();

            string keyPath = @"SYSTEM\Setup";

            using var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using var key = baseKey.OpenSubKey(keyPath, writable: false);
            if (key == null) return result;

            string[] interestingKeys = { "CmdLine", "SetupType" };

            foreach (var name in interestingKeys)
            {
                string? value = key.GetValue(name)?.ToString();
                result[name] = value ?? string.Empty;
            }

            return result;
        }

        internal static void SetWinlogonValue(string valueName, string newValue)
        {
            string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

            using var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using var key = baseKey.OpenSubKey(keyPath, writable: true);
            if (key == null) return;

            key.SetValue(valueName, newValue, RegistryValueKind.String);
        }

        internal static void SetCmdlineValue(string valueName, string newValue)
        {
            string keyPath = @"SYSTEM\Setup";

            if (valueName == "SetupType")
            {
                if (newValue != "1" && newValue != "2" && newValue != "0")
                {
                    MessageBox.Show("Параметр SetupType может принимать значения 0, 1 или 2!");
                    return;
                }
                int.Parse(newValue);
            }

            using var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using var key = baseKey.OpenSubKey(keyPath, writable: true);
            if (key == null) return;

            key.SetValue(valueName, newValue, RegistryValueKind.String);
        }

        internal static void DeleteScheduledTask(string taskPath)
        {
            using var ts = new TaskService();
            ts.RootFolder.DeleteTask(taskPath, false);
        }

        internal static void DeleteRunValue(string valueName)
        {
            string[] keyPaths = new[]
            {
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
        @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce",
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run",
        @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\RunOnce",
    };

            RegistryHive[] hives = { RegistryHive.LocalMachine, RegistryHive.CurrentUser };

            foreach (var hive in hives)
            {
                var view = hive == RegistryHive.LocalMachine ? RegistryView.Registry64 : RegistryView.Default;
                using var baseKey = RegistryKey.OpenBaseKey(hive, view);

                foreach (var keyPath in keyPaths)
                {
                    if (keyPath.Contains("WOW6432Node") && hive != RegistryHive.LocalMachine)
                        continue;

                    using var key = baseKey.OpenSubKey(keyPath, writable: true);
                    if (key == null) continue;

                    if (key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName);
                        return;
                    }
                }
            }
        }
    }
}
