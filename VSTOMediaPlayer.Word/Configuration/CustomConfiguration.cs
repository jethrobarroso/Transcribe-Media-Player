using NHotkey;
using NHotkey.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VSTOMediaPlayer.Word.Properties;

namespace VSTOMediaPlayer.Word.Configuration
{
    public class CustomConfiguration : ICustomConfiguration
    {
        private readonly IRelayConfig _config;
        private Dictionary<string, KeyGesture> _keys;

        public CustomConfiguration(IRelayConfig config)
        {
            _config = config;
            _keys = new Dictionary<string, KeyGesture>();
        }

        public Dictionary<string, KeyGesture> RegisteredKeys => _keys;

        public bool RegisterTogglePlayPause(string value = null)
        {
            //HotkeyManager.Current.AddOrReplace()

            return true;
        }
    }
}
