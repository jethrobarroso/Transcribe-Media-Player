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
        private ElementHost _host;
        private MediaPlayerControl _mediaElement;

        public TaskPane()
        {
            InitializeComponent();
            _host = new ElementHost();
            _mediaElement = new MediaPlayerControl();
            _host.Child = _mediaElement;
            _host.Dock = DockStyle.Fill;
            this.Controls.Add(_host);
        }

        private void TaskPane_Load(object sender, EventArgs e)
        {

        }
    }
}
