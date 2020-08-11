using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSTOMediaPlayer.Word.Services
{
    public interface IMediaService
    {
        void Play();
        void Pause();
        void Stop();
        void StepBack(TimeSpan stepTime);
        void StepForward(TimeSpan stepTime);
    }
}
