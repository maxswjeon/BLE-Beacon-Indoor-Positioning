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

namespace BeaconManager.Controls
{
    public partial class BeaconItem : UserControl
    {
        public BeaconModule BeaconModuleData;

        public BeaconItem(BeaconModule beaconModule, MouseEventHandler handler)
        {
            InitializeComponent();
            
            BeaconModuleData = beaconModule;
            label_ip.Text = beaconModule.GetIP().ToString();
            label_uuid.Text = beaconModule.GetUUID();
            
            MouseClick += handler;
        }

        private void BeaconItem_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(0xF7, 0xF7, 0xF7);
        }

        private void BeaconItem_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = Color.White;
        }

        private void BeaconItem_Load(object sender, EventArgs e)
        {
            if (Parent.Controls.Count != 1)
            {
                int y = 0;
                foreach (Control control in Parent.Controls)
                {
                    if (control.Location.Y > y)
                    {
                        y = control.Location.Y;
                    }
                }
                Location = new Point(Location.X, y + Height);
            }
        }
        private void BeaconItem_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, new Point(0, Height - 1), new Point(Width, Height - 1));
        }

        private void Label_name_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        private void Label_ip_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

        private void Label_uuid_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }
    }
}
