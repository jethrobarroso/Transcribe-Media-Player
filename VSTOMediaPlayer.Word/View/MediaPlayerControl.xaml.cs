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
using VSTOMediaPlayer.Word.ViewModel;

namespace VSTOMediaPlayer.Word.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MediaPlayerControl : UserControl
    {
        private bool _isDragTimeSlider = false;
        private MediaPlayerViewModel _vm;
        readonly DispatcherTimer _timer = new DispatcherTimer(DispatcherPriority.Render);

        public MediaPlayerControl()
        {
            InitializeComponent();
            this.Loaded += (ss, ee) =>
            {
                _vm = this.DataContext as MediaPlayerViewModel;
                _vm.PlayRequested += Play;
                _vm.PauseRequested += Pause;
                _vm.ResumeRequested += Resume;
                _vm.SkipForwardRequested += SkipForward;
                _vm.SkipBackwardRequested += SkipBackward;
                mePlayer.MediaOpened += OnOpenMedia;
            };

            _timer.Interval = TimeSpan.FromSeconds(0.1);
            _timer.Tick += MediaTick;
            _timer.Start();
            sliderTimeLine.Value = 0;
            sliderTimeLine.Minimum = 0;
            sliderTimeLine.Maximum = 0;
            labelTimeRemaining.Content = "00:00:00";
        }

        private void OnOpenMedia(object sender, RoutedEventArgs e)
        {
            sliderTimeLine.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void MediaTick(object sender, EventArgs e)
        {
            if (!_isDragTimeSlider)
                sliderTimeLine.Value = mePlayer.Position.TotalMilliseconds;
        }

        public void Pause(object sender, EventArgs args)
        {
            _timer.Stop();
            mePlayer.Pause();
        }

        public void Play(object sender, EventArgs args)
        {
            _timer.Start();
            mePlayer.Source = new Uri(_vm.SelectedTrack.Location);
            mePlayer.Play();
        }

        public void Resume(object sender, EventArgs args)
        {
            _timer.Start();
            mePlayer.Play();
        }

        public void SkipBackward(object sender, EventArgs args)
        {
            if (mePlayer.Position.TotalSeconds <= 5)
            {
                mePlayer.Position = TimeSpan.FromSeconds(0);
                labelTimeRemaining.Content = "00:00:00";
            }
            else
            {
                mePlayer.Position -= TimeSpan.FromSeconds(5);
            }
        }

        public void SkipForward(object sender, EventArgs args)
        {
            mePlayer.Position += TimeSpan.FromSeconds(5);
        }

        public void Stop(object sender, EventArgs args)
        {
            _timer.Stop();
            mePlayer.Stop();
            sliderTimeLine.Value = 0;
            labelTimeRemaining.Content = "00:00:00";
        }

        private void SliderTimeLine_DragStarted(object sender, DragStartedEventArgs e)
        {
            _isDragTimeSlider = true;
        }

        private void SliderTimeLine_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            _isDragTimeSlider = false;
            mePlayer.Position = TimeSpan.FromMilliseconds(sliderTimeLine.Value);
        }

        private void SliderTimeLine_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!_timer.IsEnabled)
            {
                mePlayer.Position = TimeSpan.FromMilliseconds(sliderTimeLine.Value);
                _timer.Start();
            }
        }

        private void SliderTimeLine_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_timer.IsEnabled)
                _timer.Stop();

            Debug.WriteLine(TimeSpan.FromMilliseconds(sliderTimeLine.Value).ToString(@"hh\:mm\:ss"));
        }

        private void SliderTimeLine_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelTimeRemaining.Content = TimeSpan.FromMilliseconds(sliderTimeLine.Value).ToString(@"hh\:mm\:ss");
        }
    }
}
