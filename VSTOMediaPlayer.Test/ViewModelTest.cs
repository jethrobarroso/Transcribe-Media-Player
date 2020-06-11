using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VSTOMediaPlayer.Word.Model;
using VSTOMediaPlayer.Word.Utility;
using VSTOMediaPlayer.Word.ViewModel;

namespace VSTOMediaPlayer.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MediaPlayerViewModel viewModel1 = VMLocator.MediaPlayerViewModel;
            MediaPlayerViewModel viewModel2 = VMLocator.MediaPlayerViewModel;

            viewModel1.SelectedTrack = new Track(@"C:\My_Code\Projects\VSTOMediaPlayer\VSTOMediaPlayer.Word\sample_video.mp4");

            Assert.AreEqual(viewModel2.SelectedTrack, viewModel1.SelectedTrack);
        }

        [TestMethod]
        public void InstanceNotEqual()
        {
            Track t1 = new Track(@"C:\My_Code\Projects\VSTOMediaPlayer\VSTOMediaPlayer.Word\sample_video.mp4)");
            Track t2 = new Track(@"C:\My_Code\Projects\VSTOMediaPlayer\VSTOMediaPlayer.Word\sample_video.mp4");

            Assert.AreNotEqual(t1, t2);
        }
    }
}
