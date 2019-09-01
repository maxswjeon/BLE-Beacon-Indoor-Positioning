using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeaconManager.Forms;

namespace BeaconManager.Panels
{
    public partial class WaitPanel : UserControl
    {
        private Thread _thread;
        private CountdownEvent _countdown;

        public WaitPanel(ref CountdownEvent countdown)
        {
            InitializeComponent();

            _countdown = countdown;
            progress_wait.Maximum = countdown.InitialCount;
            progress_wait.Value = countdown.InitialCount - countdown.CurrentCount;
            _thread = new Thread(() => {
                while (_countdown.CurrentCount > 0)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        progress_wait.Value = _countdown.InitialCount - _countdown.CurrentCount;
                        label_count.Text = $@"{_countdown.InitialCount - _countdown.CurrentCount}/{_countdown.InitialCount}";
                    }));
                    Thread.Sleep(10);
                }
                Invoke(new MethodInvoker(() =>
                {
                    progress_wait.Value = _countdown.InitialCount - _countdown.CurrentCount;
                    label_count.Text = $@"{_countdown.InitialCount - _countdown.CurrentCount}/{_countdown.InitialCount}";
                }));
                Thread.Sleep(1000);
                Invoke(new MethodInvoker(() =>
                {
                    ScanForm scanForm = (ScanForm) Parent.Parent;
                    scanForm.EnableStart();
                    Dispose();
                }));
            });
        }

        private void WaitPanel_Load(object sender, EventArgs e)
        {
            _thread.Start();
        }
    }
}
