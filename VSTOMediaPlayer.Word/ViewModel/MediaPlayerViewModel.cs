using MahApps.Metro.IconPacks;
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
    public class MediaPlayerViewModel : BindableBase
    {
        private readonly PackIconMaterialKind _playImage = PackIconMaterialKind.Play;
        private readonly PackIconMaterialKind _pauseImage = PackIconMaterialKind.Pause;
        private PackIconMaterialKind _playPauseImageSource;
        private PlaybackState _playbackState;
        private IFileBrowser _fileBrowser;
        private Track _selectedTrack;

        #region Subscriber events for Views
        public event EventHandler PlayRequested;
        public event EventHandler PauseRequested;
        public event EventHandler ResumeRequested;
        public event EventHandler SkipForwardRequested;
        public event EventHandler SkipBackwardRequested;
        public event EventHandler StopRequested;
        #endregion

        #region Bindable properties
        public PackIconMaterialKind PlayPauseImageSource
        {
            get { return _playPauseImageSource; }
            set
            {
                if (value == _playPauseImageSource) return;
                _playPauseImageSource = value;
                //OnPropertyChanged(nameof(PlayPauseImageSource));
                RaisePropertyChanged();
            }
        }
        public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set { SetProperty(ref _selectedTrack, value); }
        }
        public TimeSpan MediaTime { get; set; }

        public ICommand OpenFileCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        public ICommand SkipForwardCommand { get; set; }
        public ICommand SkipBackwardCommand { get; set; } 
        public ICommand StopCommand { get; set; }
        #endregion

        public MediaPlayerViewModel(IFileBrowser fileBrowser)
        {
            _playbackState = PlaybackState.Stopped;
            PlayPauseImageSource = _playImage;
            LoadCommands();
            this._fileBrowser = fileBrowser;
        }

        public void LoadCommands()
        {
            OpenFileCommand = new RelayCommand(OpenFile);
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
            if (_playbackState == PlaybackState.Stopped)
            {
                PlayRequested?.Invoke(this, new EventArgs());
                _playbackState = PlaybackState.Playing;
                PlayPauseImageSource = _pauseImage;
            }
            else if (_playbackState == PlaybackState.Playing)
            {
                PauseRequested?.Invoke(this, new EventArgs());
                _playbackState = PlaybackState.Paused;
                PlayPauseImageSource = _playImage;
            }
            else
            {
                ResumeRequested?.Invoke(this, new EventArgs());
                _playbackState = PlaybackState.Playing;
                PlayPauseImageSource = _pauseImage;
            }

        }

        private bool CanPlayFile(object obj)
        {
            return HasTrack();
        }

        private void OpenFile(object obj)
        {
            SelectedTrack = _fileBrowser.GetTrack();

            if (_fileBrowser.FileChanged == true)
            {
                StopFile(this);
            }
        }

        private bool HasTrack()
        {
            if (SelectedTrack != null)
                return true;
            return false;
        }
    }
}
