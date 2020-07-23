using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word.MVVM;

namespace VSTOMediaPlayer.Word
{
    public class MediaTrack : BindableBase
    {
        private string _location;

        public MediaTrack(string location)
        {
            if (!File.Exists(location))
                throw new FileNotFoundException("Media file could not be located", _location);
            _location = location;
        }

        public string FriendlyName => Path.GetFileName(_location);

        public string FileType => Path.GetExtension(_location);

        public bool IsVideo { get; set; }

        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        public TimeSpan TrackDuration
        {
            get
            {
                using (var shell = ShellObject.FromParsingName(_location))
                {
                    IShellProperty prop = shell.Properties.System.Media.Duration;
                    var t = (ulong)prop.ValueAsObject;
                    return TimeSpan.FromTicks((long)t);
                }
            }
        }

        public override string ToString() => _location;
    }
}
