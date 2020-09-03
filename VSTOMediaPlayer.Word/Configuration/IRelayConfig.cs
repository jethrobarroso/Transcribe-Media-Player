using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace VSTOMediaPlayer.Word.Configuration
{
    public interface IRelayConfig
    {
        string PlaybackDown { get; set; }
        string PlaybackUp { get; set; }
        string PlayRepeat { get; set; }
        string PlayUntilRelease { get; set; }
        string PlayWait { get; set; }
        string SkipBack { get; set; }
        string SkipForward { get; set; }
        StringCollection Snippets { get; set; }
        string TogglePlayPause { get; set; }
        string VolumeDown { get; set; }
        string VolumeUp { get; set; }
    }
}