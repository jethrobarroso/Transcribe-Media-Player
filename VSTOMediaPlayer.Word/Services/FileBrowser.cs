using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word.Model;

namespace VSTOMediaPlayer.Word.Services
{
    public class FileBrowser : IFileBrowser
    {
        private Track selectedTrack;

        public bool FileChanged { get; set; } = false;

        public Track GetTrack()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == true)
            {
                selectedTrack = new Track(dlg.FileName);
                FileChanged = true;
            }
            else
                FileChanged = false;

            return selectedTrack;
        }
    }
}
