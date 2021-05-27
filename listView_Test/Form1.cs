using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using DateTimeSeries;
using MindFusion.Charting;
using Brush = MindFusion.Drawing.Brush;
using SolidBrush = MindFusion.Drawing.SolidBrush;
namespace listView_Test
{

    public partial class Form1 : Form
    {
        public static int FLAG_REALTIME_CHART = 0;
        Database access_db = new Database();
        public int INDEX_BATTERY = 1;
        public int INDEX_PACKAGE = 1;
        public int INDEX_PHERI = 1;
        public static float[] battery_voltage = new float[Constant.NUMBER_BATTERY];
        private float[] battery_temperature = new float[Constant.NUMBER_BATTERY];
        // notify over voltage or temperature
        private bool[] status_adding = new bool[Constant.NUMBER_BATTERY];
        private bool[] status_battery = new bool[Constant.NUMBER_BATTERY];
        // notify over temperature
        private bool[] status_emer_bar1 = new bool[Constant.NUMBER_BATTERY];
        private bool[] status_emer_bar2 = new bool[Constant.NUMBER_BATTERY];
        // notify the status of peripheral
        private bool[] status_peripheral = new bool[Constant.NUMBER_PHERI];
        // set delegate to handle serial
        delegate void SetTextCallBack(string text);
        // set delegate to handle settable infor
        delegate void SetTable_battery(float[] battery_voltage,
                               float[] temp,
                               bool[] status_adding,
                               bool[] status_temp,
                               bool[] status_emer_bar1,
                               bool[] status_emer_bar2,
                               int size);
        // set deletage to handle settble package
        delegate void SetTable_package(float[] battery_voltage,
                              float[] temp,
                              bool[] status_battery,
                              bool[] status_peripheral,
                              int size);
        public Chart_Form chart_form = new Chart_Form();


