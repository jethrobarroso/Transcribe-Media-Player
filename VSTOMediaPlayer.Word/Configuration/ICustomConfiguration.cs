using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Windows.Input;

namespace VSTOMediaPlayer.Word.Configuration
{
    public interface ICustomConfiguration
    {
        Dictionary<string, KeyGesture> RegisteredKeys { get; }

        bool RegisterTogglePlayPause(string value = null);
    }
}