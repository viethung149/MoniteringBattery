using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace listView_Test
{
    public class Real_Time_Chart
    {
        private Chart chart1;
        private Chart chart2;
        private bool initialChart1 = true;
        private bool initialChart2 = true;
        
        // set Chart1 
        public Chart Chart1   
        {
            set { chart1 = value; }  
            get { return chart1; }
        }
        // set Chart2
        public Chart Chart2   
        {
            set { chart2= value; }
            get { return chart2; }

        }
        // config chart 1
        public void myRealTimeChart1(string titleAxisX, string titleAxisY, string title, int minY, int maxY)
        {
            // voltage: green  temperature: yellow current: blue
            initialChart1 = true;

            chart1.Tag = new ChartScaleData(chart1);
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("chart1");
            chart1.Series.Add("Voltage");
            chart1.Series.Add("Temperature");
            chart1.Series.Add("Current");
            // config type
            chart1.Series["Voltage"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Voltage"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series["Voltage"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Voltage"].BorderWidth = 3;
            chart1.Series["Temperature"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Temperature"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series["Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Temperature"].BorderWidth = 3;
            chart1.Series["Current"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Current"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series["Current"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Current"].BorderWidth = 3;
            // config format Axis X
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
            chart1.Series[0].XValueMember = "Date/Time";
            chart1.Series[0].YValueMembers = "Data";
            // maker point
            chart1.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart1.Series[0].MarkerSize = 8;
            //chart1.Series[0].MarkerColor = Color.Yellow;
            chart1.Series[0].MarkerBorderWidth = 3;
            // add title
            Title title_chart = new Title();
            title_chart.Font = new Font("Arial", 14, FontStyle.Bold);
            title_chart.Text = title;
            chart1.Titles.Clear();
            chart1.Titles.Add(title_chart);
            chart1.ChartAreas[0].AxisX.Title = titleAxisX;
            chart1.ChartAreas[0].AxisY.Title = titleAxisY;
            // set y max min
            chart1.ChartAreas[0].AxisY.Minimum = minY;
            chart1.ChartAreas[0].AxisY.Maximum = maxY;
            chart1.Series[0].Color = Color.Blue;
            // lable angle -90
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //tooltip
            chart1.Series["Voltage"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series["Temperature"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series["Current"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";

            // grid
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart1.ForeColor = Color.LightGray;
            //color
            chart1.Series["Voltage"].Color = Color.Red;
            chart1.Series["Temperature"].Color = Color.Yellow;
            chart1.Series["Current"].Color = Color.Blue;
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(2).ToOADate();

            chart1.Series[0].Points.Add();
        }
        // config chart 2
        public void myRealTimeChart2(string titleAxisX, string titleAxisY, string title, int minY, int maxY)
        {
            // voltage: green  temperature: yellow current: blue
            initialChart2 = true;
            chart2.Tag = new ChartScaleData(chart2);
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.ChartAreas.Add("chart2");
            chart2.Series.Add("Voltage");
            chart2.Series.Add("Temperature");
            chart2.Series.Add("Current");
            // config type
            chart2.Series["Voltage"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart2.Series["Voltage"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart2.Series["Voltage"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Voltage"].BorderWidth = 3;
            chart2.Series["Temperature"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart2.Series["Temperature"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart2.Series["Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Temperature"].BorderWidth = 3;
            chart2.Series["Current"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart2.Series["Current"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart2.Series["Current"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Current"].BorderWidth = 3;
            // config format Axis X
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
            chart2.Series[0].XValueMember = "Date/Time";
            chart2.Series[0].YValueMembers = "Data";
            // maker point
            chart2.Series[0].MarkerStyle = MarkerStyle.Diamond;
            chart2.Series[0].MarkerSize = 7;
            //chart1.Series[0].MarkerColor = Color.Yellow;
            chart2.Series[0].MarkerBorderWidth = 3;
            // add title
            Title title_chart = new Title();
            title_chart.Font = new Font("Arial", 14, FontStyle.Bold);
            title_chart.Text = title;
            chart2.Titles.Clear();
            chart2.Titles.Add(title_chart);
            chart2.ChartAreas[0].AxisX.Title = titleAxisX;
            chart2.ChartAreas[0].AxisY.Title = titleAxisY;
            // set y max min
            chart2.ChartAreas[0].AxisY.Minimum = minY;
            chart2.ChartAreas[0].AxisY.Maximum = maxY;
            chart2.Series[0].Color = Color.Blue;
            // lable angle -90
            chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //tooltip
            chart2.Series["Voltage"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart2.Series["Temperature"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart2.Series["Current"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            // grid
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart2.ForeColor = Color.LightGray;
            //color
            chart2.Series["Voltage"].Color = Color.Red;
            chart2.Series["Temperature"].Color = Color.Yellow;
            chart2.Series["Current"].Color = Color.Blue;
            // min axis x
            chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
            chart2.ChartAreas[0].AxisX.Maximum= DateTime.Now.AddMinutes(2).ToOADate();
            chart2.Series[0].Points.Add();
            //chart2.Series[0].Points[0].IsEmpty = true;
        }
        public void addPointToChart1(double value, DateTime time) {
            // need initial 
            if (initialChart1)
            {
                chart1.ChartAreas[0].AxisX.Minimum = time.ToOADate() ;
                chart1.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart1 = false;
            }
            else {
                if (time.ToOADate() >= chart1.ChartAreas[0].AxisX.Maximum) {
                    chart1.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(time , value);
        }
        public void addPointToChart1(double value1, double value2, DateTime time)
        {
            // need initial 
            if (initialChart1)
            {
                chart1.ChartAreas[0].AxisX.Minimum = time.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart1 = false;
            }
            else
            {
                if (time.ToOADate() >= chart1.ChartAreas[0].AxisX.Maximum)
                {
                    chart1.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(time, value1);
            chart1.Series[1].Points.AddXY(time, value2);

        }
        public void addPointToChart1(double voltage, double temperature, double current,DateTime time)
        {
            // need initial 
            if (initialChart1)
            {
                chart1.ChartAreas[0].AxisX.Minimum = time.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart1 = false;
            }
            else
            {
                if (time.ToOADate() >= chart1.ChartAreas[0].AxisX.Maximum)
                {
                    chart1.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(time, voltage);
            chart1.Series[1].Points.AddXY(time, temperature);
            chart1.Series[2].Points.AddXY(time, current);

        }
        public void addPointToChart2(double value, DateTime time)
        {
            // need initial 
            if (initialChart2)
            {
                chart2.ChartAreas[0].AxisX.Minimum = time.ToOADate();
                chart2.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart2 = false;
            }
            else
            {
                if (time.ToOADate() >= chart2.ChartAreas[0].AxisX.Maximum)
                {
                    chart2.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart2.Series[0].Points.AddXY(time, value) ;
        }
        public void addPointToChart2(double value1,double value2, DateTime time)
        {
            // need initial 
            if (initialChart2)
            {
                chart2.ChartAreas[0].AxisX.Minimum = time.ToOADate();
                chart2.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart2 = false;
            }
            else
            {
                if (time.ToOADate() >= chart2.ChartAreas[0].AxisX.Maximum)
                {
                    chart2.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart2.Series[0].Points.AddXY(time, value1);
            chart2.Series[1].Points.AddXY(time, value2);
        }
        public void addPointToChart2(double voltage, double temperature,double current, DateTime time)
        {
            // need initial 
            if (initialChart2)
            {
                chart2.ChartAreas[0].AxisX.Minimum = time.ToOADate();
                chart2.ChartAreas[0].AxisX.Maximum = time.AddMinutes(2).ToOADate();
                initialChart2 = false;
            }
            else
            {
                if (time.ToOADate() >= chart2.ChartAreas[0].AxisX.Maximum)
                {
                    chart2.ChartAreas[0].AxisX.Maximum = time.AddSeconds(30).ToOADate();
                }
            }
            chart2.Series[0].Points.AddXY(time, voltage);
            chart2.Series[1].Points.AddXY(time, temperature);
            chart2.Series[1].Points.AddXY(time, current);
        }
    }
}
