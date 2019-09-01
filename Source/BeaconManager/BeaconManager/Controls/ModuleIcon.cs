using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Dialogs;
using BeaconManager.Types;

namespace BeaconManager.Controls
{
    public partial class ModuleIcon : UserControl
    {
        public String UUID;

        private BeaconModule _module;
        private Boolean _moduleEnabled = true;

        public ModuleIcon(BeaconModule module)
        {
            InitializeComponent();
            _module = module;
            _module.OnModuleStatusChanged += Module_StateChanged;

            DoubleBuffered = true;

            UUID = _module.GetUUID();
        }

        private void Module_StateChanged(BeaconModule module)
        {
            item_start.Text = module.GetStatusCache() ? @"Stop" : @"Start";
            Invalidate();
        }

        private void ModuleIcon_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            Brush brush;
            if (_moduleEnabled)
            {
                brush = new SolidBrush(_module.GetStatusCache() ? Color.Green : Color.DarkRed);
            }
            else
            {
                brush = new HatchBrush(HatchStyle.BackwardDiagonal, _module.GetStatusCache() ? Color.Green : Color.DarkRed, Color.White);
            }
            graphics.FillEllipse(brush, 1, 1, Width - 3, Height - 3);

            Pen pen = new Pen(_module.GetStatusCache() ? Color.Green : Color.DarkRed, 2);
            graphics.DrawEllipse(pen, 1, 1, Width - 3, Height - 3);
            pen.Dispose();
            brush.Dispose();
        }

        private void ModuleIcon_Paint(object sender, PaintEventArgs e)
        {

        }

        public Boolean IsInCircle(Point cursor, Point obj)
        {
            Point inner = new Point(obj.X - cursor.X, cursor.Y - obj.Y);
            Point center = new Point(Width / 2, Height / 2);
            return Math.Pow(inner.X - center.X, 2) + Math.Pow(inner.Y - center.Y, 2) > (double)Width / 2;
        }

        private void ModuleIcon_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show($@"Bluetooth Module" + Environment.NewLine
                                              + $@"IP : {_module.GetIP()}" + Environment.NewLine
                                              + $@"UUID : {_module.GetUUID().Substring(0, 8)}", this, 10000);
        }


        private void ModuleIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menuStrip.Show(new Point(MousePosition.X, MousePosition.Y));
            }
        }

        private void ModuleIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PropertyDialog dialog = new PropertyDialog(this, ref _module);
            dialog.Show(this);
        }

        private async void Item_start_Click(object sender, EventArgs e)
        {
            if (_module.GetStatusCache())
            {
                await _module.Stop();
                await _module.LoadStatus();
                item_start.Text = @"Start";
            }
            else
            {
                await _module.Start();
                await _module.LoadStatus();
                item_start.Text = @"Stop";
            }
            Invalidate();
        }

        private void Item_enable_Click(object sender, EventArgs e)
        {
            _moduleEnabled = !_moduleEnabled;
            item_enable.Text = _moduleEnabled ? "Disable" : "Enable";
            Invalidate();
        }

        private void Item_properties_Click(object sender, EventArgs e)
        {

        }

        public void setEnabled(Boolean flag)
        {
            _moduleEnabled = flag;
            Invalidate();
        }

    }
}
