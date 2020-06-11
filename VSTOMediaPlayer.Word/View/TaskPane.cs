using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace VSTOMediaPlayer.Word.View
{
    public partial class TaskPane : UserControl
    {
        private ElementHost host;
        private MediaPlayerControl mediaElement;

        public TaskPane()
        {
            InitializeComponent();
            host = new ElementHost();
            mediaElement = new MediaPlayerControl();
            host.Child = mediaElement;
            host.Dock = DockStyle.Fill;
            this.Controls.Add(host);
        }

        private void TaskPane_Load(object sender, EventArgs e)
        {

        }
    }
}
