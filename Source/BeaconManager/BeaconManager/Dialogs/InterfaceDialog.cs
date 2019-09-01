using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Types;
using BeaconManager.Utilities;

namespace BeaconManager.Dialogs
{
    public partial class InterfaceDialog : Form
    {
        public EthernetInterface SelectedInterface;

        public InterfaceDialog()
        {
            InitializeComponent();

            foreach (EthernetInterface eif in NetworkManager.GetEthernetInterfaces(false))
            {
                box_list.Items.Add(eif);
            }
        }

        private void Box_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedInterface = box_list.SelectedItem as EthernetInterface;
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
