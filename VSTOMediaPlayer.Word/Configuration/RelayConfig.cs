using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word.Properties;

namespace VSTOMediaPlayer.Word.Configuration
{
    public class RelayConfig : IRelayConfig
    {            
        public string TogglePlayPause
        {
            get { return Settings.Default.TogglePlayPause; }
            set { Settings.Default.TogglePlayPause = value; }
        }

        public string SkipBack
        {
            get { return Settings.Default.SkipBack; }
            set { Settings.Default.SkipBack = value; }
        }

        public string SkipForward
        {
            get { return Settings.Default.SkipForward; }
            set { Settings.Default.SkipForward = value; }
        }

        public string PlayUntilRelease
        {
            get { return Settings.Default.PlayUntilRelease; }
            set { Settings.Default.PlayUntilRelease = value; }
        }

        public string PlayRepeat
        {
            get { return Settings.Default.PlayRepeat; }
            set { Settings.Default.PlayRepeat = value; }
        }

        public string PlayWait
        {
            get { return Settings.Default.PlayWait; }
            set { Settings.Default.PlayWait = value; }
        }

        public string VolumeUp
        {
            get { return Settings.Default.VolumeUp; }
            set { Settings.Default.VolumeUp = value; }
        }

        public string VolumeDown
        {
            get { return Settings.Default.VolumeDown; }
            set { Settings.Default.VolumeDown = value; }
        }

        public string PlaybackUp
        {
            get { return Settings.Default.PlaybackUp; }
            set { Settings.Default.PlaybackUp = value; }
        }

        public string PlaybackDown
        {
            get { return Settings.Default.PlaybackDown; }
            set { Settings.Default.PlaybackDown = value; }
        }

        public StringCollection Snippets
        {
            get { return Settings.Default.Snippets; }
            set { Settings.Default.Snippets = value; }
        }
    }
}
