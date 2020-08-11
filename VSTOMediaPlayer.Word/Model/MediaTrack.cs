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
    public class MediaTrack
    {
        public MediaTrack(string location)
        {
            if (!File.Exists(location))
                throw new FileNotFoundException("Media file could not be located", location);
            Location = location;
        }

        public string FriendlyName => Path.GetFileName(Location);

        public string FileType => Path.GetExtension(Location);

        public bool IsVideo { get; set; }

        public string Location { get; private set; }

        public TimeSpan TrackDuration
        {
            get
            {
                using (var shell = ShellObject.FromParsingName(Location))
                {
                    IShellProperty prop = shell.Properties.System.Media.Duration;
                    var t = (ulong)prop.ValueAsObject;
                    return TimeSpan.FromTicks((long)t);
                }
            }
        }

        public override string ToString() => Location;
    }
}
