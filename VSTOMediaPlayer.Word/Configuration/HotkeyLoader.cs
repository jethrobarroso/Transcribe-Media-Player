using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word.Properties;

namespace VSTOMediaPlayer.Word.Configuration
{
    public class HotkeyLoader
    {
        private readonly ApplicationSettingsBase _settings;

        public HotkeyLoader(ApplicationSettingsBase settings)
        {
            _settings = settings;
        }


    }
}
