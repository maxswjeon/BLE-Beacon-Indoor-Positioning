using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BeaconManager.Forms
{
    public partial class DataViewForm : Form
    {
        private MainForm main;
        private List<(DateTime, Int32, Double)> _data;

        public DataViewForm(MainForm parent, String path)
        {
            InitializeComponent();
            main = parent;
            _data = new List<(DateTime, int, double)>();

            using (StreamReader fs = File.OpenText(path))
            {
                String line;

                while ((line = fs.ReadLine()) != null)
                {
                    String[] rawData = line.Split(',');
                    (DateTime, Int32, Double) data;
                    data.Item1 = DateTime.Parse(rawData[0]);
                    data.Item2 = Convert.ToInt32(rawData[1]);
                    data.Item3 = Convert.ToDouble(rawData[2]);
                    _data.Add(data);
                }
            }

            SetFullChart();
            SetDistChart();
        }

        private void SetFullChart()
        {
            Series rawSeries = new Series("Raw Data");
            rawSeries.ChartType = SeriesChartType.Line;
            rawSeries.BorderWidth = 1;
            rawSeries.Color = Color.OrangeRed;
            rawSeries.XValueType = ChartValueType.Time;

            Series kalmanSeries = new Series("Filtered Data");
            kalmanSeries.ChartType = SeriesChartType.Line;
            kalmanSeries.BorderWidth = 1;
            kalmanSeries.Color = Color.Green;
            kalmanSeries.XValueType = ChartValueType.Time;


            foreach (var data in _data)
            {
                rawSeries.Points.AddXY(data.Item1, data.Item2);
                kalmanSeries.Points.AddXY(data.Item1, data.Item3);
            }

            chart_full.Series.Add(rawSeries);
            chart_full.Series.Add(kalmanSeries);
            chart_full.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
        }

        private void SetDistChart()
        {
            Dictionary<Int32, Int32> rawDistList = new Dictionary<Int32, Int32>();
            Dictionary<Double, Int32> filtDistList = new Dictionary<Double, Int32>();

            foreach (var data in _data)
            {
                if (rawDistList.ContainsKey(data.Item2))
                {
                    rawDistList[data.Item2]++;
                }
                else
                {
                    rawDistList.Add(data.Item2, 1);
                }

                if (filtDistList.ContainsKey(data.Item3))
                {
                    filtDistList[data.Item3]++;
                }
                else
                {
                    filtDistList.Add(data.Item3, 1);
                }
            }

            Series rawDistSeries = new Series("Raw Data");
            rawDistSeries.ChartType = SeriesChartType.Column;
            rawDistSeries.BorderWidth = 1;
            rawDistSeries.Color = Color.OrangeRed;

            Series filtDistSeries = new Series("Filtered Data");
            filtDistSeries.ChartType = SeriesChartType.Line;
            filtDistSeries.BorderWidth = 1;
            filtDistSeries.Color = Color.Green;

            List<Int32> rawDistKeys = rawDistList.Keys.ToList();
            rawDistKeys.Sort();
            List<Double> filtDistKeys = filtDistList.Keys.ToList();
            filtDistKeys.Sort();

            foreach (Int32 key in rawDistKeys)
            {
                rawDistSeries.Points.AddXY(key, rawDistList[key]);
            }

            foreach (Double key in filtDistKeys)
            {
                filtDistSeries.Points.AddXY(key, filtDistList[key]);
            }

            chart_dist.Series.Add(rawDistSeries);
            chart_dist.Series.Add(filtDistSeries);
            chart_dist.ChartAreas[0].AxisX.Maximum = rawDistKeys[rawDistList.Count - 1] + 1;
            chart_dist.ChartAreas[0].AxisX.Minimum = rawDistKeys[0] - 1;
        }

        private void CalculateStats()
        {

        }

        private void DataViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }
    }
}
