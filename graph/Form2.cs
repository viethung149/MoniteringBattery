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

namespace graph
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.counter++;
            Console.WriteLine(Form1.counter.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            init_line_chart();
            initcombobox();
        }

        private void init_line_chart()
        {
            chart1.Tag = new ChartScaleData(chart1);
            chart1.Series.Clear();
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
            title_chart.Text = "Monitoring Battery Form 2";
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
            //tooltip
            chart1.Series[0].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series[1].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            // draw data

           //chart1.Series[0].Points.DataBindXY(buffer_datetime, buffer_voltage);
           // chart1.Series[1].Points.DataBindXY(buffer_datetime, buffer_temperature);

            // lable angle -90
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
           
            // grid
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart1.ForeColor = Color.LightGray;
        }
        private void initcombobox() {
            comboBox1.Items.Add("Cells");
            comboBox1.Items.Add("Packages");
            comboBox1.SelectedItem = comboBox1.Items[0];
        }
        private float[] buffer_voltage = new float[10000];
        private float[] buffer_temperature = new float[10000];
        private float[] buffer_current = new float[10000];

        private DateTime[] buffer_datetime = new DateTime[10000];
        private DateTime[] buffer_date = new DateTime[10000];
        private long[] buffer_time = new long[10000];
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt;
            dt = dateTimePicker1.Value;
            string table = null;
            if (comboBox1.SelectedIndex == 0)
            {
                table = "Battery";
            }
            else if (comboBox1.SelectedIndex == 1) {
                table = "Package";
            }
            int ID = Int32.Parse(comboBox2.SelectedItem.ToString());
            //int size_x_axis = Form1.access_db.Get_Infor_Battery(table, ID, ref buffer_voltage, ref buffer_temperature, ref buffer_datetime, dt);
            int size_x_axis = Form1.access_db.Get_Infor_Package("Package 1", ref buffer_voltage, ref buffer_temperature,ref buffer_current, ref buffer_datetime, dt);

            if (size_x_axis > 0)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                Console.WriteLine("number row is {0}", size_x_axis);

                for (int i = 0; i < size_x_axis; i++) {
                    chart1.Series[0].Points.AddXY(buffer_datetime[i],buffer_voltage[i]);
                    chart1.Series[1].Points.AddXY(buffer_datetime[i],buffer_temperature[i]);

                }
         

                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points[size_x_axis - 1].XValue;
                chart1.Update();
            }
            else
            {
                MessageBox.Show("No data");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Items.Clear();
                for (int i = 1; i <= 8; i++)
                {
                    comboBox2.Items.Add(i.ToString());
                }
                comboBox2.SelectedIndex = 0;
            }
            else {
                comboBox2.Items.Clear();
                for (int i = 1; i <= 3; i++)
                {
                    comboBox2.Items.Add(i.ToString());
                }
                comboBox2.SelectedIndex = 0;
            }
        }
    }
}
