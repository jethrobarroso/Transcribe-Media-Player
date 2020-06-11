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

namespace VSTOMediaPlayer.Word
{
    public partial class ThisAddIn
    {
        private TaskPane taskPane;
        private CustomTaskPane customTaskPane;
        private MediaPlayerViewModel viewModel = VMLocator.MediaPlayerViewModel;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //viewModel = VMLocator.MediaPlayerViewModel;

            InitializeAppResources();

            taskPane = new TaskPane();
            customTaskPane = this.CustomTaskPanes.Add(taskPane, "Media Player");
            customTaskPane.Visible = true;
            customTaskPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionTop;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            if (System.Windows.Application.Current != null)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        protected override object RequestComAddInAutomationService()
        {
            return viewModel;
        }

        /// <summary>
        /// Initialize App.xaml.cs class for application-level xaml resources
        /// </summary>
        private void InitializeAppResources()
        {
            //Ensure the singleton WPF Application is instantiated
            if (System.Windows.Application.Current == null)
            {
                new App();
            }

            //Take control of WPF application shutdown
            System.Windows.Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
    }
}