        private void init_listView_battery() {
            Battery init = new Battery();
            init.voltage = (float)0.0;
            init.temperature = (float)0.0;
            init.status_balance = false;
            init.warning_voltage = false;
            init.warning_temperature = false;
            for (int i = 1; i <= 8; i++) {
                Display.Add_row_data_battery(i, init, this);
            }
        }
        private void init_listView_package()
        {
            Package init = new Package();
            init.capacity = (float)0.0;
            init.temperater = (float)0.0;
            init.current = (float)0.0;
            init.status_balance = false;
            init.status_connect = 0;
            init.warning = false;
            for (int i = 1; i <= Constant.NUMBER_PACKET; i++)
            {
                Display.Add_row_data_package(i, init, this);
            }
        }
        private void init_listView_pheripheral()
        {
            Peripheral init = new Peripheral();
            init.status_connect = false;
            for (int i = 1; i <= Constant.NUMBER_PHERI; i++)
            {
                Display.Add_row_data_pheripheral(i, init, this);
            }
        }
        public Form1()
        {
            InitializeComponent();
            LoadTabControl();
            LoadListView_battery();
            LoadListView_Package();
            LoadListView_Pheripheral();
            Port.DataReceived += new SerialDataReceivedEventHandler(uart_read_even);
            access_db.StrConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\App_C#\\Template\\listView_Test\\test.accdb";
            access_db.Conn = new OleDbConnection(access_db.StrConn);
            access_db.connect_access();

        }
        void LoadTabControl() {
            CustomTabControl.Dock = DockStyle.None;
            this.tabBattery.Controls.Add(this.CustomListView_Battery);
            this.tabPackage.Controls.Add(this.CustomListView_Package);
            this.tabPheripheral.Controls.Add(this.CustomListView_Pheripheral);
        }
        void LoadListView_battery() {
            CustomListView_Battery.FullRowSelect = true;
            CustomListView_Battery.GridLines = true;
            CustomListView_Battery.Columns.Add("Name Battery ");
            CustomListView_Battery.Columns.Add("Voltage");
            CustomListView_Battery.Columns.Add("Temperater");
            CustomListView_Battery.Columns.Add("Blance status");
            CustomListView_Battery.Columns.Add("Warning Voltage");
            CustomListView_Battery.Columns.Add("Warning Temperature");


            //ListViewItem item1 = new ListViewItem();
            //item1.Text = "Item1";
            //item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "Sub Item 1" });
            for (int i = 1; i <= Constant.NUMBER_BATTERY / 2; i++) {
                CustomListView_Battery.Items.Add("Battery " + i.ToString());
            }
            CustomListView_Battery.View = View.Details;
            CustomListView_Battery.Dock = DockStyle.Fill;
            init_listView_battery();
        }
        void LoadListView_Package() {
            CustomListView_Battery.FullRowSelect = true;
            CustomListView_Battery.GridLines = true;
            CustomListView_Package.View = View.Details;
            CustomListView_Package.Dock = DockStyle.Fill;
            CustomListView_Package.FullRowSelect = true;
            CustomListView_Package.GridLines = true;
            CustomListView_Package.Columns.Add("Name Package");
            CustomListView_Package.Columns.Add("Capacity");
            CustomListView_Package.Columns.Add("Temperater");
            CustomListView_Package.Columns.Add("Current");
            CustomListView_Package.Columns.Add("Balance");
            CustomListView_Package.Columns.Add("Connect");
            CustomListView_Package.Columns.Add("Warning");
            CustomListView_Package.Items.Add("Package 1");
            CustomListView_Package.Items.Add("Package 2");
            CustomListView_Package.Items.Add("All system");
        }
        void LoadListView_Pheripheral()
        {
            CustomListView_Pheripheral.FullRowSelect = true;
            CustomListView_Pheripheral.GridLines = true;
            CustomListView_Pheripheral.View = View.Details;
            CustomListView_Pheripheral.Dock = DockStyle.Fill;
            CustomListView_Pheripheral.FullRowSelect = true;
            CustomListView_Pheripheral.GridLines = true;
            CustomListView_Pheripheral.Columns.Add("Name Pheripheral");
            CustomListView_Pheripheral.Columns.Add("Status");

            CustomListView_Pheripheral.Items.Add("Fan 1");
            CustomListView_Pheripheral.Items.Add("Fan 2");
            CustomListView_Pheripheral.Items.Add("Relay package 1");
            CustomListView_Pheripheral.Items.Add("Relay package 2");
            CustomListView_Pheripheral.Items.Add("Relay package 3");

        }
        void LoadComboBox_Serial()
        {
            var ports = SerialPort.GetPortNames();
            cbComport.DataSource = ports;

            int[] baudrate = { 9600, 14400, 19200, 38400, 56000, 57600, 115200 };
            cbBaurate.DataSource = baudrate;

            int[] data_size = { 7, 8 };
            cbData.DataSource = data_size;

            string[] parity = { "None", "Even", "Odd" };
            cbParity.DataSource = parity;

            double[] stop_bits = { 1, 1.5, 2 };
            cbStop.DataSource = stop_bits;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.btnChart, "Click here to open chart");
            LoadComboBox_Serial();
            config_real_time_chart();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("timer check 1");
            Battery test = new Battery();
            Random rand = new Random();
            test.voltage = (float)rand.NextDouble() * 3;
            test.temperature = (float)rand.NextDouble() * 30;
            test.status_balance = rand.Next(0, 2) > 0;
            //test.warning = rand.Next(0, 2) > 0;
            Display.Add_row_data_battery(INDEX_BATTERY++, test, this);
            if (INDEX_BATTERY == Constant.NUMBER_BATTERY + 1) INDEX_BATTERY = 1;
        }

        private void TimerModifPackage_Tick(object sender, EventArgs e)
        {
        //    //Console.WriteLine("timer check  2");
        //    Package test = new Package();
        //    Random rand = new Random();
        //    test.capacity = (float)rand.NextDouble() * 3;
        //    test.temperater = (float)rand.NextDouble() * 30;
        //    test.current = (float)rand.NextDouble() * 30;
        //    test.status_balance = rand.Next(0, 2) > 0;
        //    test.status_connect = rand.Next(0, 2) > 0;
        //    test.status_active = rand.Next(3);
        //    Display.Add_row_data_package(INDEX_PACKAGE++, test, this);
        //    if (INDEX_PACKAGE == Constant.NUMBER_PACKET + 1) INDEX_PACKAGE = 1;
        }

