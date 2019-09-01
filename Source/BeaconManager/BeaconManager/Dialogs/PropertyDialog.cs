using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Controls;
using BeaconManager.Types;

namespace BeaconManager.Dialogs
{
    public partial class PropertyDialog : Form
    {
        private ModuleIcon _icon;
        private BeaconModule _module;

        public PropertyDialog(ModuleIcon icon, ref BeaconModule module)
        {
            InitializeComponent();
            _icon = icon;
            _module = module;

            label_ip.Text = $@"IP : {module.GetIP()}";
            label_uuid.Text = $@"UUID : {module.GetUUID()}";
        }

        private void Text_x_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Text_y_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_x_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Text_y_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private async void PropertyDialog_Load(object sender, EventArgs e)
        {
            if (await _module.GetStatus())
            {
                label_status.Text = @"Scanning";
                label_status.ForeColor = Color.Green;
                button_start.Text = @"Stop";
            }
            else
            {
                label_status.Text = @"Stopped";
                label_status.ForeColor = Color.DarkRed;
                button_start.Text = @"Start";
            }
        }

        private async void Button_start_Click(object sender, EventArgs e)
        {
            if (_module.GetStatusCache())
            {
                await _module.Stop();
                label_status.Text = @"Stopped";
                label_status.ForeColor = Color.DarkRed;
                button_start.Text = @"Start";
            }
            else
            {
                await _module.Start();
                label_status.Text = @"Scanning";
                label_status.ForeColor = Color.Green;
                button_start.Text = @"Stop";
            }
            _icon.Invalidate();
        }

        private void Button_enable_Click(object sender, EventArgs e)
        {
            _icon.setEnabled(true);
        }
    }
}
