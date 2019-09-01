using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BeaconManager.Types;
using BeaconManager.Utilities;

namespace BeaconManager.Forms
{
    public partial class DataForm : Form
    {
        private BeaconModule _beaconModule;
        private List<Beacon> _data;

        private List<Tuple<DateTime, Int32>> _currentRaw = new List<Tuple<DateTime, Int32>>();
        private List<Tuple<DateTime, Double>> _currentFilt = new List<Tuple<DateTime, Double>>();

        public DataForm(BeaconModule beaconModule, Int32 scanTime)
        {
            InitializeComponent();

            _beaconModule = beaconModule;
            Task.Factory.StartNew(async () =>
            {
                if (scanTime != 0)
                {
                    await _beaconModule.ClearData();
                }

                Thread.Sleep(scanTime * 1000);
                _data = await _beaconModule.GetData();
                Invoke(new MethodInvoker(() =>
                {
                    foreach (Beacon beacon in _data)
                    {
                        if (!listbox_uuid.Items.Contains(beacon.UUID))
                        {
                            listbox_uuid.Items.Add(beacon.UUID);
                        }
                    }

                    listbox_uuid.Enabled = true;
                    listbox_major.Enabled = true;
                    listbox_minor.Enabled = true;
                }));
            });
        }

        private void Listbox_uuid_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbox_major.Items.Clear();
            listbox_minor.Items.Clear();
            chart.Series.Clear();
            panel_info.Visible = false;
            button_save.Enabled = false;

            if (listbox_uuid.SelectedItem == null)
            {
                return;
            }

            foreach (Beacon beacon in _data)
            {
                if (beacon.UUID != (String) listbox_uuid.SelectedItem)
                {
                    continue;
                }

                if (check_tohex.Checked && !listbox_major.Items.Contains(Convert.ToString(beacon.Major, 16).PadLeft(4, '0').ToUpper()))
                {
                    listbox_major.Items.Add(Convert.ToString(beacon.Major, 16).PadLeft(4, '0').ToUpper());
                }
                else if (!check_tohex.Checked && !listbox_major.Items.Contains(beacon.Major))
                {
                    listbox_major.Items.Add(beacon.Major);
                }
            }
        }

        private void Listbox_major_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbox_minor.Items.Clear();
            chart.Series.Clear();
            panel_info.Visible = false;
            button_save.Enabled = false;
            if (listbox_major.SelectedItem == null)
            {
                return;
            }

