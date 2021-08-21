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
        private float[] buffer_voltage = new float[10000];
        private float[] buffer_temperature = new float[10000];
        private float[] buffer_current = new float[10000];
        private int[] buffer_relay = new int[10000];
        Database db = Form1.access_db;
        private bool chart_real_time = false;
        delegate void SetChartForm2(double voltage, double temperature, double current);

        public bool Chart_real_time
        {
            get { return chart_real_time; }
        }
        private DateTime[] buffer_datetime = new DateTime[10000];
        bool voltageChart = false;
       
        bool temperatureChart = false;
        
        bool currentChart = false;
        
        string objectMonitor = null;
        public string ObjectMonitor
        {
            get { return objectMonitor; }
        }
        
        void LoadComboBoxWayMonitoring() {
            cbWay.Items.Add("Real Time");
            cbWay.Items.Add("History");
            cbWay.SelectedIndex = 0;
        }
        void LoadComboBoxWhatMonitoring() {
            cbWhat.Items.Add("Package 1");
            cbWhat.Items.Add("Package 2");
            cbWhat.Items.Add("All package");
            cbWhat.Items.Add("Cell 1 - Package 1");
            cbWhat.Items.Add("Cell 2 - Package 1");
            cbWhat.Items.Add("Cell 3 - Package 1");
            cbWhat.Items.Add("Cell 4 - Package 1");
            cbWhat.Items.Add("Cell 1 - Package 2");
            cbWhat.Items.Add("Cell 2 - Package 2");
            cbWhat.Items.Add("Cell 3 - Package 2");
            cbWhat.Items.Add("Cell 4 - Package 2");
            cbWhat.Items.Add("--None--");
            cbWhat.SelectedIndex = 0;
        }
        void LoadComboBoxPheripheralInformation() {
            cbPheri.Items.Add("Relay 1 - Package 1");
            cbPheri.Items.Add("Relay 2 - Package 2");
            cbPheri.Items.Add("Relay 3 - Fan1");
            cbPheri.Items.Add("Relay 4 - Fan2");
            cbPheri.Items.Add("All Relay");
            cbPheri.Items.Add("--None--");

            cbPheri.SelectedIndex = 0;
        }
       
        public Chart_Form()
        {
            InitializeComponent();
            LoadComboBoxWayMonitoring();
            LoadComboBoxWhatMonitoring();
            LoadComboBoxPheripheralInformation();
            cBVoltage.Checked = true;
            configChart("Time", "Voltage", "Monitoring", 0, 20);
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.CustomFormat = "HH:mm tt";
            dateTimePickerFrom.Value = DateTime.Now.AddHours(-1);
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.CustomFormat = "HH:mm tt";
            dateTimePickerTo.Value = DateTime.Now.AddMinutes(-5);

        }

        public void configChart(string titleAxisX, string titleAxisY, string title, int minY, int maxY)
        {
            // voltage: green  temperature: yellow current: blue
            chart1.Tag = new ChartScaleData(chart1);
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("chart1");
            chart1.Series.Add("Voltage");
            chart1.Series.Add("Temperature");
            chart1.Series.Add("Current");
            chart1.Series.Add("Relay1 - Package1");
            chart1.Series.Add("Relay2 - Package2");
            chart1.Series.Add("Relay3 - Fan1");
            chart1.Series.Add("Relay4 - Fan2");
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

            chart1.Series["Relay1 - Package1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Relay1 - Package1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart1.Series["Relay1 - Package1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Relay1 - Package1"].BorderWidth = 3;

            chart1.Series["Relay2 - Package2"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Relay2 - Package2"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart1.Series["Relay2 - Package2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Relay2 - Package2"].BorderWidth = 3;

            chart1.Series["Relay3 - Fan1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Relay3 - Fan1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart1.Series["Relay3 - Fan1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Relay3 - Fan1"].BorderWidth = 3;

            chart1.Series["Relay4 - Fan2"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chart1.Series["Relay4 - Fan2"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chart1.Series["Relay4 - Fan2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series["Relay4 - Fan2"].BorderWidth = 3;
            // config format Axis X
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
            chart1.Series[0].XValueMember = "Date/Time";
            chart1.Series[0].YValueMembers = "Data";
            // maker point
            chart1.Series["Voltage"].MarkerStyle = MarkerStyle.Star4;
            chart1.Series["Voltage"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Voltage"].MarkerBorderWidth = 3;

            chart1.Series["Temperature"].MarkerStyle = MarkerStyle.Diamond;
            chart1.Series["Temperature"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Temperature"].MarkerBorderWidth = 3;

            chart1.Series["Current"].MarkerStyle = MarkerStyle.Cross;
            chart1.Series["Current"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Current"].MarkerBorderWidth = 3;

            chart1.Series["Relay1 - Package1"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["Relay1 - Package1"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Relay1 - Package1"].MarkerBorderWidth = 3;

            chart1.Series["Relay2 - Package2"].MarkerStyle = MarkerStyle.Square;
            chart1.Series["Relay2 - Package2"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Relay2 - Package2"].MarkerBorderWidth = 3;

            chart1.Series["Relay3 - Fan1"].MarkerStyle = MarkerStyle.Triangle;
            chart1.Series["Relay3 - Fan1"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Relay3 - Fan1"].MarkerBorderWidth = 3;

            chart1.Series["Relay4 - Fan2"].MarkerStyle = MarkerStyle.Star10;
            chart1.Series["Relay4 - Fan2"].MarkerSize = Constant.MAKER_SIZE;
            chart1.Series["Relay4 - Fan2"].MarkerBorderWidth = 3;
            // add title
            Title title_chart = new Title();
            title_chart.Font = new Font("Arial", 14, FontStyle.Bold);
            title_chart.Text = title;
            chart1.Titles.Clear();
            chart1.Titles.Add(title_chart);
            chart1.ChartAreas[0].AxisX.Title = titleAxisX;
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
            chart1.Series["Relay1 - Package1"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series["Relay2 - Package2"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series["Relay3 - Fan1"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";
            chart1.Series["Relay4 - Fan2"].ToolTip = "#VALY{F}\n#VALX{d/M/y H:mm:ss tt}";


            // grid
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            // font
            chart1.ForeColor = Color.LightGray;
            //color
            chart1.Series["Voltage"].Color = Color.Red;
            chart1.Series["Temperature"].Color = Color.Yellow;
            chart1.Series["Current"].Color = Color.Blue;
            chart1.Series["Relay1 - Package1"].Color = Color.GreenYellow;
            chart1.Series["Relay2 - Package2"].Color = Color.Orange;
            chart1.Series["Relay3 - Fan1"].Color = Color.SpringGreen;
            chart1.Series["Relay4 - Fan2"].Color = Color.BlanchedAlmond;
            chart1.Series[0].Points.Add();
        }
        /// <summary>
        /// button accept draw the chart realtime or history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string ItemComboBoxWhat = cbWhat.SelectedItem.ToString();
            string ItemComboBoxPheri = cbPheri.SelectedItem.ToString();
            objectMonitor = cbWhat.SelectedItem.ToString();
            voltageChart = cBVoltage.Checked;
            temperatureChart = cBTemperature.Checked;
            currentChart = cBCurrent.Checked;
            render_chart(ItemComboBoxWhat, ItemComboBoxPheri, voltageChart, temperatureChart, currentChart);
            if (temperatureChart)
            {
                chart1.ChartAreas[0].AxisY.Maximum = Constant.MAX_TEMPERATURE;
            }
            else if (voltageChart)
            {
                chart1.ChartAreas[0].AxisY.Maximum = Constant.MAX_VOLTAGE;
            }
            else if (currentChart)
            {
                chart1.ChartAreas[0].AxisY.Maximum = Constant.MAX_CURREN+0.2;
              
            }
            else
            {
                chart1.ChartAreas[0].AxisY.Maximum = Constant.MAX_Y_PHERI;
            }
            if (currentChart) {
                chart1.ChartAreas[0].AxisY.Minimum = -Constant.MAX_CURREN + 0.2;
            }
            if (ItemComboBoxWhat == "--None--" && ItemComboBoxPheri == "--None--") {
                MessageBox.Show("Please select what elements you want to monitoring", "Missing information",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // render chart 
            bool RenderRealTime = (cbWay.SelectedItem.ToString() == "Real Time") ? true : false;
            if (RenderRealTime) {
                // here is render real time
                chart_real_time = true;
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(3).ToOADate();
            }
            else
            {
                chart_real_time = false;
                // here is render in database
                DateTime selectedDate = dateTimePickerDate.Value;
                DateTime selectedTimeFrom = dateTimePickerFrom.Value;
                DateTime selectedTimeTo = dateTimePickerTo.Value;
                DateTime from = new DateTime(selectedDate.Year,
                                             selectedDate.Month,
                                             selectedDate.Day,
                                             selectedTimeFrom.Hour,
                                             selectedTimeFrom.Minute,
                                             selectedTimeFrom.Second);
                DateTime to = new DateTime(selectedDate.Year,
                                           selectedDate.Month,
                                           selectedDate.Day,
                                           selectedTimeTo.Hour,
                                           selectedTimeTo.Minute,
                                           selectedTimeTo.Second);

                // if monitoring package + pheripheral
                if (is_monitor_package_peri(ItemComboBoxWhat, ItemComboBoxPheri))
                {
                    
                    string namePackage = get_name_package(ItemComboBoxWhat);
                    render_chart_only_package(namePackage, from, to, voltageChart, temperatureChart, currentChart);
                    string namePheri = get_name_pheri(ItemComboBoxPheri);
                    render_chart_only_pheri(namePheri, from, to);
                    //string namePheri = get_name
                }
                // if monitoring cell + pheripheral
                if (is_monitor_cell_peri(ItemComboBoxWhat, ItemComboBoxPheri)) {
                    int idCell = get_id_cell(ItemComboBoxWhat);
                    render_chart_only_cell(idCell, from, to, voltageChart, temperatureChart);
                    string namePheri = get_name_pheri(ItemComboBoxPheri);
                    render_chart_only_pheri(namePheri,from, to);
                }
                // if only monitor package
                if (is_only_monitor_package(ItemComboBoxWhat, ItemComboBoxPheri)) {
                    string namePackage = get_name_package(ItemComboBoxWhat);
                    Console.WriteLine("get data from package" + namePackage);
                    render_chart_only_package(namePackage, from, to, voltageChart, temperatureChart, currentChart);
                }
                // if only monitor cell
                if (is_only_monitor_cell(ItemComboBoxWhat, ItemComboBoxPheri)) {
                    // check cell 1 - 4 Package1, cell 1 -4 package 2
                    // check 3 check box
                    int idCell = get_id_cell(ItemComboBoxWhat);
                    render_chart_only_cell(idCell, from,to, voltageChart, temperatureChart);
                    return;
                }
                // if only monitor pheripheral
                if (is_only_monitor_pheripheral(ItemComboBoxWhat, ItemComboBoxPheri)) {
                    string namePheri = get_name_pheri(ItemComboBoxPheri);
                    render_chart_only_pheri(namePheri,from, to);
                }
            }

        }
        // function render chart after click button 
        public void render_chart(string WhatMonitor, string WhatPheripheral, bool ifVoltage, bool ifTemperature, bool ifCurrent)
        {
            configChart("Time", "Voltage (V) ", "Monitoring Package 2", 0, 20);
            string tittleY = "";
            string tittle = "Monitor ";
            if (cbPheri.Enabled == false) {
                if (!ifVoltage)
                {
                    chart1.Series.Remove(chart1.Series["Voltage"]);
                    
                }
                if (!ifTemperature)
                {
                    chart1.Series.Remove(chart1.Series["Temperature"]);
                }
                if (!ifCurrent)
                {
                    chart1.Series.Remove(chart1.Series["Current"]);
                }
                chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
            }
            else
            {
                if (WhatMonitor != "--None--" && WhatPheripheral == "--None--")
                {
                    if (!ifVoltage)
                    {
                        chart1.Series.Remove(chart1.Series["Voltage"]);
                    }
                    if (!ifTemperature)
                    {
                        chart1.Series.Remove(chart1.Series["Temperature"]);

                    }
                    if (!ifCurrent)
                    {
                        chart1.Series.Remove(chart1.Series["Current"]);
                    }
                    chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                    chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                    chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                    chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                }
                else if (WhatMonitor == "--None--" && WhatPheripheral != "--None--")
                {
                    chart1.Series.Remove(chart1.Series["Voltage"]);
                    chart1.Series.Remove(chart1.Series["Temperature"]);
                    chart1.Series.Remove(chart1.Series["Current"]);
                    switch (WhatPheripheral)
                    {
                        case "Relay 1 - Package 1":
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 2 - Package 2":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 3 - Fan1":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 4 - Fan2":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            break;
                    }
                }
                else
                {
                    if (!ifVoltage)
                    {
                        chart1.Series.Remove(chart1.Series["Voltage"]);
                    }
                    if (!ifTemperature)
                    {
                        chart1.Series.Remove(chart1.Series["Temperature"]);

                    }
                    if (!ifCurrent)
                    {
                        chart1.Series.Remove(chart1.Series["Current"]);
                    }
                    switch (WhatPheripheral)
                    {
                        case "Relay 1 - Package 1":
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 2 - Package 2":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 3 - Fan1":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay4 - Fan2"]);
                            break;
                        case "Relay 4 - Fan2":
                            chart1.Series.Remove(chart1.Series["Relay1 - Package1"]);
                            chart1.Series.Remove(chart1.Series["Relay2 - Package2"]);
                            chart1.Series.Remove(chart1.Series["Relay3 - Fan1"]);
                            break;
                    }
                }
            }
            
        }
        // fucntion check is monitor only cells
        // return true if check monitor cells
        // return false if not
        public bool is_only_monitor_cell(string WhatMonitoring, string ifPheripheral) {
            if (WhatMonitoring != "Package 1" &&
               WhatMonitoring != "Package 2" &&
               WhatMonitoring != "All package" &&
               WhatMonitoring != "--None--" &&
               ifPheripheral == "--None--")
            {
                return true;
            }
            return false;
        }
        // return id cell get
        public int get_id_cell(string cell)
        {
            switch (cell)
            {
                case "Cell 1 - Package 1":
                    return 1;
                case "Cell 2 - Package 1":
                    return 2;
                case "Cell 3 - Package 1":
                    return 3;
                case "Cell 4 - Package 1":
                    return 4;
                case "Cell 1 - Package 2":
                    return 5;
                case "Cell 2 - Package 2":
                    return 6;
                case "Cell 3 - Package 2":
                    return 7;
                case "Cell 4 - Package 2":
                    return 8;
            }
            return -1;
        }

        public bool is_only_monitor_package(string WhatMonitoring, string ifPheripheral)
        {
            if ((WhatMonitoring == "Package 1" ||
                 WhatMonitoring == "Package 2" ||
                 WhatMonitoring == "All package") &&
                 ifPheripheral == "--None--")
            {
                return true;
            }
            return false;
        }
        public string get_name_package(string WhatMonitoring) {
            switch (WhatMonitoring)
            {
                case "Package 1":
                    return "Package 1";
                case "Package 2":
                    return "Package 2";
                case "All package":
                    return "All Package";
            }
            return null;
        }
        public void render_chart_only_cell(int idCell, DateTime from, DateTime to, bool ifVoltage, bool ifTemperature)
        {
            //chart1.Series
            int rows = db.Get_Infor_Battery(idCell, ref buffer_voltage, ref buffer_temperature, ref buffer_datetime,from, to);
            if (rows > 0) {
                Console.WriteLine("number of Data infor cell is:{0}", rows);
                if (ifVoltage && ifTemperature)
                {
                    chart1.Series["Voltage"].Points.Clear();
                    chart1.Series["Temperature"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series[0].Points.AddXY(buffer_datetime[i], buffer_voltage[i]);
                        chart1.Series[1].Points.AddXY(buffer_datetime[i], buffer_temperature[i]);
                    }

                }
                else if (ifVoltage) {
                    chart1.ChartAreas[0].AxisY.Maximum = 5;
                    chart1.Series["Voltage"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series["Voltage"].Points.AddXY(buffer_datetime[i], buffer_voltage[i]);
                    }
                }
                else if (ifTemperature)
                {
                    chart1.Series["Temperature"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series["Temperature"].Points.AddXY(buffer_datetime[i], buffer_voltage[i]);
                    }
                }
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points[rows - 1].XValue;
                chart1.Update();
            }
            else
            {
                MessageBox.Show("No data");
            }
        }
        public void render_chart_only_package(string namePackage, DateTime from, DateTime to, bool ifVoltage, bool ifTemperature, bool ifCurrent) {
            int rows = Form1.access_db.Get_Infor_Package(namePackage, ref buffer_voltage, ref buffer_temperature, ref buffer_current, ref buffer_datetime, from,to);
            Console.WriteLine("Numberber data of package infor is {0}", rows);
            if (rows > 0)
            {
                if (ifVoltage)
                {
                    chart1.Series["Voltage"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series["Voltage"].Points.AddXY(buffer_datetime[i], buffer_voltage[i]);
                    }

                }
                if (ifTemperature)
                {
                    chart1.Series["Temperature"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series["Temperature"].Points.AddXY(buffer_datetime[i], buffer_temperature[i]);
                    }
                }
                if (ifCurrent)
                {
                    chart1.Series["Current"].Points.Clear();
                    for (int i = 0; i < rows; i++)
                    {
                        chart1.Series["Current"].Points.AddXY(buffer_datetime[i], buffer_current[i]);
                    }
                }
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points[rows - 1].XValue;
                chart1.Update();
            }
            else
            {
                MessageBox.Show("No data");
            }

        }
        public bool is_monitor_cell_peri(string WhatMonitoring, string ifPheripheral) {
            if (ifPheripheral != "--None--" &&
                (WhatMonitoring != "Package 1" && WhatMonitoring != "Package 2" && WhatMonitoring != "All package") &&
                WhatMonitoring != "--None--") {
                return true;
            }
            return false;
        }
        public bool is_monitor_package_peri(string WhatMonitoring, string ifPheripheral)
        {
            if (ifPheripheral != "--None--" &&
                (WhatMonitoring == "Package 1" || WhatMonitoring == "Package 2" || WhatMonitoring == "All package") &&
                WhatMonitoring !="--None--")
            {
                return true;
            }
            return false;
        }
        public bool is_only_monitor_pheripheral(string WhatMonitoring, string ifPheripheral) {
            if (WhatMonitoring == "--None--" && ifPheripheral != "--None--")
            {
                return true;
            }
            return false;
        }
        public string get_name_pheri(string ifPheripheral)
        {
            switch (ifPheripheral)
            {
                case "Relay 1 - Package 1":
                    return "Relay 1 - Package 1";
                case "Relay 2 - Package 2":
                    return "Relay 2 - Package 2";
                case "Relay 3 - Fan1":
                    return "Relay 3 - Fan 1";
                case "Relay 4 - Fan2":
                    return "Relay 4 - Fan 2";
                case "All Relay":
                    return "all";
            }
            return null;
        }
        public void render_chart_only_pheri(string namePheri, DateTime from, DateTime to) {
            if (namePheri != "all")
            {
                int rows = Form1.access_db.Get_Infor_Pheri(namePheri, ref buffer_relay, ref buffer_datetime, from, to);
                Console.WriteLine("Number data of package pheripheral is {0}", rows);
                if (rows > 0)
                {
                    switch (namePheri)
                    {
                        case "Relay 1 - Package 1":
                            for (int i = 0; i < rows; i++)
                            {
                                chart1.Series["Relay1 - Package1"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                            }
                            break;
                        case "Relay 2 - Package 2":
                            for (int i = 0; i < rows; i++)
                            {
                                chart1.Series["Relay2 - Package2"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                            }
                            break;
                        case "Relay 3 - Fan 1":
                            for (int i = 0; i < rows; i++)
                            {
                                chart1.Series["Relay3 - Fan1"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                            }
                            break;
                        case "Relay 4 - Fan 2":
                            for (int i = 0; i < rows; i++)
                            {
                                chart1.Series["Relay4 - Fan2"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                            }
                            break;



                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("No data");
                }
            }
            else
            {
                int rows_1 = Form1.access_db.Get_Infor_Pheri("Relay 1 - Package 1", ref buffer_relay, ref buffer_datetime, from,to);
                if (rows_1 > 0)
                {
                    for (int i = 0; i < rows_1; i++)
                    {
                        chart1.Series["Relay1 - Package1"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No data");

                    return;
                }
                int rows_2 = Form1.access_db.Get_Infor_Pheri("Relay 2 - Package 2", ref buffer_relay, ref buffer_datetime, from,to);
                if (rows_2 > 0)
                {
                  for (int i = 0; i < rows_2; i++)
                    {
                        chart1.Series["Relay2 - Package2"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No data");

                    return;
                }
                int rows_3 = Form1.access_db.Get_Infor_Pheri("Relay 3 - Fan 1", ref buffer_relay, ref buffer_datetime, from, to);
                if (rows_3 > 0)
                {
                    for (int i = 0; i < rows_3; i++)
                    {
                        chart1.Series["Relay3 - Fan1"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No data");

                    return;
                }
                int rows_4 = Form1.access_db.Get_Infor_Pheri("Relay 4 - Fan 2", ref buffer_relay, ref buffer_datetime, from, to);
                if (rows_4 > 0)
                {
                    for (int i = 0; i < rows_4; i++)
                    {
                        chart1.Series["Relay4 - Fan2"].Points.AddXY(buffer_datetime[i], buffer_relay[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No data");

                    return;
                }

            }


        }
        public void render_chart_real_time(double voltage, double temperature, double current) {
           
            try
            {
                
                if (chart1.InvokeRequired)
                {
                    SetChartForm2 d = new SetChartForm2(render_chart_real_time);
                    this.Invoke(d, voltage, temperature, current);
                }
                else
                {
                    if (DateTime.Now.ToOADate() >= chart1.ChartAreas[0].AxisX.Maximum)
                    {
                        chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(3).ToOADate();
                    }
                    if (voltageChart)
                    {
                        chart1.Series["Voltage"].Points.AddXY(DateTime.Now,voltage );
                    }
                    if (temperatureChart)
                    {
                        chart1.Series["Temperature"].Points.AddXY(DateTime.Now,temperature);
                    }
                    if (currentChart)
                    {
                        chart1.Series["Current"].Points.AddXY(DateTime.Now,current);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }  
        }
       
        private void btnScale_Click(object sender, EventArgs e)
        {
            if ((chart1.Tag as ChartScaleData).isZoomed == true)
            {
                Console.WriteLine("Zoom out chart 1");
                (chart1.Tag as ChartScaleData).ResetAxisScale();
                (chart1.Tag as ChartScaleData).isZoomed = false;
            }
        }

        private void Chart_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.FLAG_REALTIME_CHART = 0;
            this.Hide(); // hide the form instead of closing
            e.Cancel = true; // this cancels the close event.
            Console.WriteLine(Form1.FLAG_REALTIME_CHART);
        }

        private void cbWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWay.SelectedItem.ToString() == "Real Time")
            {
                
                cbPheri.Enabled = false;
                dateTimePickerDate.Enabled = false;
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else
            {
                chart_real_time = false;
                cbPheri.Enabled = true;
                dateTimePickerDate.Enabled = true;
                dateTimePickerFrom.Enabled = true;
                dateTimePickerTo.Enabled = true;
            }
        }

        private void cbWhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbWhat.SelectedItem.ToString();
            if (selected != "Package 1" && selected != "Package 2" && selected != "All package" && selected !="--None--") {
                cBCurrent.Checked = false;
                cBCurrent.Enabled = false;
            }
            else if(selected == "--None--")
            {
                cBVoltage.Checked = false;
                cBVoltage.Enabled = false;
                cBTemperature.Checked = false;
                cBTemperature.Enabled = false;
                cBCurrent.Checked = false;
                cBCurrent.Enabled = false;
            }
            else
            {
                cBTemperature.Enabled = true;
                cBVoltage.Enabled = true;
                cBCurrent.Enabled = true;
            }
        }
        // tool tip for chart 1
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                       ChartElementType.DataPoint);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15);

                        }
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //PrintDialog a = new PrintDialog();
            //chart1.Printing.Print(true);
            reportPrinter1.Print();
        }
        // ZOOM 
        Rectangle zoomRectChart1;
        bool zoomingChart1Now = false;
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Chart Real Time Move down");
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            this.Focus();
            //Test for Ctrl + Left Single Click to start displaying selection box
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1) &&
                    ((ModifierKeys & Keys.Control) != 0) && sender is Chart)
            {
                zoomingChart1Now = true;
                zoomRectChart1.Location = e.Location;
                zoomRectChart1.Width = zoomRectChart1.Height = 0;
                DrawZoomRect(); //Draw the new selection rect
            }
            this.Focus();
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomingChart1Now)
            {
                DrawZoomRect(); //Redraw the old selection 
                                //rect, which erases it
                zoomRectChart1.Width = e.X - zoomRectChart1.Left;
                zoomRectChart1.Height = e.Y - zoomRectChart1.Top;
                DrawZoomRect(); //Draw the new selection rect
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Move up in real time chart");
            if (zoomingChart1Now && e.Button == MouseButtons.Left)
            {
                DrawZoomRect(); //Redraw the selection 
                                //rect, which erases it
                if ((zoomRectChart1.Width != 0) && (zoomRectChart1.Height != 0))
                {
                    //Just in case the selection was dragged from lower right to upper left
                    zoomRectChart1 = new Rectangle(Math.Min(zoomRectChart1.Left, zoomRectChart1.Right),
                            Math.Min(zoomRectChart1.Top, zoomRectChart1.Bottom),
                            Math.Abs(zoomRectChart1.Width),
                            Math.Abs(zoomRectChart1.Height));
                    ZoomInToZoomRect(); //no Shift so Zoom in.
                }
                zoomingChart1Now = false;
            }
        }
        bool useGDI32_chart1 = true;
        private void DrawZoomRect()
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (useGDI32_chart1)
            {
                //This is so much smoother than ControlPaint.DrawReversibleFrame
                GDI32.DrawXORRectangle(chart1.CreateGraphics(), pen, zoomRectChart1);
            }
            else
            {
                Rectangle screenRect = chart1.RectangleToScreen(zoomRectChart1);
                ControlPaint.DrawReversibleFrame(screenRect, chart1.BackColor, FrameStyle.Dashed);
            }
        }
        private void ZoomInToZoomRect()
        {
            if (zoomRectChart1.Width == 0 || zoomRectChart1.Height == 0)
                return;
            Rectangle r = zoomRectChart1;
            ChartScaleData csd = chart1.Tag as ChartScaleData;
            Console.WriteLine(chart1.Tag);
            if (csd == null)
            {
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
        private void SetAxisFormats()
        {
            if (true)
            {
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F2";
            }
        }

        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((chart1.Tag as ChartScaleData).isZoomed == true)
            {
                Console.WriteLine("Zoom out chart 1");
                (chart1.Tag as ChartScaleData).ResetAxisScale();
                (chart1.Tag as ChartScaleData).isZoomed = false;
            }
        }

        private void Chart_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBinDateorTime.Checked)
            {
                dateTimePickerFrom.Value = DateTime.Now.AddHours(-1);
                dateTimePickerTo.Value = DateTime.Now.AddMinutes(-5);
            }
            else
            {
                dateTimePickerFrom.Value = new DateTime(2021, 06, 19, 0, 0, 0);
                dateTimePickerTo.Value = new DateTime(2021, 06, 19, 23, 59, 0);
            }
        }

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Chart_Form_Load_1(object sender, EventArgs e)
        {

        }
    }
}
