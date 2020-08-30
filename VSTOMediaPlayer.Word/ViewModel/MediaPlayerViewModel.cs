using MahApps.Metro.IconPacks;
using Microsoft.WindowsAPICodePack.Shell.Interop;
using NHotkey;
using NHotkey.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VSTOMediaPlayer.Word;
using VSTOMediaPlayer.Word.Model;
using VSTOMediaPlayer.Word.MVVM;
using VSTOMediaPlayer.Word.Properties;
using VSTOMediaPlayer.Word.Services;
using VSTOMediaPlayer.Word.Utility;

namespace VSTOMediaPlayer.Word.ViewModel
{
    public class MediaPlayerViewModel : BindableBase
    {
        private readonly PackIconMaterialKind _playImage = PackIconMaterialKind.Play;
        private readonly PackIconMaterialKind _pauseImage = PackIconMaterialKind.Pause;

        private IMediaService _mediaService;
        private string _mediaPath;
        private bool _isPlaying;
        private ObservableCollection<string> _fileHistory;
        private PackIconMaterialKind _playPauseImage;
        private readonly IFileBrowser _fileBrowser;

        public MediaPlayerViewModel(IFileBrowser fileBrowser)
        {
            InitialiseCommands();
            _fileBrowser = fileBrowser;

            PlayPauseImage = _playImage;
        }

        #region Properties
        public IMediaService MediaService
        {
            get { return _mediaService; }
            set { SetProperty(ref _mediaService, value); }
        }

        public ICommand LoadedCommand { get; set; }
        public ICommand RegularPlayPauseCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand StepForwardCommand { get; set; }
        public ICommand StepBackCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }

        public string MediaPath
        {
            get { return _mediaPath; }
            set { SetProperty(ref _mediaPath, value); }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { SetProperty(ref _isPlaying, value); }
        }

        public ObservableCollection<string> FileHistory
        {
            get { return _fileHistory; }
            set { SetProperty(ref _fileHistory, value); }
        }

        public PackIconMaterialKind PlayPauseImage
        {
            get { return _playPauseImage; }
            set { SetProperty(ref _playPauseImage, value); }
        }
        #endregion

        #region Command callbacks
        private void StepBack(object obj)
        {
            MediaService.StepBack(TimeSpan.FromSeconds(2));
        }

        private void StepForward(object obj)
        {
            MediaService.StepForward(TimeSpan.FromSeconds(2));
        }

        private void Stop(object obj)
        {
            MediaService.Stop();
        }

        private void PlayPause(object obj)
        { 
            if(IsPlaying)
            {
                PlayPauseImage = _playImage;
                MediaService.Pause();
                IsPlaying = false;
            }
            else
            {
                PlayPauseImage = _pauseImage;
                MediaService.Play();
                IsPlaying = true;
            }
        }

        private void Loaded(object obj) => MediaService = obj as IMediaService;

        private void LoadMedia(object obj)
        {
            MediaTrack track = _fileBrowser.GetTrack();
            MediaPath = track.Location;
        }
        #endregion

        private void InitialiseCommands()
        {
            LoadedCommand = new RelayCommand(Loaded);
            RegularPlayPauseCommand = new RelayCommand(PlayPause);
            StopCommand = new RelayCommand(Stop);
            StepForwardCommand = new RelayCommand(StepForward);
            StepBackCommand = new RelayCommand(StepBack);
            OpenFileCommand = new RelayCommand(LoadMedia);
        }
    }
}
