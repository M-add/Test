using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Charts
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.Rows.Add(2011, 2000, 1100);
            dataGridView.Rows.Add(2012, 2200, 1500);
            dataGridView.Rows.Add(2013, 1800, 1050);
            dataGridView.Rows.Add(2014, 1000, 800);
            dataGridView.Rows.Add(2015, 1500, 900);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart.Series.Clear();
            int max = 0;

            Series series = new Series
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)),
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Int32,
                Name = "Amount"
            };
            Series series2 = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 5,
                BorderDashStyle = ChartDashStyle.Solid,
                Color = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)),
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Int32,
                Name = "Profit"
            };

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    try
                    {
                        int year = int.Parse(row.Cells["Year"].Value.ToString());
                        int amount = int.Parse(row.Cells["Amount"].Value.ToString());
                        int profit = int.Parse(row.Cells["Profit"].Value.ToString());

                        max = amount > max ? amount : max;

                        series.Points.AddXY(year, amount);
                        series2.Points.AddXY(year, profit);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            chart.Series.Add(series);
            chart.Series.Add(series2);

            chart.ChartAreas[0].AxisX.Title = "Year";
            chart.ChartAreas[0].AxisY.Title = "Amount , Profit";
            chart.ChartAreas[0].AxisY.Maximum = max + 1000;
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Tai Le", 12, FontStyle.Bold);
            chart.ChartAreas[0].AxisX.TitleFont = new Font("Microsoft Tai Le", 12, FontStyle.Bold);
            chart.ChartAreas[0].AxisX.Interval = 1;
        }
    }
}
