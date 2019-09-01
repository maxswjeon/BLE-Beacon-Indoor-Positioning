using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Controls;
using BeaconManager.Dialogs;
using BeaconManager.Types;
using BeaconManager.Types.Geometry;
using BeaconManager.Utilities;

namespace BeaconManager.Forms
{
    public partial class LocateForm : Form
    {
        private MainForm _main;
        private CountdownEvent _scanEvent;

        private Dictionary<BeaconModule, ModuleIcon> _modules = new Dictionary<BeaconModule, ModuleIcon>();
        private ConcurrentBag<BeaconModule> _scanResult = new ConcurrentBag<BeaconModule>();
        private Dictionary<Beacon, BeaconIcon> _beacons = new Dictionary<Beacon, BeaconIcon>();

        private Point _mouseStart;
        private Point _mouseDiff;
        private Point _gridDiff = new Point(0, 0);
        private int _gridWidth = 50;
        private Boolean _ctrl;

        private int _scanTime = 500;

        public LocateForm(MainForm parent)
        {
            InitializeComponent();
            _main = parent;
            DoubleBuffered = true;

            comboBox1.Items.Add(100);
            comboBox1.Items.Add(250);
            comboBox1.Items.Add(500);
            comboBox1.Items.Add(750);
            comboBox1.Items.Add(1000);
            comboBox1.Items.Add(2000);
        }

        private void ViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _main.Show();
        }
        
