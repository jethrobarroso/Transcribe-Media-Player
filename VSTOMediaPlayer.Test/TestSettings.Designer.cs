﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VSTOMediaPlayer.Test {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
    internal sealed partial class TestSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TestSettings defaultInstance = ((TestSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TestSettings())));
        
        public static TestSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F1,1")]
        public string TogglePlayPause {
            get {
                return ((string)(this["TogglePlayPause"]));
            }
            set {
                this["TogglePlayPause"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F2,5")]
        public string SkipBack {
            get {
                return ((string)(this["SkipBack"]));
            }
            set {
                this["SkipBack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F3,5")]
        public string SkipForward {
            get {
                return ((string)(this["SkipForward"]));
            }
            set {
                this["SkipForward"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F4,1")]
        public string PlayUntilRelease {
            get {
                return ((string)(this["PlayUntilRelease"]));
            }
            set {
                this["PlayUntilRelease"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F9,5,1")]
        public string PlayRepeat {
            get {
                return ((string)(this["PlayRepeat"]));
            }
            set {
                this["PlayRepeat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F10,3")]
        public string PlayWait {
            get {
                return ((string)(this["PlayWait"]));
            }
            set {
                this["PlayWait"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F6")]
        public string VolumeUp {
            get {
                return ((string)(this["VolumeUp"]));
            }
            set {
                this["VolumeUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F5")]
        public string VolumeDown {
            get {
                return ((string)(this["VolumeDown"]));
            }
            set {
                this["VolumeDown"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F8")]
        public string PlaybackUp {
            get {
                return ((string)(this["PlaybackUp"]));
            }
            set {
                this["PlaybackUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("F7")]
        public string PlaybackDown {
            get {
                return ((string)(this["PlaybackDown"]));
            }
            set {
                this["PlaybackDown"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>{$time_short} Shrot time</string>
  <string>{$time_long} Long time</string>
  <string>{$date_short} Date short</string>
  <string>{$date_long} Date long</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Snippets {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Snippets"]));
            }
            set {
                this["Snippets"] = value;
            }
        }
    }
}