using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VSTOMediaPlayer.Word.Services;
using VSTOMediaPlayer.Word.ViewModel;

namespace VSTOMediaPlayer.Word.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MediaPlayerControl : UserControl, IMediaService
    {
        public MediaPlayerControl()
        {
            InitializeComponent();
        }

        public void Pause()
        {
            mePlayer.Pause();
        }

        public void Play()
        {
            mePlayer.Play();
        }

        public void StepBack(TimeSpan stepTime)
        {
            mePlayer.Position -= stepTime;
        }

        public void StepForward(TimeSpan stepTime)
        {
            mePlayer.Position += stepTime;
        }

        public void Stop()
        {
            mePlayer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confWindow = new ConfigurationWindow();
            confWindow.Show();
        }
    }
}
