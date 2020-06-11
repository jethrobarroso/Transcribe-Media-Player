using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VSTOMediaPlayer.Word.Services
{
    [ComVisible(true)]
    public interface IVBAInterop
    {
        void VBAPlayPause();
    }
}
