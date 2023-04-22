using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSwitcher.Helpers;

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

}
