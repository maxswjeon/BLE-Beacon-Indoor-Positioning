using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Forms;
using BeaconManager.Types;

namespace BeaconManager.Panels
{
    public partial class BeaconPanel : UserControl
    {
        private BeaconModule _beaconModule;

        public BeaconPanel(BeaconModule beaconModule)
        {
            InitializeComponent();
            _beaconModule = beaconModule;
            _beaconModule.OnModuleStatusChanged += Module_StatusChanged;

            label_ip.Text = $@"IP : {beaconModule.GetIP()}";
            label_uuid.Text = $@"UUID : {beaconModule.GetUUID()}";
        }

        private void Module_StatusChanged(BeaconModule module)
        {
            Int32 t;
            if (_beaconModule.GetStatusCache())
            {
                text_status.Text = @"Scanning";
                text_status.ForeColor = Color.Green;
                button_toggle.Text = @"Stop";
                button_live_data.Enabled = true;
                button_data.Enabled = Int32.TryParse(text_scan.Text, out t);
            }
            else
            {
                text_status.Text = @"Stopped";
                text_status.ForeColor = Color.DarkRed;
                button_toggle.Text = @"Start";
                button_live_data.Enabled = false;
                button_data.Enabled = Int32.TryParse(text_scan.Text, out t);
            }
        }

        private async void BeaconPanel_Load(object sender, EventArgs e)
        {
            await _beaconModule.LoadStatus();
        }

        private async void Button_toggle_Click(object sender, EventArgs e)
        {
            if (_beaconModule.GetStatusCache())
            {
                await _beaconModule.Stop();
            }
            else
            {
                await _beaconModule.Start();
            }
        }

        private void Button_data_Click(object sender, EventArgs e)
        {
            new DataForm(_beaconModule, Int32.Parse(text_scan.Text)).Show();
        }

        private void Button_live_data_Click(object sender, EventArgs e)
        {
            new DataForm(_beaconModule, 0).Show();
        }

        private void Text_scan_TextChanged(object sender, EventArgs e)
        {
            Int32 t;
            if (Int32.TryParse(text_scan.Text, out t) && _beaconModule.GetStatusCache())
            {
                button_data.Enabled = true;
            }
            else
            {
                button_data.Enabled = false;
            }
        }
    }
}
