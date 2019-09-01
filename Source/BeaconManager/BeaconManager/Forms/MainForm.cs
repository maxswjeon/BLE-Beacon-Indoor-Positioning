using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Dialogs;

namespace BeaconManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label origin = sender as Label;
            origin.ForeColor = Color.Black;

            Cursor.Current = Cursors.Hand;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label origin = sender as Label;
            origin.ForeColor = Color.DimGray;

            Cursor.Current = Cursors.Default;
        }

        private void Label_data_Click(object sender, EventArgs e)
        {
            Hide();
            new ScanForm(this).Show(this);
        }

        private void Label_locate_Click(object sender, EventArgs e)
        {
            Hide();
            new LocateForm(this).Show(this);
        }

        private void Label_open_Click(object sender, EventArgs e)
        {
            openDialog.Filter = @"CSV Data file (*.csv)|*.csv|모든 파일 (*.*)|*.*";
            if (openDialog.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                new DataViewForm(this, openDialog.FileName).Show(this);
            }
        }

        private void Label_about_Click(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog(this);
        }
    }
}
