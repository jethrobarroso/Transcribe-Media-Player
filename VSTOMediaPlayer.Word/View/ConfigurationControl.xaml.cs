﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VSTOMediaPlayer.Word.View
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationControl : UserControl
    {
        public ConfigurationControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var doc = Globals.ThisAddIn.Application.ActiveDocument;
            var selection = doc.Application.Selection;

            selection.TypeText("testing123");
        }
    }
}
