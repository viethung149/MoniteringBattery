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

namespace graph
{
    public partial class Form1 : Form
    {
        Database access_db = new Database();
        public static int counter = 0;
        MyDateTimeSeries series1, series2;
        
        public Form1()
        {
            InitializeComponent();

        }
        private void fillChart(DateTime start, DateTime end, DateTime number)
        {
            lineChart.LicenseKey = "license key stays here";
            series1 = new MyDateTimeSeries(start, end, number);
            series1.DateTimeFormat = DateTimeFormat.ShortTime;
            //how many values will be added before a time stamp is rendered at the axis
            series1.LabelInterval = 20;
            series1.MinValue = 0;
            series1.MaxValue = 100;
            series1.Title = "Voltage";
            series1.SupportedLabels = LabelKinds.XAxisLabel;

            series2 = new MyDateTimeSeries(start,end,number);
            series2.DateTimeFormat = DateTimeFormat.ShortTime;
            series2.LabelInterval = 20;
            series2.MinValue = 0;
            series2.MaxValue = 100;
            series2.Title = "Temperature";
            series2.SupportedLabels = LabelKinds.None;
            // setup chart
            lineChart.Series.Add(series1);
            lineChart.Series.Add(series2);
            lineChart.Title = "Real-time Monitor Load";
            lineChart.ShowXCoordinates = false;
            lineChart.ShowLegendTitle = false;
            lineChart.LayoutPanel.Margin = new Margins(20, 20, 20, 20);

            lineChart.XAxis.Title = "Time";
            lineChart.XAxis.MinValue = 0;
            lineChart.XAxis.MaxValue = 120;
            lineChart.XAxis.Interval = 20;

            lineChart.YAxis.MinValue = 0;
            lineChart.YAxis.MaxValue = 120;
            lineChart.YAxis.Interval = 10;
            lineChart.YAxis.Title = "Current Voltage(V)\n Temperature(C)";

            List<Brush> brushes = new List<Brush>()
            {
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.Orange),
            };

            List<double> thicknesses = new List<double>() { 2 };

            PerSeriesStyle style = new PerSeriesStyle(brushes, brushes, thicknesses, null);
            lineChart.AllowZoom = true;
            lineChart.LineType = LineType.Curve;
            lineChart.Plot.SeriesStyle = style;
            lineChart.Theme.PlotBackground = new SolidBrush(Color.White);
            lineChart.Theme.GridLineColor = Color.LightGray;
            lineChart.Theme.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            lineChart.TitleMargin = new Margins(10);
            lineChart.GridType = GridType.Horizontal;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            access_db.StrConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\App_C#\\Template\\listView_Test\\test.accdb";
            access_db.Conn = new OleDbConnection(access_db.StrConn);
            access_db.connect_access();
            Get_Infor_Battery("Battery", 1, ref buffer_voltage, ref buffer_temperature, ref buffer_datetime, 1000);
            fillChart(buffer_datetime[0], buffer_datetime[0], buffer_datetime[82]);
        }
        static int X = 160;
        static int Y = 200;
        private void button1_Click(object sender, EventArgs e)
        {
        
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
            for (int i = 0; i < 83; i++) {
                Console.WriteLine(buffer_datetime[0].ToString());
                Console.WriteLine(buffer_voltage[0].ToString());
                series1.addValue(buffer_voltage[i], buffer_datetime[i]);
                series2.addValue(buffer_temperature[i], buffer_datetime[i]);
            }
                

                //series2.addValue(buffer_temperature[i], buffer_datetime[i]);
                if (series1.Size > 1)
                {
                    double currVal = series1.GetValue(series1.Size - 1, 0);

                    if (currVal > lineChart.XAxis.MaxValue)
                    {
                        double span = currVal - series1.GetValue(series1.Size - 2, 0);
                        lineChart.XAxis.MinValue += span;
                        lineChart.XAxis.MaxValue += span;

                    }
                    lineChart.ChartPanel.InvalidateLayout();

            }
        }
        private float[] buffer_voltage = new float[1000];
        private float[] buffer_temperature = new float[1000];
        private DateTime[] buffer_datetime = new DateTime[1000];
        private DateTime[] buffer_date = new DateTime[1000];
        private DateTime[] buffer_time = new DateTime[1000];
        private System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
        private void lineChart_DataItemClicked(object sender, HitResult e)
        {
            tooltip.RemoveAll();
            double voltage = e.Value;
            int index = e.Index;
            long time = series1.dates[index];
            DateTime dt = new DateTime(time);
            Console.WriteLine("voltage is {0} time is {1}", voltage,dt.ToString());
            string infor = voltage.ToString("0.000") + " at " + dt.ToString("HH:mm");
            tooltip.AutoPopDelay = 5000;
            tooltip.Show(infor,lineChart);
        }

        private void Get_Infor_Battery(String table_name,
                                        int ID_battery,
                                        ref float[] buffer_voltage,
                                        ref float[] buffer_temperature,
                                        ref DateTime[] buffer_datetime,
                                        int SIZE_BUFFER) {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = access_db.Conn;
            command.CommandText = "SELECT Voltage, Temperature, Time FROM " + "Battery" + " WHERE Battery.IDbattery = @ID";
            command.Parameters.Add("@ID", OleDbType.Integer).Value = ID_battery;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("Voltage battery 1 is {0} Temperature is {1} at Time {2}",
                        row["Voltage"].ToString(), row["Temperature"].ToString(), row["Time"].ToString());
                if (index_row < SIZE_BUFFER) {
                    buffer_voltage[index_row] = float.Parse(row["Voltage"].ToString());
                    buffer_temperature[index_row] = float.Parse(row["Temperature"].ToString());
                    buffer_datetime[index_row] = DateTime.ParseExact(row["Time"].ToString(), "yyyy:MM:dd hh:mm:ss", null); 
                    index_row++;
                }
                //Console.WriteLine("Data after convert is {0}, {1}, {2}", Voltage, Temperature, Time);
            }
            }
        }
    }

