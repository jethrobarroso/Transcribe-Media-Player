using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VSTOMediaPlayer.Word.Model;
using VSTOMediaPlayer.Word.MVVM;
using VSTOMediaPlayer.Word.Services;
using VSTOMediaPlayer.Word.Utility;

namespace VSTOMediaPlayer.Word.ViewModel
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MediaPlayerViewModel : BindableBase, IVBAInterop
    {
        private readonly string playImage = "\uf04b";
        private readonly string pauseImage = "\uf04c";
        private string playPauseImageSource;
        private PlaybackState playbackState;
        private IFileBrowser fileBrowser;
        private Track selectedTrack;

        #region Instance Properties
        public string PlayPauseImageSource
        {
            get { return playPauseImageSource; }
            set
            {
                if (value == playPauseImageSource) return;
                playPauseImageSource = value;
                //OnPropertyChanged(nameof(PlayPauseImageSource));
                RaisePropertyChanged();
            }
        }
        public Track SelectedTrack
        {
            get
            {
                return selectedTrack;
            }
            set
            {
                if (selectedTrack != value)
                {
                    selectedTrack = value;

                }
            }
        }
        public TimeSpan MediaTime { get; set; }

        public ICommand OpenFileCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        public ICommand SkipForwardCommand { get; set; }
        public ICommand SkipBackwardCommand { get; set; } 
        public ICommand StopCommand { get; set; }
        #endregion

        #region Subscriber events for Views
        public event EventHandler PlayRequested;
        public event EventHandler PauseRequested;
        public event EventHandler ResumeRequested;
        public event EventHandler SkipForwardRequested;
        public event EventHandler SkipBackwardRequested;
        public event EventHandler StopRequested;
        #endregion

        public MediaPlayerViewModel() : this(new FileBrowser()) { }

        public MediaPlayerViewModel(IFileBrowser fileBrowser)
        {
            playbackState = PlaybackState.Stopped;
            PlayPauseImageSource = playImage;
            LoadCommands();
            this.fileBrowser = fileBrowser;
        }

        public void LoadCommands()
        {
            OpenFileCommand = new RelayCommand(OpenFile, CanOpenFile);
            PlayPauseCommand = new RelayCommand(PlayFile, CanPlayFile);
            SkipForwardCommand = new RelayCommand(SkipForward, CanSkipForward);
            SkipBackwardCommand = new RelayCommand(SkipBackward, CanSkipBackward);
            StopCommand = new RelayCommand(StopFile, CanStopFile);
        }

        private bool CanStopFile(object obj)
        {
            return HasTrack();
        }

        private void StopFile(object obj)
        {
            StopRequested?.Invoke(this, new EventArgs());
        }

        private bool CanSkipBackward(object obj)
        {
            return HasTrack();
        }

        private void SkipBackward(object obj)
        {
            SkipBackwardRequested?.Invoke(this, new EventArgs());
        }

        private bool CanSkipForward(object obj)
        {
            return HasTrack();
        }

        private void SkipForward(object obj)
        {
            SkipForwardRequested?.Invoke(this, new EventArgs());
        }

        private void PlayFile(object obj)
        {
            if (playbackState == PlaybackState.Stopped)
            {
                PlayRequested?.Invoke(this, new EventArgs());
                playbackState = PlaybackState.Playing;
                PlayPauseImageSource = pauseImage;
            }
            else if (playbackState == PlaybackState.Playing)
            {
                PauseRequested?.Invoke(this, new EventArgs());
                playbackState = PlaybackState.Paused;
                PlayPauseImageSource = playImage;
            }
            else
            {
                ResumeRequested?.Invoke(this, new EventArgs());
                playbackState = PlaybackState.Playing;
                PlayPauseImageSource = pauseImage;
            }

        }

        private bool CanPlayFile(object obj)
        {
            return HasTrack();
        }

        private void OpenFile(object obj)
        {
            SelectedTrack = fileBrowser.GetTrack();

            if (fileBrowser.FileChanged == true)
            {
                StopFile(this);
            }
        }

        private bool CanOpenFile(object obj)
        {
            return true;
        }


        private bool HasTrack()
        {
            if (SelectedTrack != null)
                return true;
            return false;
        }

        #region VBA Calling methods

        public void VBAPlayPause()
        {
            PlayFile(this);
        }

        #endregion
    }
}
