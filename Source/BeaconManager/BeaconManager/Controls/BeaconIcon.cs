using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Types;
using BeaconManager.Types.Geometry;

namespace BeaconManager.Controls
{
    public partial class BeaconIcon : UserControl
    {
        private Beacon _beacon;
        private List<MCircle> _ranges;

        public BeaconIcon(Beacon beacon)
        {
            InitializeComponent();
            _beacon = beacon;
        }

        public void AddScanData(Point position, double radius)
        {

        }

        public void AddScanData(MCircle c)
        {
            _ranges.Add(c);
        }

        public Boolean Update()
        {
            if (_ranges.Count < 3)
            {
                return false;
            }

            MPoint p = MCircle.IntersectThree(_ranges[0], _ranges[1], _ranges[2]);
            Console.WriteLine($@"{_beacon.UUID} : {p}");
            Location = (Point)p;
            return true;
        }

        private void BeaconIcon_Load(object sender, EventArgs e)
        {

        }
    }
}