        private void timerModifyPheripheral_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("timer check  3");
            Peripheral test = new Peripheral();
            Random rand = new Random();
            test.status_connect = rand.Next(0, 2) > 0;
            Display.Add_row_data_pheripheral(INDEX_PHERI++, test, this);
            if (INDEX_PHERI == Constant.NUMBER_PHERI + 1) INDEX_PHERI = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Port.IsOpen)
            {
                Port.PortName = cbComport.SelectedItem.ToString();
                Port.BaudRate = Int32.Parse(cbBaurate.SelectedItem.ToString());
                Port.DataBits = Int32.Parse(cbData.SelectedItem.ToString());
                switch (cbStop.SelectedItem.ToString())
                {
                    case "1":
                        Port.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        Port.StopBits = StopBits.OnePointFive;
                        break;
                    default:
                        Port.StopBits = StopBits.Two;
                        break;
                }
                switch (cbParity.SelectedItem.ToString())
                {
                    case "None":
                        Port.Parity = Parity.None;
                        break;
                    case "Odd":
                        Port.Parity = Parity.Odd;
                        // code block
                        break;
                    default:
                        Port.Parity = Parity.Even;
                        // code block
                        break;
                }
                Port.Handshake = Handshake.None;
                try
                {
                    Port.ReceivedBytesThreshold = 1;
                    Port.Open();
                    btnConnectSerial.Text = "Disconnect";
       
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else {
                Port.Close();
                btnConnectSerial.Text = "Connect";

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cbComport.DataSource = ports;
        }
        private int counter = 1;
        private byte[] buffer_rx = new byte[200];
        private byte[] data = new byte[135];
        private int number_byte_read = 0;
        private bool update = false;
        private void uart_read_even(object sender, SerialDataReceivedEventArgs e)
        {
            byte crc = 0x00;
            int bytes = Port.BytesToRead;
            byte[] read = new byte[bytes];
            Port.Read(read, 0, bytes);
            if (bytes == 0) return;
            
            //string 
            string content = " test ";
            foreach (var item in read)
            {
                if (number_byte_read >= 200) number_byte_read = 0;
                buffer_rx[number_byte_read] = (byte)item;
                Console.WriteLine("number: {0} byte {1:X2}", number_byte_read, buffer_rx[number_byte_read]);
                
                
                if (buffer_rx[134] == '\r')
                {
                    Array.Copy(buffer_rx, 0, data, 0, 135);
                    number_byte_read = -1;
                    Array.Clear(buffer_rx, 0, buffer_rx.Length);
                    update = true;
                }
                else if (buffer_rx[number_byte_read] == '\r' && number_byte_read != 134) {
                    Console.WriteLine("byte wrong {0:X2} number {1}", buffer_rx[number_byte_read], number_byte_read);
                    number_byte_read = -1;
                    Console.WriteLine("Wrong end data");
                }
                number_byte_read++;
                content += " " + ((byte)item).ToString("X2");
            }
            Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("in event " + counter.ToString() + content +"with number byte is " +bytes.ToString());
            counter++;

            // bytes = 8;
            //byte[] buffer_rx = new byte[bytes];
            //Port.Read(buffer_rx, 0, bytes);
            if (update) {
                update = false;
                if (data[0] == 'I' || data[0] == 'E')
                {
                    int number_bytes = data.Length;
                    string content1 = "number of bytes read is" + data.Length.ToString() + ": ";
                    foreach (var item in data)
                    {
                        content1 += " " + item.ToString("X2");
                    }
                    if (Data.check_correct_emerPackage(data,
                                                        number_bytes,
                                                        ref status_emer_bar1,
                                                        ref status_emer_bar2,
                                                        Constant.NUMBER_BATTERY))
                    {
                        content1 += "success emer";
                    }
                    else if (Data.check_correct_inforPackage(data,
                                                        number_bytes,
                                                        ref battery_voltage,
                                                        ref battery_temperature,
                                                        Constant.NUMBER_BATTERY,
                                                        ref status_battery,
                                                        ref status_adding,
                                                        Constant.NUMBER_BATTERY))
                    {
                        content1 += " success infor";
                        if (FLAG_REALTIME_CHART == 1)
                        {
                            // adding data to chart form
                            Data_chart.add_point("Battery Voltage", 100, 100, chart_form);
                        }
                        SetListView_Infor(battery_voltage, battery_temperature, status_battery, status_adding, status_emer_bar1, status_emer_bar2, Constant.NUMBER_BATTERY);
                        SetListView_Pakage(battery_voltage, battery_temperature, status_battery, status_peripheral ,Constant.NUMBER_BATTERY);
                        SetRealTimeChart(battery_voltage, battery_temperature, Constant.NUMBER_BATTERY);
                    }

                    //Port.DiscardInBuffer();
                    SetText(content1);

                }
                else
                {

                    Port.DiscardInBuffer();
                    return;
                }
            }

        }
        public void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetText);
                this.Invoke(d, new string[] { text });
            }
            else
            {
                richTextBox1.Clear();
                this.richTextBox1.Text = text;
            }

        }

        public void SetListView_Infor(float[] battery_voltage,
                         float[] temperature,
                         bool[] status_battery,
                         bool[] status_adding,
                         bool[] status_emer_bar1,
                         bool[] status_emer_bar2,
                         int size)
        {
            if (this.CustomListView_Battery.InvokeRequired)
            {
                SetTable_battery d = new SetTable_battery(SetListView_Infor);
                this.Invoke(d, battery_voltage, temperature, status_battery, status_adding, status_emer_bar1, status_emer_bar2, 16);
            }
            else
            {
                for (int i = 0; i < size / 2; i++)
                {
                    Battery temp = new Battery();
                    temp.voltage = battery_voltage[i];
                    temp.temperature = battery_temperature[i];
                    temp.status_balance = false;
                    temp.warning_temperature = status_battery[i];
                    temp.warning_voltage = status_battery[i+8];
                    Display.Add_row_data_battery(i + 1, temp, this);
                    access_db.insert_battery("Battery", temp, i + 1);
                }
            }

        }
        public void SetListView_Pakage(float[] battery_voltage,
                         float[] temperature,
                         bool[] status_battery,
                         bool[] status_peripheral,
                         int size)
        {
            if (this.CustomListView_Battery.InvokeRequired)
            {
                SetTable_package d = new SetTable_package(SetListView_Pakage);
                this.Invoke(d, battery_voltage, temperature, status_battery, status_peripheral, size);
            }
            else
            {
                bool status_package_1 = false;
                bool status_package_2= false;
                bool status_temperature_package_1 = false;
                bool status_voltage_package_1 = false;
                bool status_temperature_package_2= false;
                bool status_voltage_package_2= false;
                bool FAN_1 = status_peripheral[0];
                bool FAN_2 = status_peripheral[1];
                bool PACKAGE_1 = status_peripheral[2];
                bool PACKAGE_2 = status_peripheral[3];
                for (int i = 0; i < 4; i++) {
                    status_temperature_package_1 |= status_battery[i];
                    status_voltage_package_1 |= status_battery[i + 8];
                };
                for (int i = 4; i < 8; i++)
                {
                    status_temperature_package_2 |= status_battery[i];
                    status_voltage_package_2 |= status_battery[i + 8];
                };
                status_package_1 = status_temperature_package_1 | status_voltage_package_1;
                status_package_2 = status_temperature_package_2 | status_voltage_package_2;

                Package row1 = new Package();
                row1.capacity = battery_voltage[0] + battery_voltage[1] + battery_voltage[2] + battery_voltage[3];
                row1.current = battery_temperature[8];
                // if current < 0 discharge current>0 charge (dong duong khi sac dong am khi xa)
                row1.temperater = (battery_temperature[0] + battery_temperature[1] + battery_temperature[2] + battery_temperature[3])/4;
                row1.warning = status_package_1;
                row1.status_balance = false;
                if (PACKAGE_1 == true && row1.current > 0) { row1.status_connect = 2; }//charge
                else if (PACKAGE_1 == true && row1.current < 0) { row1.status_connect = 3; }//discharge
                else if (PACKAGE_1 == true && row1.current == 0) { row1.status_connect = 1; }//discharge
                else { row1.status_connect = 0; } //disconnect 
                Display.Add_row_data_package(1, row1, this);
                access_db.insert_package("Package", row1, "Package 1");
                Package row2 = new Package();
                row2.capacity = battery_voltage[4] + battery_voltage[5] + battery_voltage[6] + battery_voltage[7];
                row2.current = battery_temperature[9];
                // if current < 0 discharge current>0 charge (dong duong khi sac dong am khi xa)
                row2.temperater = (battery_temperature[4] + battery_temperature[5] + battery_temperature[6] + battery_temperature[7])/4;
                row2.warning = status_package_2;
                row2.status_balance = false;
                if (PACKAGE_2 == true && row2.current > 0) { row2.status_connect = 2; }//charge
                else if (PACKAGE_2 == true && row2.current < 0) { row2.status_connect = 3; }//discharge
                else if (PACKAGE_2 == true && row2.current == 0) { row2.status_connect = 1; }//discharge
                else { row2.status_connect = 0; } //disconnect 
                Display.Add_row_data_package(2, row2, this);
                access_db.insert_package("Package", row2, "Package 2");

                Package row3 = new Package();
                row3.capacity = (row1.capacity + row2.capacity)/2;
                row3.current = battery_temperature[10];
                // if current < 0 discharge current>0 charge (dong duong khi sac dong am khi xa)
                row3.temperater = (row1.temperater + row2.temperater)/2;
                row3.warning = status_package_1 | status_package_2;
                row3.status_balance = false;
                if (row1.status_connect == 0 && row2.status_connect == 0)
                {
                    row3.status_connect = 0;
                }
                else if (row3.current == 0) { row3.status_connect = 1; }
                else if (row3.current > 0) { row3.status_connect = 2; }
                else if (row3.current < 0) { row3.status_connect = 3; }
                Display.Add_row_data_package(3, row3, this);
                access_db.insert_package("Package", row3, "All Package");

                //access_db.insert_battery("Battery", temp, i + 1);
            }

        }
        private void btnChart_Click(object sender, EventArgs e)
        {
            FLAG_REALTIME_CHART = 1;
            Console.WriteLine(FLAG_REALTIME_CHART);
            chart_form.WindowState = FormWindowState.Normal;
            chart_form.Show();
        }
        // config
        MyDateTimeSeries series1, series2, series3, series4;

        private System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();


        private void lineChart1_DataItemClicked_1(object sender, HitResult e)
        {
            tooltip.RemoveAll();
            double Value = e.Value;
            int index = e.Index;
            long time = series1.dates[index];
            DateTime dt = new DateTime(time);
            Console.WriteLine("voltage is {0} time is {1}", Value, dt.ToString());
            string infor = Value.ToString("0.000") + " at " + dt.ToString("HH:mm");
            tooltip.AutoPopDelay = 5000;
            tooltip.Show(infor, lineChart);
        }

        private void lineChart_DataItemClicked_1(object sender, HitResult e)
        {
            tooltip.RemoveAll();
            double Value = e.Value;
            int index = e.Index;
            long time = series1.dates[index];
            DateTime dt = new DateTime(time);
            Console.WriteLine("voltage is {0} time is {1}", Value, dt.ToString());
            string infor = Value.ToString("0.000") + " at " + dt.ToString("HH:mm");
            tooltip.AutoPopDelay = 5000;
            tooltip.Show(infor, lineChart);
        }


        private void config_real_time_chart() {

            series1 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            series1.DateTimeFormat = DateTimeFormat.LongTime;
            series1.LabelInterval = 1;
            series1.MinValue = 0;
            series1.MaxValue = 120;
            series1.Title = "Voltage Package 1";
            series1.SupportedLabels = LabelKinds.XAxisLabel;

            series2 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            series2.DateTimeFormat = DateTimeFormat.LongTime;
            series2.LabelInterval = 1;
            series2.MinValue = 0;
            series2.MaxValue = 120;
            series2.Title = "Temperature Package 1";

            series3 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            series3.DateTimeFormat = DateTimeFormat.LongTime;
            series3.LabelInterval = 1;
            series3.MinValue = 0;
            series3.MaxValue = 120;
            series3.Title = "Voltage Package 1";
            series3.SupportedLabels = LabelKinds.XAxisLabel;

            series4 = new MyDateTimeSeries(DateTime.Now, DateTime.Now, DateTime.Now.AddMinutes(1));
            series4.DateTimeFormat = DateTimeFormat.LongTime;
            series4.LabelInterval = 1;
            series4.MinValue = 0;
            series4.MaxValue = 120;
            series4.Title = "Temperature Package 2";
            series4.SupportedLabels = LabelKinds.None;
            // setup chart
            lineChart.Series.Add(series1);
            lineChart.Series.Add(series2);
            lineChart1.Series.Add(series3);
            lineChart1.Series.Add(series4);
            // config Chart 1
            lineChart.Title = "Package 1";
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
            lineChart.YAxis.Title = "Voltage(V)\n Temperature(C)";
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
            // config Chart 2
            lineChart1.Title = "Package 2";
            lineChart1.ShowXCoordinates = false;
            lineChart1.ShowLegendTitle = false;
            lineChart1.LayoutPanel.Margin = new Margins(20, 20, 20, 20);
                     
            lineChart1.XAxis.Title = "Time";
            lineChart1.XAxis.MinValue = 0;
            lineChart1.XAxis.MaxValue = 120;
            lineChart1.XAxis.Interval = 20;
                     
            lineChart1.YAxis.MinValue = 0;
            lineChart1.YAxis.MaxValue = 120;
            lineChart1.YAxis.Interval = 10;
            lineChart1.YAxis.Title = "Voltage(V)\n Temperature(C)";
            lineChart1.AllowZoom = true;
            lineChart1.LineType = LineType.Curve;
            lineChart1.Plot.SeriesStyle = style;
            lineChart1.Theme.PlotBackground = new SolidBrush(Color.White);
            lineChart1.Theme.GridLineColor = Color.LightGray;
            lineChart1.Theme.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            lineChart1.TitleMargin = new Margins(10);
            lineChart1.GridType = GridType.Horizontal;


        }
        private void SetRealTimeChart(float[] battery_voltage, float[] battery_temperature, int size_battery) {
            float Voltage_P1 = 0;
            float Voltage_P2 = 0;
            float Temperature_P1 = 0;
            float Temperature_P2 = 0;
            Voltage_P1 = battery_voltage[0] + battery_voltage[1] + battery_voltage[2] + battery_voltage[3];
            Voltage_P2 = battery_voltage[4] + battery_voltage[5] + battery_voltage[6] + battery_voltage[7];
            Temperature_P1 = (battery_temperature[0] + battery_temperature[1] + battery_temperature[2] + battery_temperature[3])/4;
            Temperature_P2 = (battery_temperature[4] + battery_temperature[5] + battery_temperature[6] + battery_temperature[7])/4;
            series1.addValue(Voltage_P1, DateTime.Now);
            series2.addValue(Temperature_P1, DateTime.Now);
            series3.addValue(Voltage_P2, DateTime.Now);
            series4.addValue(Temperature_P2, DateTime.Now);
            //series2.addValue(buffer_temperature[i], buffer_datetime[i]);
            if (series1.Size >= 1)
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
            if (series3.Size >= 1)
            {
                double currVal = series3.GetValue(series3.Size - 1, 0);

                if (currVal > lineChart1.XAxis.MaxValue)
                {
                    double span = currVal - series3.GetValue(series3.Size - 2, 0);
                    lineChart1.XAxis.MinValue += span;
                    lineChart1.XAxis.MaxValue += span;
                }
                lineChart1.ChartPanel.InvalidateLayout();

            }
        }
    }
}
