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
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace listView_Test
{

    public partial class Form1 : Form
    {
        // config chart 
        Real_Time_Chart MyChart = new Real_Time_Chart();
        // control chart
        string objectChart1 = "Package 1";
        bool voltageChart1 = true;
        bool temperatureChart1 = false;
        bool currentChart1 = false;
        string objectChart2 = "Package 1";
        bool voltageChart2 = true;
        bool temperatureChart2 = false;
        bool currentChart2 = false;
        // package information 
        double[] voltage_package = new double[Constant.NUMBER_PACKET];
        double[] temperature_package = new double[Constant.NUMBER_PACKET];
        double[] current_package = new double[Constant.NUMBER_PACKET];
        // buffer TX
        private byte[] buffer_tx = new byte[Constant.SIZE_BUFFER_TX];
        public static int FLAG_REALTIME_CHART = 0;
        public static Database access_db = new Database();
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
        private bool[] status_adding_pheripheral = new bool[Constant.NUMBER_PHERI];
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
        // set delegate to handle set peripheral
        delegate void SetTable_peripheral(bool[] status_peripheral, bool[] status_adding_pheripheral, int size);
        //set delegate to handle draw chart1
        delegate void SetChart1();
        //set delegate to handle draw chart2
        delegate void SetChart2();
        //set deletage control update icon
        delegate void SetIconUpdateChart1();
        delegate void SetIconUpdateChart2();
        //set chart form 2 real time

        public Chart_Form chart_form = new Chart_Form();
        bool Flag_package1 = false;
        bool Flag_package2 = false;
        bool Flag_fan1 = false;
        bool Flag_fan2 = false;

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
            //CustomListView_Battery.Columns.Add("Blance status");
            CustomListView_Battery.Columns.Add("Warning Voltage");
            CustomListView_Battery.Columns.Add("Warning Temperature");


            //ListViewItem item1 = new ListViewItem();
            //item1.Text = "Item1";
            //item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "Sub Item 1" });
            for (int i = 1; i <= Constant.NUMBER_BATTERY / 2; i++)
            {
                CustomListView_Battery.Items.Add("Battery " + i.ToString());
            }
            CustomListView_Battery.View = View.Details;
            CustomListView_Battery.Dock = DockStyle.Fill;
            //init_listView_battery();
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
            //CustomListView_Package.Columns.Add("Balance");
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

            CustomListView_Pheripheral.Items.Add("Relay 1 - Package 1");
            CustomListView_Pheripheral.Items.Add("Relay 2 - Package 2");
            CustomListView_Pheripheral.Items.Add("Relay 3 - Fan 1");
            CustomListView_Pheripheral.Items.Add("Relay 4 - Fan 2");

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
        void LoadComboBox_Obj_Chart1() {
            cbSelectObjChart1.Items.Add("Package 1");
            cbSelectObjChart1.Items.Add("Package 2");
            cbSelectObjChart1.Items.Add("All package");
            cbSelectObjChart1.Items.Add("Cell 1 - Package 1");
            cbSelectObjChart1.Items.Add("Cell 2 - Package 1");
            cbSelectObjChart1.Items.Add("Cell 3 - Package 1");
            cbSelectObjChart1.Items.Add("Cell 4 - Package 1");
            cbSelectObjChart1.Items.Add("Cell 1 - Package 2");
            cbSelectObjChart1.Items.Add("Cell 2 - Package 2");
            cbSelectObjChart1.Items.Add("Cell 3 - Package 2");
            cbSelectObjChart1.Items.Add("Cell 4 - Package 2");
            cbSelectObjChart1.SelectedIndex = 0;
        }
        void LoadComboBox_Obj_Chart2()
        {
            cbSelectObjChart2.Items.Add("Package 1");
            cbSelectObjChart2.Items.Add("Package 2");
            cbSelectObjChart2.Items.Add("All package");
            cbSelectObjChart2.Items.Add("Cell 1 - Package 1");
            cbSelectObjChart2.Items.Add("Cell 2 - Package 1");
            cbSelectObjChart2.Items.Add("Cell 3 - Package 1");
            cbSelectObjChart2.Items.Add("Cell 4 - Package 1");
            cbSelectObjChart2.Items.Add("Cell 1 - Package 2");
            cbSelectObjChart2.Items.Add("Cell 2 - Package 2");
            cbSelectObjChart2.Items.Add("Cell 3 - Package 2");
            cbSelectObjChart2.Items.Add("Cell 4 - Package 2");
            cbSelectObjChart2.SelectedIndex = 0;
        }

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadTabControl();
            LoadListView_battery();
            LoadListView_Package();
            LoadListView_Pheripheral();
            Port.DataReceived += new SerialDataReceivedEventHandler(uart_read_even);
            access_db.StrConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\App_C#\\Template\\listView_Test\\test.accdb";
            access_db.Conn = new OleDbConnection(access_db.StrConn);
            access_db.connect_access();

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
            LoadComboBox_Obj_Chart1();
            LoadComboBox_Obj_Chart2();
            cBVoltageChart1.Checked = true;
            cBVoltageChart2.Checked = true;
            //config_real_time_chart();
            MyChart.Chart1 = chart1;
            MyChart.Chart2 = chart2;
            MyChart.myRealTimeChart1("Time", "Voltage", "Monitoring Voltage Package", 0, 5);
            MyChart.myRealTimeChart2("Time", "Voltage", "Monitoring Voltage Package", 0, 5);
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
            //Peripheral test = new Peripheral();
            //Random rand = new Random();
            //test.status_connect = rand.Next(0, 2) > 0;
            //Display.Add_row_data_pheripheral(INDEX_PHERI++, test, this);
            //if (INDEX_PHERI == Constant.NUMBER_PHERI + 1) INDEX_PHERI = 1;
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
                    btnConnectSerial.BackColor = Color.Red;

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else {
                Port.Close();
                btnConnectSerial.Text = "Connect";
                btnConnectSerial.BackColor = Color.Lime;
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
        int success_data = 0;
        int fail_data = 0;
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
                // Console.WriteLine("number: {0} byte {1:X2}", number_byte_read, buffer_rx[number_byte_read]);
                //Console.Write("{0:X2} ", (byte)item);
                if (buffer_rx[134] == '\r')
                {
                    Array.Copy(buffer_rx, 0, data, 0, 135);
                    number_byte_read = -1;
                    Array.Clear(buffer_rx, 0, buffer_rx.Length);
                    update = true;
                }
                //else if (buffer_rx[number_byte_read] == '\r' && number_byte_read != 134) {
                //    Console.WriteLine("byte wrong {0:X2} number {1}", buffer_rx[number_byte_read], number_byte_read);
                //    number_byte_read = -1;
                //    Console.WriteLine("Wrong end data");
                //}
                number_byte_read++;
                content += " " + ((byte)item).ToString("X2");
            }
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine("in event " + counter.ToString() + content +"with number byte is " +bytes.ToString());
            counter++;


            if (update)
            {
                update = false;
                if (data[0] == 'I' || data[0] == 'E' || data[0] == 'H')
                {
                    int number_bytes = data.Length;
                    string content1 = "number of bytes read is" + data.Length.ToString() + ": ";
                 
                    if (Data.check_correct_emerPackage(data,
                                                        number_bytes,
                                                        ref status_emer_bar1,
                                                        ref status_emer_bar2,
                                                        Constant.NUMBER_BATTERY))
                    {
                        Console.WriteLine("Successfull receive EmerPackage");

                        success_data++;
                        Console.WriteLine("Number success {0} Number fail {1}", success_data, fail_data);
                    }
                    if (Data.check_correct_inforPackage(data,
                                                        number_bytes,
                                                        ref battery_voltage,
                                                        ref battery_temperature,
                                                        Constant.NUMBER_BATTERY,
                                                        ref status_battery,
                                                        ref status_adding,
                                                        Constant.NUMBER_BATTERY))
                    {
                        success_data++;
                        Console.WriteLine("Successfull receive inforPackage");
                        Console.WriteLine("Number success {0} Number fail {1}", success_data, fail_data);
                        //if (FLAG_REALTIME_CHART == 1)
                        //{
                        //    // adding data to chart form
                        //    Data_chart.add_point("Battery Voltage", 100, 100, chart_form);
                        //}
                        SetIconChart1();
                        SetIconChart2();
                        SetListView_Infor(battery_voltage, battery_temperature, status_battery, status_adding, status_emer_bar1, status_emer_bar2, Constant.NUMBER_BATTERY);
                        SetListView_Pakage(battery_voltage, battery_temperature, status_battery, status_peripheral, Constant.NUMBER_BATTERY);
                        SetChartRealTime1();
                        SetChartRealTime2();
                        SetChartForm2RealTime();
                    }
                    if (Data.check_correct_periPackage(data,
                                                       number_bytes,
                                                       ref status_peripheral,
                                                       ref status_adding_pheripheral,
                                                       Constant.NUMBER_PHERI))
                    {
                        success_data++;
                        Console.WriteLine("Successfull receive humanPackage");
                        Console.WriteLine("Number success {0} Number fail {1}", success_data, fail_data);
                        SetListView_Pheripheral(status_peripheral, status_adding_pheripheral, Constant.NUMBER_PHERI);
                    }
                }
                else
                {
                    fail_data++;
                    Console.WriteLine("Number success {0} Number fail {1}", success_data, fail_data);
                    Port.DiscardInBuffer();
                }
            }
           

        }
        public void SetIconChart1() {
            if (this.pbChart1.InvokeRequired) {
                SetIconUpdateChart1 d = new SetIconUpdateChart1(SetIconChart1);
                this.Invoke(d);
            }
            else
            {
                timerChangeChart1.Enabled = true;
                pbChart1.Visible = true;
            }
        }
        public void SetIconChart2()
        {
            if (this.pbChart1.InvokeRequired)
            {
                SetIconUpdateChart2 d = new SetIconUpdateChart2(SetIconChart2);
                this.Invoke(d);
            }
            else
            {
                timerChangeChart2.Enabled = true;
                pbChart2.Visible = true;
            }
        }
      
        void SetChartForm2RealTime()
        {

            if (chart_form.Chart_real_time == true)
            {
                string whatmonitor = chart_form.ObjectMonitor;
                switch (whatmonitor)
                {
                    case "Package 1":
                        chart_form.render_chart_real_time(voltage_package[Constant.INDEX_ALL],
                                                           temperature_package[Constant.INDEX_ALL],
                                                           current_package[Constant.INDEX_ALL]);
                        break;
                    case "Package 2":
                        chart_form.render_chart_real_time(voltage_package[Constant.INDEX_ALL],
                                                           temperature_package[Constant.INDEX_ALL],
                                                           current_package[Constant.INDEX_ALL]);
                        break;
                    case "All package":
                        chart_form.render_chart_real_time(voltage_package[Constant.INDEX_ALL],
                                                          temperature_package[Constant.INDEX_ALL],
                                                          current_package[Constant.INDEX_ALL]);
                        break;
                    case "Cell 1 - Package 1":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL1_PACKAGE1],
                                                          battery_temperature[Constant.CELL1_PACKAGE1],
                                                          0);
                        break;
                    case "Cell 2 - Package 1":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL2_PACKAGE1],
                                                          battery_temperature[Constant.CELL2_PACKAGE1],
                                                          0);
                        break;
                    case "Cell 3 - Package 1":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL3_PACKAGE1],
                                                          battery_temperature[Constant.CELL3_PACKAGE1],
                                                          0);
                        break;
                    case "Cell 4 - Package 1":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL4_PACKAGE1],
                                                          battery_temperature[Constant.CELL4_PACKAGE1],
                                                          0);
                        break;
                    case "Cell 1 - Package 2":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL1_PACKAGE2],
                                                          battery_temperature[Constant.CELL1_PACKAGE2],
                                                          0);
                        break;
                    case "Cell 2 - Package 2":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL2_PACKAGE2],
                                                          battery_temperature[Constant.CELL2_PACKAGE2],
                                                          0);
                        break;
                    case "Cell 3 - Package 2":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL3_PACKAGE2],
                                                          battery_temperature[Constant.CELL3_PACKAGE2],
                                                          0);
                        break;
                    case "Cell 4 - Package 2":
                        chart_form.render_chart_real_time(battery_voltage[Constant.CELL3_PACKAGE2],
                                                          battery_temperature[Constant.CELL3_PACKAGE2],
                                                          0);
                        break;
                }
            }

        }
        //private void OnDataChanged(object sender, EventArgs e, double voltage, double temperature,double current)
        //{
        //    if (this.DataChanged != null)
        //        this.DataChanged(this, e);
        //}
        // set table ListView Information
        public void SetListView_Infor(float[] battery_voltage,
                         float[] battery_temperature,
                         bool[] status_battery,
                         bool[] status_adding,
                         bool[] status_emer_bar1,
                         bool[] status_emer_bar2,
                         int size)
        {
            if (this.CustomListView_Battery.InvokeRequired)
            {
                SetTable_battery d = new SetTable_battery(SetListView_Infor);
                this.Invoke(d, battery_voltage, battery_temperature, status_battery, status_adding, status_emer_bar1, status_emer_bar2, 16);
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
        // set table ListView Package
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
                bool PACKAGE_1 = status_peripheral[0];
                bool PACKAGE_2 = status_peripheral[1];
                bool FAN_1 = status_peripheral[2];
                bool FAN_2 = status_peripheral[3];
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
                row1.current = battery_temperature[9];
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
                // -- set to global variable
                voltage_package[Constant.INDEX_PACKAGE1] = row1.capacity;
                temperature_package[Constant.INDEX_PACKAGE1] = row1.temperater;
                current_package[Constant.INDEX_PACKAGE1] = row1.current;

                Package row2 = new Package();
                row2.capacity = battery_voltage[4] + battery_voltage[5] + battery_voltage[6] + battery_voltage[7];
                row2.current = battery_temperature[10];
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
                // -- set to global variable
                voltage_package[Constant.INDEX_PACKAGE2] = row2.capacity;
                temperature_package[Constant.INDEX_PACKAGE2] = row2.temperater;
                current_package[Constant.INDEX_PACKAGE2] = row2.current;
                Package row3 = new Package();
                row3.capacity = (row1.capacity + row2.capacity)/2;
                row3.current = battery_temperature[8];
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
                // -- set to global variable
                voltage_package[Constant.INDEX_ALL] = row3.capacity;
                temperature_package[Constant.INDEX_ALL] = row3.temperater;
                current_package[Constant.INDEX_ALL] = row3.current;
                //access_db.insert_battery("Battery", temp, i + 1);
            }

        } 
        // set table listView pheripheral
        public void SetListView_Pheripheral(bool[] status_pheripheral, bool[] status_adding_pheripheral, int size)
        {
            //  byte 1 bit1 bit2 bit3 bit4
            if (this.CustomListView_Battery.InvokeRequired)
            {
                SetTable_peripheral d = new SetTable_peripheral(SetListView_Pheripheral);
                this.Invoke(d, status_pheripheral, status_adding_pheripheral, size);
            }
            else
            {
                // package 1
                Peripheral package1 = new Peripheral();
                package1.status_connect = status_peripheral[0];
                Flag_package1 = package1.status_connect;
                package1.name_peripheral = "Relay 1 - Package 1";
                Display.Add_row_data_pheripheral(1, package1, this);
                access_db.insert_peri("Peripheral", package1, package1.name_peripheral);
                // package 2
                Peripheral package2 = new Peripheral();
                package2.status_connect = status_peripheral[1];
                Flag_package2 = package2.status_connect;
                package2.name_peripheral = "Relay 2 - Package 2";
                Display.Add_row_data_pheripheral(2, package2, this);
                access_db.insert_peri("Peripheral", package2, package2.name_peripheral);
                // fan1
                Peripheral fan1 = new Peripheral();
                fan1.status_connect = status_peripheral[2];
                Flag_fan1 = fan1.status_connect;
                fan1.name_peripheral = "Relay 3 - Fan 1";
                Display.Add_row_data_pheripheral(3, fan1, this);
                access_db.insert_peri("Peripheral", fan1, fan1.name_peripheral);
                // fan2
                Peripheral fan2 = new Peripheral();
                fan2.status_connect = status_peripheral[3];
                Flag_fan2 = fan2.status_connect;
                fan2.name_peripheral = "Relay 4 - Fan 2";
                Display.Add_row_data_pheripheral(4, fan2, this);
                access_db.insert_peri("Peripheral", fan2, fan2.name_peripheral);
            }
        
        }
        public void SetChartRealTime1() {
            if (this.chart1.InvokeRequired)
            {
                SetChart1 d = new SetChart1(SetChartRealTime1);
                this.Invoke(d);
            }
            else { 
                if(objectChart1 == "Package 1" || objectChart1 =="Package 2" || objectChart1 == "All package")
                {
                    update_chart_package_chart1(MyChart);
                }
                else
                {
                    update_chart_cell_chart1(MyChart);
                }
            }
        }
        public void SetChartRealTime2() {
            if (this.chart1.InvokeRequired)
            {
                SetChart2 d = new SetChart2(SetChartRealTime2);
                this.Invoke(d);
            }
            else
            {
                if (objectChart2 == "Package 1" || objectChart2 == "Package 2" || objectChart2 == "All package")
                {
                    update_chart_package_chart2(MyChart);
                }
                else
                {
                    update_chart_cell_chart2(MyChart);
                }
            }
        }
        public void update_chart_package_chart1(Real_Time_Chart myChart) {
            if (objectChart1 == "Package 1")
            {
                make_update_package1(Constant.INDEX_PACKAGE1, voltageChart1, temperatureChart1, currentChart1, MyChart);
            }
            else if (objectChart1 == "Package 2")
            {
                make_update_package1(Constant.INDEX_PACKAGE2, voltageChart1, temperatureChart1, currentChart1, MyChart);
            }
            else { 
                make_update_package1(Constant.INDEX_ALL, voltageChart1, temperatureChart1, currentChart1, MyChart);
            }
        }
        public void update_chart_package_chart2(Real_Time_Chart myChart)
        {
            if (objectChart2 == "Package 1")
            {
                make_update_package2(Constant.INDEX_PACKAGE1, voltageChart2, temperatureChart2, currentChart2, MyChart);
            }
            else if (objectChart2 == "Package 2")
            {
                make_update_package2(Constant.INDEX_PACKAGE2, voltageChart2, temperatureChart2, currentChart2, MyChart);
            }
            else
            {
                make_update_package2(Constant.INDEX_ALL, voltageChart2, temperatureChart2, currentChart2, MyChart);
            }
        }
        public void make_update_package1(int index, bool ifVoltage, bool ifTemperature, bool Ifcurrent, Real_Time_Chart myChart)
        {
            if (ifVoltage && ifTemperature && Ifcurrent)
            {
                myChart.addPointToChart1(voltage_package[index], temperature_package[index], current_package[index],DateTime.Now);
            }
            else if (ifVoltage && ifTemperature)
            {
                myChart.addPointToChart1(voltage_package[index], temperature_package[index], DateTime.Now);
            }
            else if (ifVoltage && Ifcurrent)
            {
                myChart.addPointToChart1(voltage_package[index], temperature_package[index], current_package[index], DateTime.Now);
            }
            else if (ifTemperature && Ifcurrent)
            {
                myChart.addPointToChart1(temperature_package[index], current_package[index], DateTime.Now);
            }
            else if (ifVoltage)
            {
                myChart.addPointToChart1(voltage_package[index], DateTime.Now);
            }
            else if (ifTemperature)
            {
                myChart.addPointToChart1(temperature_package[index], DateTime.Now);
            }
            else if (Ifcurrent)
            {
                myChart.addPointToChart1(current_package[index], DateTime.Now);
            }
        }
        public void make_update_package2(int index, bool ifVoltage, bool ifTemperature, bool Ifcurrent, Real_Time_Chart myChart)
        {
            if (ifVoltage && ifTemperature && Ifcurrent)
            {
                myChart.addPointToChart2(voltage_package[index], temperature_package[index], current_package[index], DateTime.Now);
            }
            else if (ifVoltage && ifTemperature)
            {
                myChart.addPointToChart2(voltage_package[index], temperature_package[index], DateTime.Now);
            }
            else if (ifVoltage && Ifcurrent)
            {
                myChart.addPointToChart2(voltage_package[index], temperature_package[index], current_package[index], DateTime.Now);
            }
            else if (ifTemperature && Ifcurrent)
            {
                myChart.addPointToChart2(temperature_package[index], current_package[index], DateTime.Now);
            }
            else if (ifVoltage)
            {
                myChart.addPointToChart2(voltage_package[index], DateTime.Now);
            }
            else if (ifTemperature)
            {
                myChart.addPointToChart2(temperature_package[index], DateTime.Now);
            }
            else if (Ifcurrent)
            {
                myChart.addPointToChart2(current_package[index], DateTime.Now);
            }
        }
        public void update_chart_cell_chart1(Real_Time_Chart myChart) {
            switch (objectChart1)
            {
                case "Cell 1 - Package 1":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL1_PACKAGE1);
                    break;
                case "Cell 2 - Package 1":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL2_PACKAGE1);
                    break;

                case "Cell 3 - Package 1":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL3_PACKAGE1);
                    break;

                case "Cell 4 - Package 1":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL4_PACKAGE1);
                    break;

                case "Cell 1 - Package 2":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL1_PACKAGE2);
                    break;

                case "Cell 2 - Package 2":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL2_PACKAGE2);
                    break;
                case "Cell 3 - Package 2":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL3_PACKAGE2);
                    break;
                case "Cell 4 - Package 2":
                    make_update_cell_chart1(myChart, voltageChart1, temperatureChart1, Constant.CELL4_PACKAGE2);
                    break;
                default:
                    break;
            }
        }
        public void update_chart_cell_chart2(Real_Time_Chart myChart)
        {
            switch (objectChart2)
            {
                case "Cell 1 - Package 1":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL1_PACKAGE1);
                    break;
                case "Cell 2 - Package 1":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL2_PACKAGE1);
                    break;

                case "Cell 3 - Package 1":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL3_PACKAGE1);
                    break;

                case "Cell 4 - Package 1":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL4_PACKAGE1);
                    break;

                case "Cell 1 - Package 2":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL1_PACKAGE2);
                    break;

                case "Cell 2 - Package 2":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL2_PACKAGE2);
                    break;
                case "Cell 3 - Package 2":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL3_PACKAGE2);
                    break;
                case "Cell 4 - Package 2":
                    make_update_cell_chart2(myChart, voltageChart2, temperatureChart2, Constant.CELL4_PACKAGE2);
                    break;
                default:
                    break;
            }
        }
        public void make_update_cell_chart1(Real_Time_Chart myChart, bool voltage, bool temperature,int index) {
            if (voltage && temperature) {
                myChart.addPointToChart1(battery_voltage[index], battery_temperature[index], DateTime.Now);
            }
            else if (voltage)
            {
                myChart.addPointToChart1(battery_voltage[index], DateTime.Now);
            }
            else if (temperature)
            {
                myChart.addPointToChart1(battery_temperature[index], DateTime.Now);
            }
        }
        public void make_update_cell_chart2(Real_Time_Chart myChart, bool voltage, bool temperature, int index)
        {
            if (voltage && temperature)
            {
                myChart.addPointToChart2(battery_voltage[index], battery_temperature[index], DateTime.Now);
            }
            else if (voltage)
            {
                myChart.addPointToChart2(battery_voltage[index], DateTime.Now);
            }
            else if (temperature)
            {
                myChart.addPointToChart2(battery_temperature[index], DateTime.Now);
            }
        }
        private void btnChart_Click(object sender, EventArgs e)
        {
            FLAG_REALTIME_CHART = 1;
            Console.WriteLine(FLAG_REALTIME_CHART);
            
            chart_form.WindowState = FormWindowState.Normal;
            chart_form.Show();
        }

   
        private System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();

    

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            chart_form.chart1.Series[0].Points.AddXY(now, 5);
        }

        private void btnExecuteMonitoring_Click(object sender, EventArgs e)
        {
            // hit then config again chart1
            objectChart1 = cbSelectObjChart1.SelectedItem.ToString();
            voltageChart1 = cBVoltageChart1.Checked;
            temperatureChart1 = cBTemperatureChart1.Checked;
            currentChart1 = cBCurrentChart1.Checked;
            if (!voltageChart1 && !temperatureChart1 && !currentChart1)
            {
                MessageBox.Show("Please select what elements you want to monitoring in chart 1", "Missing information",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maxY =10;
            if (objectChart1 == "Package 1" || objectChart1 == "Package 2" ||objectChart1 == "All package")
            {
                if (temperatureChart1)
                {
                    maxY = 120;
                }
                else if (voltageChart1)
                {
                    maxY = 20;
                }
                else
                {
                    maxY = 3;
                }
            }
            else
            {
                if (temperatureChart1)
                {
                    maxY = 120;
                }
                else if (voltageChart1)
                {
                    maxY = 5;
                }
            }
            string title = "Monitoring "+ objectChart1;
            string label_x = "Time";
            string label_y = (voltageChart1) ? "Voltage " : "";
            label_y += (temperatureChart1) ? "Temperature " : "";
            label_y += (currentChart1) ? "Current " : "";
            MyChart.myRealTimeChart1(label_x, label_y, title, 0, maxY);
            if (voltageChart1 == false) {
                MyChart.Chart1.Series.Remove(MyChart.Chart1.Series["Voltage"]);
            }
            if (temperatureChart1 == false)
            {
                MyChart.Chart1.Series.Remove(MyChart.Chart1.Series["Temperature"]);
            }
            if (currentChart1 == false)
            {
                MyChart.Chart1.Series.Remove(MyChart.Chart1.Series["Current"]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // hit then config again chart2
            
            objectChart2 = cbSelectObjChart2.SelectedItem.ToString();
            voltageChart2 = cBVoltageChart2.Checked;
            temperatureChart2 = cBTemperatureChart2.Checked;
            currentChart2 = cBCurrentChart2.Checked;
            if (!voltageChart2 && !temperatureChart2 && !currentChart2) {
                MessageBox.Show("Please select what elements you want to monitoring in chart 2", "Missing information",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string title = "Monitoring " + objectChart2;
            string label_x = "Time";
            string label_y = (voltageChart2) ? "Voltage " : "";
            label_y += (temperatureChart2) ? "Temperature " : "";
            label_y += (currentChart2) ? "Current " : "";
            int maxY = 10 ;
            if (objectChart2 == "Package 1" || objectChart2 == "Package 2" || objectChart2 == "All package")
            {
                if (temperatureChart2) {
                    maxY = 120;
                }
                else if (voltageChart2)
                {
                    maxY = 20;
                }
                else
                {
                    maxY = 3;
                }
            }
            else 
            {
                if (temperatureChart2)
                {
                    maxY = 120;
                }
                else if (voltageChart2)
                {
                    maxY = 5;
                }
            }
            MyChart.myRealTimeChart2(label_x, label_y, title, 0, maxY);
            if (voltageChart2 == false)
            {
                MyChart.Chart2.Series.Remove(MyChart.Chart2.Series["Voltage"]);
            }
            if (temperatureChart2 == false)
            {
                MyChart.Chart2.Series.Remove(MyChart.Chart2.Series["Temperature"]);
            }
            if (currentChart2 == false)
            {
                MyChart.Chart2.Series.Remove(MyChart.Chart2.Series["Current"]);
            }
        }

        private void cbSelectObjChart1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbSelectObjChart1.SelectedItem.ToString();
            if (selected != "Package 1"  && selected != "Package 2" && selected !="All package")
            {
                cBCurrentChart1.Checked = false;
                cBCurrentChart1.Enabled = false;
            }
            else
                cBCurrentChart1.Enabled = true;
        }

        private void cbSelectObjChart2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbSelectObjChart2.SelectedItem.ToString();
            if (selected != "Package 1" && selected != "Package 2" && selected != "All package")
            {
                cBCurrentChart2.Checked = false;
                cBCurrentChart2.Enabled = false;
            }
            else
                cBCurrentChart2.Enabled = true;
        }
        //-------------------------------------------- ZOOM IN CHART1 ------------------------------
        Rectangle zoomRectChart1;
        bool zoomingChart1Now = false;
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Chart 1 Move down");
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
            Console.WriteLine("Move up");
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
        int zoom_level_chart1 = 0;
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Zoom in clicked");
            if (chart1.Series[0].Points.Count > 10) {
                Console.WriteLine("Zoom level now is {0}", zoom_level_chart2);

                if (zoom_level_chart1 < 5)
                {
                    double max = chart1.ChartAreas[0].AxisX.Maximum;
                    double min = chart1.ChartAreas[0].AxisX.Minimum;
                    double new_min = (max + min) / 2;
                    chart1.ChartAreas[0].AxisX.Minimum = new_min;
                    zoom_level_chart1++;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    zoom_level_chart1 = 0;
                }
            }
            
        }
        //---------------------------------------- ZOOM IN CHART2 ----------------------------------------------
        Rectangle zoomRectChart2;
        bool zoomingChart2Now = false;

        private void chart2_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Move down");
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            this.Focus();
            //Test for Ctrl + Left Single Click to start displaying selection box
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1) &&
                    ((ModifierKeys & Keys.Control) != 0) && sender is Chart)
            {
                zoomingChart2Now = true;
                zoomRectChart2.Location = e.Location;
                zoomRectChart2.Width = zoomRectChart2.Height = 0;
                DrawZoomRect_2(); //Draw the new selection rect
            }
            this.Focus();
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomingChart2Now)
            {
                DrawZoomRect_2(); //Redraw the old selection 
                                //rect, which erases it
                zoomRectChart2.Width = e.X - zoomRectChart2.Left;
                zoomRectChart2.Height = e.Y - zoomRectChart2.Top;
                DrawZoomRect_2(); //Draw the new selection rect
            }
        }

        private void chart2_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Move up");
            if (zoomingChart2Now && e.Button == MouseButtons.Left)
            {
                DrawZoomRect_2(); //Redraw the selection 
                                //rect, which erases it
                if ((zoomRectChart2.Width != 0) && (zoomRectChart2.Height != 0))
                {
                    //Just in case the selection was dragged from lower right to upper left
                    zoomRectChart2 = new Rectangle(Math.Min(zoomRectChart2.Left, zoomRectChart2.Right),
                            Math.Min(zoomRectChart2.Top, zoomRectChart2.Bottom),
                            Math.Abs(zoomRectChart2.Width),
                            Math.Abs(zoomRectChart2.Height));
                    ZoomInToZoomRect_2(); //no Shift so Zoom in.
                }
                zoomingChart2Now = false;
            }
        }
        bool useGDI32_chart2 = true;
        private void DrawZoomRect_2()
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (useGDI32_chart2)
            {
                //This is so much smoother than ControlPaint.DrawReversibleFrame
                GDI32.DrawXORRectangle(chart2.CreateGraphics(), pen, zoomRectChart2);
            }
            else
            {
                Rectangle screenRect = chart2.RectangleToScreen(zoomRectChart2);
                ControlPaint.DrawReversibleFrame(screenRect, chart1.BackColor, FrameStyle.Dashed);
            }
        }
        private void ZoomInToZoomRect_2()
        {
            if (zoomRectChart2.Width == 0 || zoomRectChart2.Height == 0)
                return;
            Rectangle r = zoomRectChart2;
            ChartScaleData csd = chart2.Tag as ChartScaleData;
            Console.WriteLine(chart2.Tag);
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
            SetZoomAxisScale_2(chart2.ChartAreas[0].AxisX, r.Left, r.Right);
            SetZoomAxisScale_2(chart2.ChartAreas[0].AxisY, r.Bottom, r.Top);
        }
        private void SetZoomAxisScale_2(Axis axis, int pxLow, int pxHi)
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
            SetAxisFormats_2();
            Console.WriteLine("-----------------end function SetZoomAxisScale------------------------");
        }
        private void SetAxisFormats_2()
        {
            if (true)
            {
                chart2.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm:ss tt";
                chart2.ChartAreas[0].AxisY.LabelStyle.Format = "F2";
            }
        }
        private void chart2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((chart2.Tag as ChartScaleData).isZoomed == true)
            {
                Console.WriteLine("Zoom out chart 2");
                (chart2.Tag as ChartScaleData).ResetAxisScale();
                (chart2.Tag as ChartScaleData).isZoomed = false;
            }
        }
        int zoom_level_chart2 = 0;
        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Zoom in clicked");
            if (chart2.Series[0].Points.Count > 10)
            {
                Console.WriteLine("Zoom level now is {0}",zoom_level_chart2);
                if (zoom_level_chart2 < 5)
                {
                    double max = chart2.ChartAreas[0].AxisX.Maximum;
                    double min = chart2.ChartAreas[0].AxisX.Minimum;
                    double new_min = (max + min) / 2;
                    chart2.ChartAreas[0].AxisX.Minimum = new_min;
                    zoom_level_chart2++;
                }
                else
                {
                    chart2.ChartAreas[0].AxisX.Minimum = 0;
                    zoom_level_chart2 = 0;
                }
            }
        }



        //---- CONTROL INCON UPDATE -----------------
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pbChart1.Visible = false;
            timerChangeChart1.Enabled = false;
        }
        private void timerChangeChart2_Tick(object sender, EventArgs e)
        {
            pbChart2.Visible = false;
            timerChangeChart2.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------------------
        // ------------------------------- CONTROL BATTERY MONTERING CIRCUIT --------------------------------
        private void btnRelay1_Click(object sender, EventArgs e)
        {
            //SetBufferSend(1, !Flag_package1, ref buffer_tx);
            Port.Write(new byte[] { 0x01 }, 0, 1);
            //reset_buffer_tx(ref buffer_tx, Constant.SIZE_BUFFER_TX);
        }

       

        private void btnRelay2_Click(object sender, EventArgs e)
        {
            //SetBufferSend(2, !Flag_package2, ref buffer_tx);
            Port.Write(new byte[] { 0x02}, 0, 1);
            //reset_buffer_tx(ref buffer_tx, Constant.SIZE_BUFFER_TX);
        }

        private void btnFan1_Click(object sender, EventArgs e)
        {
            //SetBufferSend(3, !Flag_fan1, ref buffer_tx);
            Port.Write(new byte[] { 0x03}, 0, 1);
            //reset_buffer_tx(ref buffer_tx, Constant.SIZE_BUFFER_TX);
        }

        private void btnFan2_Click(object sender, EventArgs e)
        {
            //SetBufferSend(4, !Flag_fan2, ref buffer_tx);
            Port.Write(new byte[] { 0x04}, 0, 1);
            //reset_buffer_tx(ref buffer_tx, Constant.SIZE_BUFFER_TX);
        }

        private void btnConnectWifi_Click(object sender, EventArgs e)
        {
            string ssid = "@SSID@"+txtSSID.Text;
            string pass = "@PASS@"+txtPass.Text;
            int length_ssid = ssid.Length;
            int length_pass = pass.Length;
            byte crc = 0x00;
            for(int i = 0; i< length_ssid; i++)
            {
                crc += (byte)ssid[i];
            }
            for (int i = 0; i < length_pass; i++)
            {
                crc += (byte)pass[i];
            }
            Console.WriteLine("crc is {0:X}", crc);
            string dataWifiSend = ssid + pass;
            Console.WriteLine("length of dataWifiSend {0}", dataWifiSend.Length);
            byte[] bytes_send = Encoding.ASCII.GetBytes(dataWifiSend);
            Console.WriteLine("number bytes to send {0}", bytes_send.Length);
            Port.Write(bytes_send, 0, bytes_send.Length);
            Port.Write(new byte[] { crc , 0x0D ,(byte)'\n'}, 0, 3);
        }

        private void btnDisconnecWifi_Click(object sender, EventArgs e)
        {
            string frame_disconnect = "@D@";
            int length_frame = frame_disconnect.Length;
            byte crc = 0x00;
            for (int i = 0; i < length_frame; i++)
            {
                crc += (byte)frame_disconnect[i];
            }
            byte[] bytes_send = Encoding.ASCII.GetBytes(frame_disconnect);
            Port.Write(bytes_send, 0, bytes_send.Length);
            Port.Write(new byte[] { crc, 0x0D, (byte)'\n' }, 0, 3);
        }
    }
}
