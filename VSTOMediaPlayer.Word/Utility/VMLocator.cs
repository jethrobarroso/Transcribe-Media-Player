using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSTOMediaPlayer.Word.Services;
using VSTOMediaPlayer.Word.ViewModel;

namespace VSTOMediaPlayer.Word.Utility
{
    public class VMLocator
    {
        private static IFileBrowser fileBrowser = new FileBrowser();
        private static MediaPlayerViewModel mediaPlayerViewModel;

        public static MediaPlayerViewModel MediaPlayerViewModel 
        { 
            get
            {
                if (mediaPlayerViewModel == null)
                    mediaPlayerViewModel = new MediaPlayerViewModel(fileBrowser);
                return mediaPlayerViewModel;
            } 
        }
    }
}
