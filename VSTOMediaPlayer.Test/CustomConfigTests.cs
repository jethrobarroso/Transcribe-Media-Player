using Moq;
using NHotkey;
using NHotkey.Wpf;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using VSTOMediaPlayer.Word.Configuration;
using VSTOMediaPlayer.Word.View;

namespace VSTOMediaPlayer.Test
{
    public class CustomConfigTests
    {
        private Mock<IRelayConfig> _mockRelayConfig;

        [OneTimeSetUp]
        public void OneTimeInitialisation()
        {
            _mockRelayConfig = new Mock<IRelayConfig>();
            SetupConfigRelayMock(_mockRelayConfig);
        }
        
        [Test]
        public void RegisterTogglePlayPause_Ok()
        {
            bool isRegistered = false;
            var relayMock = new Mock<IRelayConfig>();
            ICustomConfiguration config = new CustomConfiguration(_mockRelayConfig.Object);
            
            config.RegisterTogglePlayPause();

            Assert.That(isRegistered, Is.True);
        }

        private void SetupConfigRelayMock(Mock<IRelayConfig> mock)
        {
            var snippets = new StringCollection()
            {
                "{$time_short} Shrot time",
                "{$time_long} Long time",
                "{$date_short} Date short",
                "{$date_long} Date long"
            };

            mock.Setup(r => r.TogglePlayPause).Returns("F1,1");
            mock.Setup(r => r.SkipBack).Returns("F2,5");
            mock.Setup(r => r.SkipForward).Returns("F3,5");
            mock.Setup(r => r.PlayUntilRelease).Returns("F4,1");
            mock.Setup(r => r.PlayRepeat).Returns("F9,5,1");
            mock.Setup(r => r.PlayWait).Returns("F10,3");
            mock.Setup(r => r.VolumeUp).Returns("F6");
            mock.Setup(r => r.VolumeDown).Returns("F5");
            mock.Setup(r => r.PlaybackUp).Returns("F8");
            mock.Setup(r => r.PlaybackDown).Returns("F7");
            mock.Setup(r => r.Snippets).Returns(snippets);
        }
    }
}
