using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using MindFusion.Charting;
using Brush = MindFusion.Drawing.Brush;
using SolidBrush = MindFusion.Drawing.SolidBrush;
using DateTimeSeries;
using System.Data.OleDb;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Windows.Forms.DataVisualization.Charting;
using Axis = System.Windows.Forms.DataVisualization.Charting.Axis;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace graph
{

    public partial class Form1 : Form
    {
        public static Database access_db = new Database();
        public static int counter = 0;
        MyDateTimeSeries series1, series2;
        DateTime[] test_x = { new DateTime(2021, 6, 21, 9, 37, 00), new DateTime(2021, 6, 21, 9, 39, 00), new DateTime(2021, 6, 21, 9, 40, 00) };
        double[] test_y = { 1, 2, 3 };
        public Form1()
        {
            InitializeComponent();
            chart1.MouseDown += chart_MouseDown;
            chart1.MouseMove += chart_MouseMove;
            chart1.MouseUp += chart_MouseUp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            access_db.StrConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\App_C#\\Template\\listView_Test\\test.accdb";
            access_db.Conn = new OleDbConnection(access_db.StrConn);
            access_db.connect_access();
            myChart();
        }
        private void myChart() {
            chart1.Tag = new ChartScaleData(chart1);
            chart1.Series.Clear();
            DateTime inDate = new DateTime(2021, 6, 2);
            int size_x_axis = access_db.Get_Infor_Battery("Battery", 1, ref buffer_voltage, ref buffer_temperature, ref buffer_datetime, inDate);
            chart1.Series.Add("Voltage");
            chart1.Series.Add("Temperature");
            // config type
            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series[1].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series[1].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series[0].BorderWidth = 3;
            chart1.Series[1].BorderWidth = 3;
            // config format Axis X
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm tt";
            chart1.Series[0].XValueMember = "Date/Time";
            chart1.Series[0].YValueMembers = "Voltage";
            chart1.Series[1].XValueMember = "Date/Time";
            chart1.Series[1].YValueMembers = "Voltage";
            // add title
            Title title_chart = new Title();
            title_chart.Font = new Font("Arial", 14, FontStyle.Bold);
            title_chart.Text = "Monitoring Battery";
            chart1.Titles.Add(title_chart);
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Voltage / Temperature";
            // set y max min
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            // maker line voltage
            //chart1.Series[0].MarkerStyle = MarkerStyle.Diamond;
            //chart1.Series[0].MarkerSize = 4;
            //chart1.Series[0].MarkerColor = Color.Red;
            //chart1.Series[0].MarkerBorderWidth = 3;
            // maker line temperature
            //chart1.Series[1].MarkerStyle = MarkerStyle.Circle;
            //chart1.Series[1].MarkerSize = 4;
            //chart1.Series[1].MarkerColor = Color.Aqua;
            //chart1.Series[1].MarkerBorderWidth = 3;
            // change color
            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].Color = Color.Cyan;

            // lable angle -90
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            //tooltip
            chart1.Series[0].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series[1].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";

            // draw data
            chart1.Series[0].Points.DataBindXY(buffer_datetime, buffer_voltage);
            chart1.Series[1].Points.DataBindXY(buffer_datetime, buffer_temperature);

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points[size_x_axis - 1].XValue;
            // grid
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart1.ForeColor = Color.LightGray;
            
        }
        void myRealTimeChart() {
            chart1.Tag = new ChartScaleData(chart1);
            chart1.Series.Clear();
            chart1.Series.Add("Test");
            // config type
            chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line; 
            chart1.Series[0].BorderWidth = 3;
            // config format Axis X
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "";
            chart1.Series[0].XValueMember = "Date/Time";
            chart1.Series[0].YValueMembers = "Voltage";
            // add title
            Title title_chart = new Title();
            title_chart.Font = new Font("Arial", 14, FontStyle.Bold);
            title_chart.Text = "Monitoring Battery";
            chart1.Titles.Add(title_chart);
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Voltage / Temperature";
            // set y max min
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            // maker line voltage
            //chart1.Series[0].MarkerStyle = MarkerStyle.Diamond;
            //chart1.Series[0].MarkerSize = 4;
            //chart1.Series[0].MarkerColor = Color.Red;
            //chart1.Series[0].MarkerBorderWidth = 3;
            // maker line temperature
            //chart1.Series[1].MarkerStyle = MarkerStyle.Circle;
            //chart1.Series[1].MarkerSize = 4;
            //chart1.Series[1].MarkerColor = Color.Aqua;
            //chart1.Series[1].MarkerBorderWidth = 3;
            // change color
            chart1.Series[0].Color = Color.Blue;
            // lable angle -90
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            //tooltip
            chart1.Series[0].ToolTip = "#VALY{F}\n#VALX{F}";

            // draw data
            //chart1.Series[0].Points.DataBindXY(buffer_datetime, buffer_voltage);
            //chart1.Series[1].Points.DataBindXY(buffer_datetime, buffer_temperature);
            // grid
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart1.ForeColor = Color.LightGray;
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
           // chart1.ChartAreas[0].AxisX.Interval = ;
        }
        static int X = 160;
        static int Y = 200;
        private void button1_Click(object sender, EventArgs e)
        {
            (chart1.Tag as ChartScaleData).ResetAxisScale();
            (chart1.Tag as ChartScaleData).isZoomed = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        //private int get_diff(DateTime Start, DateTime End) { 

        //}
        private void button3_Click(object sender, EventArgs e)
        {
            //Get_Infor_Battery("Battery", 1, ref buffer_voltage, ref buffer_temperature, ref buffer_datetime, 1000);
            for (int i = 0; i < 83; i++)
            {
                Console.WriteLine(buffer_datetime[0].ToString());
                Console.WriteLine(buffer_voltage[0].ToString());
            }
        }
        private float[] buffer_voltage = new float[1000];
        private float[] buffer_temperature = new float[1000];
        private DateTime[] buffer_datetime = new DateTime[1000];
        private DateTime[] buffer_date = new DateTime[1000];
        private long[] buffer_time = new long[1000];

        Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        //private void chart1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    var pos = e.Location;
        //    if (prevPosition.HasValue && pos == prevPosition.Value)
        //        return;
        //    tooltip.RemoveAll();
        //    prevPosition = pos;
        //    var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
        //    foreach (var result in results)
        //    {
        //        if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
        //        {
        //            var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
        //            var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
        //            tooltip.Show(((float)yVal).ToString()+ " "+ ((double)xVal).ToString(), chart1, pos.X, pos.Y - 15);
        //        }
        //    }
        //}

       
        //Variables to implement a dashed zoom rectangle when the 
        //mouse is dragged over a chart with the Ctrl key pressed
        Rectangle zoomRect;         //The zoom rectanble
        bool zoomingNow = false;    //Flag to indicat that we're dragging 
                                    //to define the zoom rectangle
                                    //MouseDown, MouseMove and MouseUp handle creation and drawing of the Zoom Rectangle
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Move down");
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            this.Focus();
            //Test for Ctrl + Left Single Click to start displaying selection box
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1) &&
                    ((ModifierKeys & Keys.Control) != 0) && sender is Chart)
            {
                zoomingNow = true;
                zoomRect.Location = e.Location;
                zoomRect.Width = zoomRect.Height = 0;
                DrawZoomRect(); //Draw the new selection rect
            }
            this.Focus();
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomingNow)
            {
                DrawZoomRect(); //Redraw the old selection 
                                //rect, which erases it
                zoomRect.Width = e.X - zoomRect.Left;
                zoomRect.Height = e.Y - zoomRect.Top;
                DrawZoomRect(); //Draw the new selection rect
            }
        }

        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Move up");
            if (zoomingNow && e.Button == MouseButtons.Left)
            {
                DrawZoomRect(); //Redraw the selection 
                                //rect, which erases it
                if ((zoomRect.Width != 0) && (zoomRect.Height != 0))
                {
                    //Just in case the selection was dragged from lower right to upper left
                    zoomRect = new Rectangle(Math.Min(zoomRect.Left, zoomRect.Right),
                            Math.Min(zoomRect.Top, zoomRect.Bottom),
                            Math.Abs(zoomRect.Width),
                            Math.Abs(zoomRect.Height));
                    ZoomInToZoomRect(); //no Shift so Zoom in.
                }
                zoomingNow = false;
            }
        }
        bool useGDI32 = true;
        bool useNiceRoundNumbers = true;
        private void DrawZoomRect()
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (useGDI32)
            {
                //This is so much smoother than ControlPaint.DrawReversibleFrame
                GDI32.DrawXORRectangle(chart1.CreateGraphics(), pen, zoomRect);
            }
            else
            {
                Rectangle screenRect = chart1.RectangleToScreen(zoomRect);
                ControlPaint.DrawReversibleFrame(screenRect, chart1.BackColor, FrameStyle.Dashed);
            }
        }
        private void ZoomInToZoomRect()
        {
            if (zoomRect.Width == 0 || zoomRect.Height == 0)
                return;
            Rectangle r = zoomRect;
            ChartScaleData csd = chart1.Tag as ChartScaleData;
            Console.WriteLine(chart1.Tag);
            if (csd == null) {
                Console.WriteLine("Not declare");
                return;
            }
            Rectangle ipr = csd.innerPlotRectangle;
            if (!r.IntersectsWith(ipr))
                return;
            r.Intersect(ipr);
            if (!csd.isZoomed)
            {
                csd.isZoomed = true;
                csd.UpdateAxisBaseData();
            }
            SetZoomAxisScale(chart1.ChartAreas[0].AxisX, r.Left, r.Right);
            SetZoomAxisScale(chart1.ChartAreas[0].AxisY, r.Bottom, r.Top);
        }
        private void SetZoomAxisScale(Axis axis, int pxLow, int pxHi)
        {

            Console.WriteLine("-----------------start function SetZoomAxisScale----------------");
            double minValue = Math.Max(axis.Minimum, axis.PixelPositionToValue(pxLow));
            double maxValue = Math.Min(axis.Maximum, axis.PixelPositionToValue(pxHi));
            double axisInterval = 0.2;
            double axisIntMinor = 0.2;
            Console.WriteLine("minValue {0}", minValue);
            Console.WriteLine("maxValue {0}", maxValue);
            Console.WriteLine("axisInterval {0}", axisInterval);
            Console.WriteLine("axisIntMinor {0}", axisIntMinor);
            axisInterval = (maxValue - minValue) / 5d;
            axis.Minimum = minValue;
            axis.Maximum = maxValue;
           // axis.Interval = axisInterval;
           // axis.MinorTickMark.Interval = axisIntMinor;
            SetAxisFormats();
            Console.WriteLine("-----------------end function SetZoomAxisScale------------------------");
        }
        static double xvalue = 2;
        static double  yvalue = 3;
        private void button4_Click(object sender, EventArgs e)
        {
            if (xvalue >= chart1.ChartAreas[0].AxisX.Maximum)
            {
                chart1.ChartAreas[0].AxisX.Maximum = xvalue + 5;
            }
            chart1.Series[0].Points.AddXY(xvalue, yvalue);
            xvalue += 0.5;
            yvalue += 0.3;
        }
        int zoom_level = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (zoom_level < 5)
            {
                double max = chart1.ChartAreas[0].AxisX.Maximum;
                double min = chart1.ChartAreas[0].AxisX.Minimum;
                double new_min = (max + min) / 2;
                chart1.ChartAreas[0].AxisX.Minimum = new_min;
                zoom_level++;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                zoom_level = 0;
            }
        }

        private void SetAxisFormats()
        {
            if (true)
            {
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F2";
            }
        }

    }
    /// <summary>
    /// Container class to maintain scaleing data for each chart's axes
    /// </summary>
    public class ChartScaleData
    {
        public Chart chart;
        public int chartIndex;
        public double xBaseMin, xBaseMax, xBaseInt, xBaseMinorInt;
        public double yBaseMin, yBaseMax, yBaseInt, yBaseMinorInt;
        public bool isZoomed = false;
        public bool scalesAreValid = false;  //only true after the chart has been drawn once;

        public ChartScaleData(Chart chart)
        {
            this.chart = chart;
        }
        //store AXIS Y
        public void UpdateAxisBaseDataX()
        {
            xBaseMinorInt = chart.ChartAreas[0].AxisX.MinorTickMark.Interval;
            xBaseInt = chart.ChartAreas[0].AxisX.Interval;
            xBaseMax = chart.ChartAreas[0].AxisX.Maximum;
            xBaseMin = chart.ChartAreas[0].AxisX.Minimum;
        }
        // store AXIS X
        public void UpdateAxisBaseDataY()
        {
            yBaseMinorInt = chart.ChartAreas[0].AxisY.MinorTickMark.Interval;
            yBaseInt = chart.ChartAreas[0].AxisY.Interval;
            yBaseMax = chart.ChartAreas[0].AxisY.Maximum;
            yBaseMin = chart.ChartAreas[0].AxisY.Minimum;
        }

        public void UpdateAxisBaseData()
        {
            UpdateAxisBaseDataX();
            UpdateAxisBaseDataY();
        }

        public void ResetAxisScaleX()
        {
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = xBaseMinorInt;
            chart.ChartAreas[0].AxisX.Interval = xBaseInt;
            chart.ChartAreas[0].AxisX.Maximum = xBaseMax;
            chart.ChartAreas[0].AxisX.Minimum = xBaseMin;
        }

        public void ResetAxisScaleY()
        {
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = yBaseMinorInt;
            chart.ChartAreas[0].AxisY.Interval = yBaseInt;
            chart.ChartAreas[0].AxisY.Maximum = yBaseMax;
            chart.ChartAreas[0].AxisY.Minimum = yBaseMin;
        }

        public void ResetAxisScale()
        {
            ResetAxisScaleX();
            ResetAxisScaleY();
        }

        public RectangleF chartAreaRectangleF
        {
            get
            {
                Rectangle cr = chart.ClientRectangle;
                RectangleF rfp = chart.ChartAreas[0].Position.ToRectangleF();
                //rfp is the chart area rectangle as percentages of the entire chart ClientRectangle
                float chAreaX = rfp.Left * cr.Width / 100f;
                float chAreaY = rfp.Top * cr.Height / 100f;
                float chAreaW = rfp.Width * cr.Width / 100f;
                float chAreaH = rfp.Height * cr.Height / 100f;
                return new RectangleF(chAreaX, chAreaY, chAreaW, chAreaH);
            }
        }

        public Rectangle chartAreaRectangle { get { return Rectangle.Round(chartAreaRectangleF); } }

        public RectangleF innerPlotRectangleF
        {
            get
            {
                RectangleF rfi = chart.ChartAreas[0].InnerPlotPosition.ToRectangleF();
                //rfi is the inner plot area rectangle as percentages of the chart area rectangle 
                RectangleF chArea = chartAreaRectangleF;
                float ipX = chArea.X + rfi.Left * chArea.Width / 100f;
                float ipY = chArea.Y + rfi.Top * chArea.Height / 100f;
                float ipW = rfi.Width * chArea.Width / 100f;
                float ipH = rfi.Height * chArea.Height / 100f;
                return new RectangleF(ipX, ipY, ipW, ipH);
            }
        }

        public Rectangle innerPlotRectangle { get { return Rectangle.Round(innerPlotRectangleF); } }
    }
}