        private async Task LoadModules()
        {
            BeaconModule m;
            while (!_scanResult.IsEmpty)
            {
                _scanResult.TryTake(out m);
            }
            foreach (ModuleIcon icon in _modules.Values)
            {
                icon.Dispose();
            }
            _modules.Clear();

            InterfaceDialog dialog = new InterfaceDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK && dialog.SelectedInterface != null)
            {
                status_text.Text = $@"Loading Bluetooth Modules from {dialog.SelectedInterface.Text}";

                ThreadPool.SetMinThreads(500, 500);
                ThreadPool.SetMaxThreads(4096, 4096);

                UnicastIPAddressInformation ipInfo = dialog.SelectedInterface.IP;

                (IPAddress start, IPAddress end, int count) =
                    NetworkManager.GetSubnetRange(ipInfo.Address, ipInfo.IPv4Mask);

                _scanEvent = new CountdownEvent(count);
                status_progress.Maximum = count;

                for (IPAddress ip = start; !Equals(ip, end); ip = NetworkManager.NextAddress(ip))
                {
                    ThreadPool.QueueUserWorkItem(ScanModule, ip);
                }

                await WaitScan();

                status_text.Text = $@"Found {_scanResult.Count} Bluetooth Modules";
                if (_scanResult.Count < 3)
                {
                    DialogResult result = MessageBox.Show(
                        $@"There are less than 3 Bluetooth Modules in this network (Found {_scanResult.Count} Modules)" +
                        Environment.NewLine +
                        @"Need at least 3 Modules to Locate Beacon", @"Too less Modules Found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        await LoadModules();
                    }
                    else
                    {
                        status_text.Text = @"Failed to Load Bluetooth Modules";
                    }
                }

                foreach (BeaconModule module in _scanResult)
                {
                    ModuleIcon icon = new ModuleIcon(module);
                    icon.MouseDown += ModuleIcon_MouseDown;
                    icon.MouseMove += ModuleIcon_MouseMove;
                    icon.MouseUp += ModuleIcon_MouseUp;
                    icon.KeyDown += ModuleIcon_KeyDown;
                    icon.KeyUp += ModuleIcon_KeyUp;
                    _modules[module] = icon;
                    Controls.Add(icon);
                }
            }
        }

        private async void ScanModule(Object obj)
        {
            IPAddress ip = obj as IPAddress;
            BeaconModule module = await BeaconModule.GetBeacon(ip);
            if (module != null)
            {
                _scanResult.Add(module);
            }

            _scanEvent.Signal();
        }

        private async Task WaitScan()
        {
            while (!_scanEvent.IsSet)
            {
                await Task.Delay(10);
                Invoke(new MethodInvoker(() =>
                {
                    status_progress.Value = _scanEvent.InitialCount - _scanEvent.CurrentCount;
                }));
            }
        }

        private async void ViewForm_Shown(object sender, EventArgs e)
        {
            await LoadModules();
        }

        private void ModuleIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseStart = e.Location;
                _mouseDiff = new Point(0, 0);
            }
        }

        private void ModuleIcon_MouseMove(object sender, MouseEventArgs e)
        {
            ModuleIcon icon = sender as ModuleIcon;
            if (icon == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                Point diff = new Point(e.X - _mouseStart.X, e.Y - _mouseStart.Y);
                icon.Location = new Point(icon.Location.X + diff.X, icon.Location.Y + diff.Y);
            }
        }

        private void ModuleIcon_MouseUp(object sender, MouseEventArgs e)
        {
            ModuleIcon icon = sender as ModuleIcon;
            if (icon == null)
            {
                return;
            }

            _mouseStart = new Point(0, 0);
            _mouseDiff = new Point(0, 0);

            if (!_ctrl)
            {
                int x = (int)(Math.Round((double)icon.Location.X / _gridWidth) * _gridWidth + _gridDiff.X % _gridWidth - (double)icon.Width / 2);
                int y = (int)(Math.Round((double)icon.Location.Y / _gridWidth) * _gridWidth + _gridDiff.Y % _gridWidth - (double)icon.Height / 2);
                icon.Location = new Point(x, y);
            }
        }

        private void ModuleIcon_KeyDown(object sender, KeyEventArgs e)
        {
            _ctrl = e.Control;
        }

        private void ModuleIcon_KeyUp(object sender, KeyEventArgs e)
        {
            _ctrl = e.Control;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Pen p = new Pen(Color.DimGray);

            for (int x = 0; x < Width / _gridWidth; ++x)
            {
                graphics.DrawLine(p, x * _gridWidth + _gridDiff.X % _gridWidth, 0, x * _gridWidth + _gridDiff.X % _gridWidth, Height);
            }
            for (int y = 0; y < Height / _gridWidth; ++y)
            {
                graphics.DrawLine(p, 0, y * _gridWidth + _gridDiff.Y % _gridWidth, Width, y * _gridWidth + _gridDiff.Y % _gridWidth);
            }

            p.Dispose();
        }

        private void LocateForm_KeyDown(object sender, KeyEventArgs e)
        {
            _ctrl = e.Control;
        }

        private void LocateForm_KeyUp(object sender, KeyEventArgs e)
        {
            _ctrl = e.Control;
        }

        private void LocateForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseStart = e.Location;
            }
        }

        private void LocateForm_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseStart = new Point(0, 0);
            _mouseDiff = new Point(0, 0);
        }

        private void LocateForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point diff = new Point(e.X - _mouseStart.X, e.Y - _mouseStart.Y);
                _gridDiff.X = _gridDiff.X - _mouseDiff.X + diff.X;
                _gridDiff.Y = _gridDiff.Y - _mouseDiff.Y + diff.Y;
                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(ModuleIcon))
                    {
                        ModuleIcon icon = control as ModuleIcon;
                        icon.Location = new Point(icon.Location.X - _mouseDiff.X + diff.X, icon.Location.Y - _mouseDiff.Y + diff.Y);
                    }
                }
                _mouseDiff = diff;
                Invalidate();
            }
        }

        private async void Button_start_Click(object sender, EventArgs e)
        {
            //var stopTasks = _modules.Keys
            //    .Select(module => module)
            //    .ToDictionary(m => m.Stop(), m => m);
            //var startTasks =_modules.Keys
            //    .Select(module => module)
            //    .ToDictionary(m => m.Start(), m => m);


            //while (stopTasks.Count > 0)
            //{
            //    Task first = await Task.WhenAny(stopTasks.Keys);
            //    stopTasks.Remove(first);
            //    await first;
            //}

            //while (startTasks.Count > 0)
            //{
            //    Task first = await Task.WhenAny(startTasks.Keys);
            //    BeaconModule module = startTasks[first];
            //    startTasks.Remove(first);
            //    await first;
            //}

            _beacons.Clear();
            foreach (BeaconModule module in _modules.Keys)
            {
                await module.Stop();
                await module.Start();
            }

            while (true)
            {
                foreach (BeaconModule module in _modules.Keys)
                {
                    List<Beacon> beacons = await module.GetData();

                    foreach (Beacon beacon in beacons)
                    {
                        if (!_beacons.ContainsKey(beacon))
                        {
                            BeaconIcon icon = new BeaconIcon(beacon);
                            _beacons.Add(beacon, new BeaconIcon(beacon));
                        }

                        //_beacons[beacon].AddScanData(_modules[module].Location, beacon.GetData());
                    }
                }

                await Task.Delay(_scanTime);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _scanTime = (int)comboBox1.SelectedItem;
        }
    }
}
