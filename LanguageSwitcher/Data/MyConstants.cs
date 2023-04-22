using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSwitcher.Data;

internal static class MyConstants
{
    internal enum LANGTOGGLE_VALUES
    {
        ALT_SHIFT = 1,
        CTRL_SHIFT = 2,
        NONE = 3
    };



    internal const uint WM_INPUTLANGCHANGEREQUEST = 0x50;
    //private const uint KLF_ACTIVATE = 0x00000001;
    internal static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);



}
