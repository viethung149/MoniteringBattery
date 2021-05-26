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

namespace listView_Test
{
    public partial class Chart_Form : Form
    {
        public Chart_Form()
        {
            InitializeComponent();
            Config_chart();
        }
        void Config_chart() {
            chart1.Titles.Add("Monitoring Battery");
            var series_1 = chart1.Series.Add("Battery Voltage");
            var series_2 = chart1.Series.Add("Battery Temperature");
            var series_3 = chart1.Series.Add("Pheripheral");
            // config color
            chart1.Series["Battery Voltage"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Battery Voltage"].Color = Color.Blue;
            chart1.Series[0].IsVisibleInLegend = false;
            // config color
            chart1.Series["Battery Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Battery Temperature"].Color = Color.Red;
            chart1.Series[1].IsVisibleInLegend = false;
            //config color
            chart1.Series["Pheripheral"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Pheripheral"].Color = Color.Red;
            chart1.Series[2].IsVisibleInLegend = false;
            var chartArea = chart1.ChartAreas[series_1.ChartArea];
            Console.WriteLine(series_1.ChartArea.ToString());
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 5000;
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 1000;
            // enable autoscroll
            chartArea.CursorX.AutoScroll = true;
            // let's zoom to [0,blockSize] (e.g. [0,100])
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position = 0;
            int size = 100;
            chartArea.AxisX.ScaleView.Zoom(position, size);
            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            // set scrollbar small change to blockSize (e.g. 100)
            chartArea.AxisX.ScaleView.SmallScrollSize = 10;

            // ZOOM Y
            // enable autoscroll
            chartArea.CursorY.AutoScroll = true;
            // let's zoom to [0,blockSize] (e.g. [0,100])
            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position_y = 0;
            int size_y = 2000;
            chartArea.AxisY.ScaleView.Zoom(position_y, size_y);
            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea.AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            // set scrollbar small change to blockSize (e.g. 100)
            chartArea.AxisY.ScaleView.SmallScrollSize = 10;
            chart1.Series["Battery Voltage"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chart1.Series["Battery Temperature"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            chart1.Series["Pheripheral"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Data_chart.add_point("Battery Voltage", 100, 100, this);
        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    string information = "X = " + ((int)xVal).ToString() + " Y = " + ((int)yVal).ToString();
                    tooltip.Show(information, chart1, pos.X, pos.Y - 15);
                }
            }
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            // feature auto scale
        }

        private void Chart_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.FLAG_REALTIME_CHART = 0;
            this.Hide(); // hide the form instead of closing
            e.Cancel = true; // this cancels the close event.
            Console.WriteLine(Form1.FLAG_REALTIME_CHART);
        }
    }
}
