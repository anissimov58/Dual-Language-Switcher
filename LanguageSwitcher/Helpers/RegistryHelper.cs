using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDS.Helpers;

public static class RegistryHelper
{
    public static string? GetRegistryValue(string keyPath, string valueName)
    {
        string? value = string.Empty;
        using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(keyPath))
        {
            if (key != null)
            {
                value = key.GetValue(valueName) as string;
            }
            else
            {
                throw new System.ArgumentNullException("value");
            }
        }
        return value;
    }

    public static void SetRegistryValue(string keyPath, string valueName, string value)
    {
        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
        {
            key.SetValue(valueName, value, RegistryValueKind.String);
        }
    }

    public static int Get_Language_Toggle_Value()
    {
        string keyPath = @"Keyboard Layout\Toggle";
        string valueName = @"Language Hotkey";
        string? value = string.Empty;
        using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(keyPath))
        {
            if (key != null)
            {
                value = key.GetValue(valueName) as string;
            }
        }
        return Int32.TryParse(value, out int result)? result : -1 ;
    }

    public static void Set_Language_Toggle_Value(int value)
    {
        string keyPath = @"Keyboard Layout\Toggle";
        string valueName = @"Language Hotkey";
        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
        {
            key.SetValue(valueName, value, RegistryValueKind.String);
        }
    }

    public static void Set_EnableOnStartUp() {
        // Add a registry key to the Windows registry to make the application start automatically on Windows startup
        RegistryKey? registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (registryKey != null)
        {
            registryKey.SetValue("DLS", Application.ExecutablePath);
        }
        else {
            MessageBox.Show("Error enabling automatic startup for this application. Sorry(");
        }
    }


    public static void Set_DisableOnStartUp()
    {
        // Add a registry key to the Windows registry to make the application start automatically on Windows startup
        RegistryKey? registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        if (registryKey != null)
        {
            registryKey.DeleteValue("DLS", false);
        }
        else
        {
            MessageBox.Show("Error disabling automatic startup for this application. Sorry(");
        }
    }

}
