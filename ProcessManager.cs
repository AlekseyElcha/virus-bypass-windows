using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;

internal static class ProcessManager
{
    private const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
    private const uint PROCESS_SET_INFORMATION = 0x0200;
    private const int ProcessCriticalInformation = 9;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool IsProcessCritical(IntPtr hProcess, ref bool Critical);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetProcessInformation(
        IntPtr hProcess,
        int ProcessInformationClass,
        ref int ProcessInformation,
        uint ProcessInformationSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hObject);


    internal static List<Dictionary<string, string>> GetAllProcesses()
    {
        var result = new List<Dictionary<string, string>>();

        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
        using (var collection = searcher.Get())

        {
            foreach (ManagementObject obj in collection)
            {
                try
                {
                    int pid = Convert.ToInt32(obj["ProcessId"]);
                    string name = obj["Name"]?.ToString() ?? "";
                    string path = obj["ExecutablePath"]?.ToString() ?? "-";

                    long memBytes = obj["WorkingSetSize"] != null ? Convert.ToInt64(obj["WorkingSetSize"]) : 0;
                    string memory = $"{memBytes / 1024 / 1024} MB";
                    string threads = obj["ThreadCount"]?.ToString() ?? "0";

                    string user = "";
                    string[] args = new string[2];
                    int ret = Convert.ToInt32(obj.InvokeMethod("GetOwner", args));
                    if (ret == 0)
                        user = $"{args[1]}\\{args[0]}";

                    string critical = GetProcessCriticality(pid);

                    result.Add(new Dictionary<string, string>
                    {
                        ["Name"] = name,
                        ["PID"] = pid.ToString(),
                        ["Critical"] = critical,
                        ["Path"] = path,
                        ["User"] = user,
                        ["Memory"] = memory,
                        ["Threads"] = threads,
                    });
                }
                catch { }
            }
        }

        return result.OrderBy(p => p["Name"]).ToList();
    }

    private static string GetProcessCriticality(int processId)
    {
        IntPtr hProcess = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, false, processId);
        if (hProcess == IntPtr.Zero) return "-";

        try
        {
            bool isCritical = false;
            if (IsProcessCritical(hProcess, ref isCritical))
            {
                return isCritical ? "Да" : "Нет";
            }
            return "-";
        }
        catch
        {
            return "-";
        }
        finally
        {
            CloseHandle(hProcess);
        }
    }

    internal static bool SetProcessCriticality(int pid, bool isCritical)
    {
        IntPtr hProcess = OpenProcess(PROCESS_SET_INFORMATION, false, pid);
        if (hProcess == IntPtr.Zero) return false;

        try
        {
            int value = isCritical ? 1 : 0;
            return SetProcessInformation(hProcess, ProcessCriticalInformation, ref value, sizeof(int));
        }
        catch
        {
            return false;
        }
        finally
        {
            CloseHandle(hProcess);
        }
    }
}
