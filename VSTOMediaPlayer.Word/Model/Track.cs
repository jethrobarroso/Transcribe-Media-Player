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

namespace VSTOMediaPlayer.Word.Model
{
    public class Track : BindableBase
    {
        private string _location;

        public Track(string location)
        {
            _location = location;
        }

        public string FriendlyName
        {
            get { return Path.GetFileName(_location); }
        }

        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        public string FileType
        {
            get { return Path.GetExtension(_location); }
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

        public override string ToString()
        {
            return _location;
        }
    }
}
