using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Controls;
using BeaconManager.Panels;
using BeaconManager.Types;
using BeaconManager.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeaconManager.Forms
{

    public partial class ScanForm : Form
    {
        private CountdownEvent scanEvent;
        private MainForm main;
        

        public ScanForm(MainForm parent)
        {
            InitializeComponent();
            ThreadPool.SetMinThreads(250, 250);
            ThreadPool.SetMaxThreads(2048, 2048);
            main = parent;
        }

        private void LoadNetworkInterfaces()
        {
            box_interface.DataSource = null;
            box_interface.Items.Clear();
            box_interface.DataSource = NetworkManager.GetEthernetInterfaces(check_unavailable.Checked);
            button_scan.Enabled = box_interface.SelectedItem != null;
        }

        private async void TestModule(Object ip_obj)
        {
            IPAddress ip = (IPAddress)ip_obj;
            BeaconModule module = await BeaconModule.GetBeacon(ip);
            scanEvent.Signal();

            if (module != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    BeaconItem item = new BeaconItem(module, BeaconItem_Click);
                    panel_list.Controls.Add(item);
                }));
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadNetworkInterfaces();
        }

        private void Check_unavailable_CheckedChanged(object sender, EventArgs e)
        {
            LoadNetworkInterfaces();
        }

        private void Button_refresh_Click(object sender, EventArgs e)
        {
            LoadNetworkInterfaces();
        }

        private void Button_scan_Click(object sender, EventArgs e)
        {
            button_scan.Enabled = false;

            UnicastIPAddressInformation ipInfo = ((EthernetInterface)box_interface.SelectedValue).IP;
            IPAddress host = ipInfo.Address;
            (IPAddress start, IPAddress end, int count) = NetworkManager.GetSubnetRange(host, ipInfo.IPv4Mask);

            scanEvent = new CountdownEvent(count);

            panel_list.Controls.Clear();
            panel_main.Controls.Clear();
            WaitPanel panel = new WaitPanel(ref scanEvent);
            panel.Dock = DockStyle.Fill;
            panel_main.Controls.Add(panel);

            IPAddress ip = start;
            while (!ip.Equals(end))
            {
                ThreadPool.QueueUserWorkItem(TestModule, ip);
                ip = NetworkManager.NextAddress(ip);
            }
        }

        private void Box_interface_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_scan.Enabled = box_interface.SelectedItem != null;
        }

        public void BeaconItem_Click(object sender, MouseEventArgs e)
        {
            BeaconItem item = (BeaconItem)sender;
            panel_main.Controls.Clear();
            panel_main.Controls.Add(new BeaconPanel(item.BeaconModuleData));
        }

        public void EnableStart()
        {
            button_scan.Enabled = true;
        }

        private void ScanForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
    }
}