            foreach (Beacon beacon in _data)
            {
                if (beacon.UUID != (String) listbox_uuid.SelectedItem)
                {
                    if (check_tohex.Checked && (String)listbox_major.SelectedItem != Convert.ToString(beacon.Major, 16).PadLeft(4, '0').ToUpper())
                    {
                        continue;
                    }

                    if (!check_tohex.Checked && (UInt16)listbox_major.SelectedItem != beacon.Major)
                    {
                        continue;
                    }
                }

                if (check_tohex.Checked && !listbox_minor.Items.Contains(Convert.ToString(beacon.Minor, 16).PadLeft(4, '0').ToUpper()))
                {
                    listbox_minor.Items.Add(Convert.ToString(beacon.Minor, 16).PadLeft(4, '0').ToUpper());
                }
                else if (!check_tohex.Checked && !listbox_minor.Items.Contains(beacon.Minor))
                {
                    listbox_minor.Items.Add(beacon.Minor);
                }
            }
        }

        private void Listbox_minor_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart.Series.Clear();
            _currentRaw.Clear();
            _currentFilt.Clear();
            panel_info.Visible = false;
            button_save.Enabled = false;
            if (listbox_minor.SelectedItem == null)
            {
                return;
            }

            String uuid = (String) listbox_uuid.SelectedItem;
            UInt16 major;
            UInt16 minor;
            if (!check_tohex.Checked)
            {
                major = (UInt16) listbox_major.SelectedItem;
                minor = (UInt16) listbox_minor.SelectedItem;
            }
            else
            {
                major = Convert.ToUInt16((String)listbox_major.SelectedItem, check_tohex.Checked ? 16 : 10);
                minor = Convert.ToUInt16((String)listbox_minor.SelectedItem, check_tohex.Checked ? 16 : 10);
            }
            
            Beacon dummyBeacon = new Beacon(uuid, major, minor, 0);
            Beacon beacon = _data[_data.IndexOf(dummyBeacon)];
            List<Tuple<DateTime, Int32>> dataList = beacon.GetData();

            KalmanFilter filter = new KalmanFilter();
            
            Series rawSeries = new Series("Raw Data");
            rawSeries.ChartType = SeriesChartType.FastLine;
            rawSeries.BorderWidth = 1;
            rawSeries.Color = Color.OrangeRed;
            rawSeries.XValueType = ChartValueType.Time;

            Series kalmanSeries = new Series("Filtered Data");
            kalmanSeries.ChartType = SeriesChartType.FastLine;
            kalmanSeries.BorderWidth = 1;
            kalmanSeries.Color = Color.Green;
            kalmanSeries.XValueType = ChartValueType.Time;


            foreach (var data in dataList)
            {
                rawSeries.Points.AddXY(data.Item1, data.Item2);
                filter.Update(new []{(Double)data.Item2});
                kalmanSeries.Points.AddXY(data.Item1, filter.getState()[0]);

                _currentRaw.Add(new Tuple<DateTime, int>(data.Item1, data.Item2));
                _currentFilt.Add(new Tuple<DateTime, double>(data.Item1, filter.getState()[0]));
            }

            SetInfo();

            chart.Series.Add(rawSeries);
            chart.Series.Add(kalmanSeries);
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";

            panel_info.Visible = true;
            button_save.Enabled = true;
        }

        private void SetInfo()
        {
            Int64 sum = 0;
            Int64 sum2 = 0;
            Double mean = 0;
            Double sigma = 0;

            Double filt_sum = 0;
            Double filt_sum2 = 0;
            Double filt_mean = 0;
            Double filt_sigma = 0;

            foreach (var data in _currentRaw)
            {
                sum += data.Item2;
                sum2 += data.Item2 * data.Item2;
            }

            foreach (var data in _currentFilt)
            {
                filt_sum += data.Item2;
                filt_sum2 += data.Item2 * data.Item2;
            }

            mean = (Double)sum / _currentRaw.Count;
            sigma = (Double)sum2 / _currentRaw.Count - mean * mean;
            filt_mean = (Double)filt_sum / _currentFilt.Count;
            filt_sigma = (Double)filt_sum2 / _currentFilt.Count - filt_mean * filt_mean;

            label_mean.Text = $@"Mean : {mean}";
            label_sigma.Text = $@"Sigma : {sigma}";
            label_count.Text = $@"Count : {_currentRaw.Count}";
            label_start.Text = $@"Start : {_currentRaw[0].Item1.ToString("yyyy/MM/dd HH:mm:ss.fff")}";
            label_end.Text = $@"End : {_currentRaw[_currentRaw.Count - 1].Item1.ToString("yyyy/MM/dd HH:mm:ss.fff")}";
            label_duration.Text =
                $@"Duration : {(_currentRaw[_currentRaw.Count - 1].Item1 - _currentRaw[0].Item1).ToString(@"hh\:mm\:ss\.fff")}";
            label_kalman_mean.Text = $@"Filtered Mean : {filt_mean}";
            label_kalman_sigma.Text = $@"Filtered Sigma : {filt_sigma}";
        }

        private void Check_tohex_CheckedChanged(object sender, EventArgs e)
        {
            if (check_tohex.Checked)
            {
                //Major/Minor was in dec before
                String oldMajor = null;
                String oldMinor = null;

                if (listbox_major.SelectedItem != null)
                {
                    oldMajor = Convert.ToString((UInt16)listbox_major.SelectedItem, 16).PadLeft(4, '0').ToUpper();
                }

                if (listbox_minor.SelectedItem != null)
                {
                    oldMinor = Convert.ToString((UInt16) listbox_minor.SelectedItem, 16).PadLeft(4, '0').ToUpper();
                }

                List<UInt16> majorList = listbox_major.Items.Cast<UInt16>().ToList();
                List<UInt16> minorList = listbox_minor.Items.Cast<UInt16>().ToList();

                listbox_major.Items.Clear();
                listbox_minor.Items.Clear();

                foreach (UInt16 major in majorList)
                {
                    listbox_major.Items.Add(Convert.ToString(major, 16).PadLeft(4, '0').ToUpper());
                }

                foreach (UInt16 minor in minorList)
                {
                    listbox_minor.Items.Add(Convert.ToString(minor, 16).PadLeft(4, '0').ToUpper());
                }

                if (oldMajor != null)
                {
                    listbox_major.SelectedItem = oldMajor;
                }

                if (oldMinor != null)
                {
                    listbox_minor.SelectedItem = oldMinor;
                }
            }
            else
            {
                //Major/Minor was in hex before
                String oldMajor = (String)listbox_major.SelectedItem;
                String oldMinor = (String)listbox_minor.SelectedItem;
                
                List<String> majorList = listbox_major.Items.Cast<String>().ToList();
                List<String> minorList = listbox_minor.Items.Cast<String>().ToList();

                listbox_major.Items.Clear();
                listbox_minor.Items.Clear();

                foreach (String major in majorList)
                {
                    listbox_major.Items.Add(Convert.ToUInt16(major, 16));
                }

                foreach (String minor in minorList)
                {
                    listbox_minor.Items.Add(Convert.ToUInt16(minor, 16));
                }

                if (oldMajor != null)
                {
                    listbox_major.SelectedItem = Convert.ToUInt16(oldMajor, 16);
                }

                if (oldMinor != null)
                {
                    listbox_minor.SelectedItem = Convert.ToUInt16(oldMinor, 16);
                }
            }
        }

        private void Button_save_Click(object sender, EventArgs e)
        {
            String uuid = ((String)listbox_uuid.SelectedItem).Substring(0, 8);
            String start = _currentRaw[0].Item1.ToString("yyyy-MM-dd HH.mm.ss");
            String end = _currentRaw[_currentRaw.Count - 1].Item1.ToString("yyyy-MM-dd HH.mm.ss");

            String major;
            String minor;

            if (check_tohex.Checked)
            {
                major = (String) listbox_major.SelectedItem;
                minor = (String) listbox_minor.SelectedItem;
            }
            else
            {
                major = Convert.ToString((UInt16)listbox_major.SelectedItem, 16);
                minor = Convert.ToString((UInt16)listbox_minor.SelectedItem, 16);
            }

            fileDialog.Filter = @"CSV File|*.csv";
            fileDialog.Title = @"Save Beacon Scan Data";
            fileDialog.FileName = $@"data_{uuid}_{major}_{minor}_{start}_{end}";
            DialogResult res = fileDialog.ShowDialog(this);

            if (fileDialog.FileName != "" && res == DialogResult.OK)
            {
                using (StreamWriter fs = new StreamWriter(fileDialog.OpenFile()))
                {
                    for (int i = 0; i < _currentRaw.Count; ++i)
                    {
                        fs.Write(_currentRaw[i].Item1.ToString("yyyy/MM/dd HH:mm:ss.fff"));
                        fs.Write(",");
                        fs.Write(_currentRaw[i].Item2);
                        fs.Write(",");
                        fs.Write(_currentFilt[i].Item2);
                        fs.WriteLine();
                    }
                    fs.Flush();
                }
            }
            fileDialog.Reset();
        }
    }
}
