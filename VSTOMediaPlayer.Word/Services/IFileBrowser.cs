using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word;
using VSTOMediaPlayer.Word.Model;

namespace VSTOMediaPlayer.Word.Services
{
    public interface IFileBrowser
    {
        bool FileChanged { get; set; }
        MediaTrack GetTrack();
    }
}
