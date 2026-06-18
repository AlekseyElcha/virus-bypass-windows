using System;
using Microsoft.Win32;
using System.Diagnostics;

internal static class VirusRestrictionResetter
{
    internal static void ResetAllSystemRestrictions()
    {
        ResetRegistryPolicies();
        ResetImageFileExecutionOptions();
        ResetFileAssociations();
        RestartExplorer();
    }

    private static void ResetRegistryPolicies()
    {
        string[] policyPaths = new string[]
        {
            @"Software\Microsoft\Windows\CurrentVersion\Policies\System",
            @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer",
            @"Software\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop"
        };

        string[] valuesToDelete = new string[]
        {
            "DisableTaskMgr",
            "DisableRegistryTools",
            "DisableCMD",
            "NoRun",
            "NoControlPanel",
            "NoWinKeys",
            "NoClose",
            "NoViewContextMenu"
        };

        RegistryKey[] roots = { Registry.CurrentUser, Registry.LocalMachine };

        foreach (var root in roots)
        {
            foreach (var path in policyPaths)
            {
                try
                {
                    using (RegistryKey key = root.OpenSubKey(path, true))
                    {
                        if (key == null) continue;

                        foreach (var value in valuesToDelete)
                        {
                            if (key.GetValue(value) != null)
                            {
                                key.DeleteValue(value);
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    //
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
    }

    private static void ResetImageFileExecutionOptions()
    {
        string ifeoPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";

        string[] criticalApps = { "taskmgr.exe", "regedit.exe", "cmd.exe", "explorer.exe", "msconfig.exe" };

        try
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(ifeoPath, true))
            {
                if (key == null) return;

                foreach (var app in criticalApps)
                {
                    using (RegistryKey appKey = key.OpenSubKey(app))
                    {
                        if (appKey != null && appKey.GetValue("Debugger") != null)
                        {
                            key.DeleteSubKeyTree(app);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
    }

    private static void ResetFileAssociations()
    {
        try
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"exefile\shell\open\command", true))
            {
                if (key != null)
                {
                    string currentValue = key.GetValue("")?.ToString();
                    if (currentValue != "\"%1\" %*")
                    {
                        key.SetValue("", "\"%1\" %*");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
    }

    private static void RestartExplorer()
    {
        try
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
                process.WaitForExit();
            }
            Process.Start("explorer.exe");
        }
        catch (Exception ex)
        {
             //
        }
    }
}
