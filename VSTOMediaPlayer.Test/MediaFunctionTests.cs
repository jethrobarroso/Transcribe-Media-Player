using MahApps.Metro.IconPacks;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using VSTOMediaPlayer.Word.Services;
using VSTOMediaPlayer.Word.ViewModel;

namespace VSTOMediaPlayer.Test
{
    public class MediaFunctionTests
    {
        private Mock<IFileBrowser> _mockFileBrowser;
        private Mock<IMediaService> _mockMediaService;
        private MediaPlayerViewModel _playerViewModel;
        private List<string> _propertyList;

        [SetUp]
        public void InitialSetup()
        {
            _mockFileBrowser = new Mock<IFileBrowser>();
            _mockMediaService = new Mock<IMediaService>();
            _playerViewModel = new MediaPlayerViewModel(_mockFileBrowser.Object);
            _playerViewModel.LoadedCommand.Execute(_mockMediaService.Object);
            _propertyList = new List<string>();
            _playerViewModel.PropertyChanged += (s, e) => _propertyList.Add(e.PropertyName);
        }


        [Test]
        public void IsPlaying_Is_False_On_Load()
        {
            Assert.That(_playerViewModel.IsPlaying, Is.False);
        }

        [Test]
        public void IsPlaying_Phases()
        {
            _playerViewModel.LoadedCommand.Execute(_mockMediaService.Object);
            _playerViewModel.RegularPlayPauseCommand.Execute(null);

            Assert.That(_playerViewModel.IsPlaying, Is.True);
            Assert.That(_propertyList, Has.Exactly(1).EqualTo("IsPlaying"));

            _playerViewModel.RegularPlayPauseCommand.Execute(null);

            Assert.That(_playerViewModel.IsPlaying, Is.False);
            Assert.That(_propertyList, Has.Exactly(2).EqualTo("IsPlaying"));
            _mockMediaService.Verify(m => m.Play(), Times.Once);
            _mockMediaService.Verify(m => m.Pause(), Times.Once);
        }

        [Test]
        public void Should_Show_Play_Icon_On_Startup()
        {
            Assert.That(_playerViewModel.PlayPauseImage, Is.EqualTo(PackIconMaterialKind.Play));
            _mockMediaService.Verify(m => m.Play(), Times.Never);
        }

        [Test]
        public void Should_Toggle_Icon_When_Play_Pause()
        {
            // Playing
            _playerViewModel.RegularPlayPauseCommand.Execute(null);

            Assert.That(_playerViewModel.PlayPauseImage, Is.EqualTo(PackIconMaterialKind.Pause));
            Assert.That(_propertyList, Has.Exactly(1).EqualTo("PlayPauseImage"));

            // Pausing
            _playerViewModel.RegularPlayPauseCommand.Execute(null);

            Assert.That(_playerViewModel.PlayPauseImage, Is.EqualTo(PackIconMaterialKind.Play));
            Assert.That(_propertyList, Has.Exactly(2).EqualTo("PlayPauseImage"));
        }
    }
}