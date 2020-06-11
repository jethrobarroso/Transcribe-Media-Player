﻿using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace VSTOMediaPlayer.Word.Tools
{
    public sealed class FreeSlideBehavior : Behavior<Slider>
    {
        private Thumb _thumb;

        private Thumb Thumb
        {
            get
            {
                if (_thumb == null)
                {
                    _thumb = ((Track)AssociatedObject.Template.FindName("PART_Track", AssociatedObject)).Thumb;
                }
                return _thumb;
            }
        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += OnMouseMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= OnMouseMove;
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (args.LeftButton == MouseButtonState.Released) return;
            if (Thumb.IsDragging) return;
            if (!Thumb.IsMouseOver) return;

            Thumb.RaiseEvent(new MouseButtonEventArgs(args.MouseDevice, args.Timestamp, MouseButton.Left)
            {
                RoutedEvent = UIElement.MouseLeftButtonDownEvent
            });

            var slider = (Slider)sender;
            slider.RaiseEvent(new MouseButtonEventArgs(args.MouseDevice, args.Timestamp, MouseButton.Left)
            {
                RoutedEvent = UIElement.MouseLeftButtonDownEvent
            });
        }
    }
}
