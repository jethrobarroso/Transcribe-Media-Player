using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word;
using VSTOMediaPlayer.Word.Model;

namespace VSTOMediaPlayer.Word.Services
{
    public class FileBrowser : IFileBrowser
    {
        private MediaTrack selectedTrack;

        public bool FileChanged { get; set; } = false;

        public MediaTrack GetTrack()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV"
            };

            if (dlg.ShowDialog() == true)
            {
                selectedTrack = new MediaTrack(dlg.FileName);
                FileChanged = true;
            }
            else
                FileChanged = false;

            return selectedTrack;
        }
    }
}
