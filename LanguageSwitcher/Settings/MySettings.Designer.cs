﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LanguageSwitcher.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
    internal sealed partial class MySettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MySettings defaultInstance = ((MySettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings())));
        
        public static MySettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int Language_Toggle {
            get {
                return ((int)(this["Language_Toggle"]));
            }
            set {
                this["Language_Toggle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int LanguageIndex1 {
            get {
                return ((int)(this["LanguageIndex1"]));
            }
            set {
                this["LanguageIndex1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int LanguageIndex2 {
            get {
                return ((int)(this["LanguageIndex2"]));
            }
            set {
                this["LanguageIndex2"] = value;
            }
        }
    }
}
