using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using VSTOMediaPlayer.Word.View;
using Microsoft.Office.Tools;
using VSTOMediaPlayer.Word.Utility;
using VSTOMediaPlayer.Word.ViewModel;
using System.Windows;
using Microsoft.Office.Tools.Ribbon;

namespace VSTOMediaPlayer.Word
{
    public partial class ApplicationRibbon
    {
        private TaskPane taskPane;
        private CustomTaskPane customTaskPane;
        private MediaPlayerViewModel viewModel = VMLocator.MediaPlayerViewModel;

        private void ApplicationRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            if(customTaskPane == null)
            {
                taskPane = new TaskPane();
                customTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPane, "Media Player");
                customTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionTop;
            }
            if (!customTaskPane.Visible) customTaskPane.Visible = true;
        }
    }
}
