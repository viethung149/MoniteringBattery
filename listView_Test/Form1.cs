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

namespace listView_Test
{
   
    public partial class Form1 : Form
    {
        Database access_db = new Database();
        public int INDEX_BATTERY = 1;
        public int INDEX_PACKAGE = 1;
        public int INDEX_PHERI = 1;
        public static float[] battery_voltage = new float[Constant.NUMBER_BATTERY];
        private float[] battery_temperature = new float[Constant.NUMBER_BATTERY];
        // notify over voltage or temperature
        private bool[] status_voltage = new bool[Constant.NUMBER_BATTERY];
        private bool[] status_temperature = new bool[Constant.NUMBER_BATTERY];
        // notify over temperature
        private bool[] status_emer_bar1 = new bool[Constant.NUMBER_BATTERY];
        private bool[] status_emer_bar2 = new bool[Constant.NUMBER_BATTERY];

        // set delegate to handle serial
        delegate void SetTextCallBack(string text);
        // set delegate to handle settable
        delegate void SetTable(float[] battery_voltage, 
                               float[] temp, 
                               bool[] status_voltage, 
                               bool[] status_temp, 
                               bool[] status_emer_bar1, 
                               bool[] status_emer_bar2,
                               int size);
        
       
        private void init_listView_battery() {
            Battery init = new Battery();
            init.voltage = (float)0.0;
            init.temperature = (float)0.0;
            init.status_balance = false;
            init.warning = false;
            for (int i = 1; i <= 8; i++) {
                Display.Add_row_data_battery(i, init,this);
            }
        }
        private void init_listView_package()
        {
            Package init = new Package();
            init.capacity = (float)0.0;
            init.temperater = (float)0.0;
            init.current = (float)0.0;
            init.status_balance = false;
            init.status_connect = false;
            init.status_active = 0;
            for (int i = 1; i <= Constant.NUMBER_PACKET; i++)
            {
                Display.Add_row_data_package(i, init,this);
            }
        }
        private void init_listView_pheripheral()
        {
            Peripheral init = new Peripheral();
            init.status_connect = false;
            for (int i = 1; i <= Constant.NUMBER_PHERI; i++)
            {
                Display.Add_row_data_pheripheral(i, init,this);
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
            CustomListView_Battery.Columns.Add("Emergency");

            //ListViewItem item1 = new ListViewItem();
            //item1.Text = "Item1";
            //item1.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "Sub Item 1" });
            for (int i = 1; i <= Constant.NUMBER_BATTERY; i++) {
                CustomListView_Battery.Items.Add("Battery "+ i.ToString() );
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
            CustomListView_Package.Columns.Add("Status balance");
            CustomListView_Package.Columns.Add("Status connect");
            CustomListView_Package.Columns.Add("Status active");
            CustomListView_Package.Items.Add("All system");
            CustomListView_Package.Items.Add("Package 1");
            CustomListView_Package.Items.Add("Package 2");
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

            string[] parity = { "None", "Even","Odd" };
            cbParity.DataSource = parity;

            double[] stop_bits = { 1, 1.5, 2 };
            cbStop.DataSource = stop_bits;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox_Serial();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("timer check 1");
            Battery test = new Battery();
            Random rand = new Random();
            test.voltage = (float)rand.NextDouble()*3;
            test.temperature = (float)rand.NextDouble()*30;
            test.status_balance  = rand.Next(0,2) > 0 ;
            test.warning = rand.Next(0, 2) > 0;
            Display.Add_row_data_battery(INDEX_BATTERY++, test,this);
            if (INDEX_BATTERY == Constant.NUMBER_BATTERY+1) INDEX_BATTERY = 1;
        }

        private void TimerModifPackage_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("timer check  2");
            Package test = new Package();
            Random rand = new Random();
            test.capacity = (float)rand.NextDouble() * 3;
            test.temperater = (float)rand.NextDouble() * 30;
            test.current = (float)rand.NextDouble() * 30;
            test.status_balance = rand.Next(0, 2) > 0;
            test.status_connect = rand.Next(0, 2) > 0;
            test.status_active =  rand.Next(3);
            Display.Add_row_data_package(INDEX_PACKAGE++, test,this);
            if (INDEX_PACKAGE == Constant.NUMBER_PACKET+1) INDEX_PACKAGE = 1;
        }

        private void timerModifyPheripheral_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("timer check  3");
            Peripheral test = new Peripheral();
            Random rand = new Random();
            test.status_connect = rand.Next(0, 2) > 0;
            Display.Add_row_data_pheripheral(INDEX_PHERI++, test,this);
            if (INDEX_PHERI == Constant.NUMBER_PHERI+1) INDEX_PHERI = 1;
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
        private void uart_read_even(object sender, SerialDataReceivedEventArgs e)
        {
            byte crc = 0x00;
            int bytes = Port.BytesToRead;
            // bytes = 8;
            byte[] buffer_rx = new byte[bytes];
            Port.Read(buffer_rx, 0, bytes);
            string content = "number of bytes read is" + bytes.ToString() + ": ";
            foreach (var item in buffer_rx)
            {
                content += " " + item.ToString("X2"); 
            }
            bool flag = false;
            if (Data.check_correct_emerPackage( buffer_rx, 
                                                bytes, 
                                                ref status_emer_bar1, 
                                                ref status_emer_bar2, 
                                                Constant.NUMBER_BATTERY)) {
                content += "success emer";
            }
            if (Data.check_correct_inforPackage(buffer_rx, 
                                                bytes, 
                                                ref battery_voltage,
                                                ref battery_temperature,
                                                Constant.NUMBER_BATTERY,
                                                ref status_voltage,
                                                ref status_temperature,
                                                Constant.NUMBER_BATTERY)) {
                                                content += " success infor";
                SetListView(battery_voltage, battery_temperature, status_voltage, status_temperature, status_emer_bar1, status_emer_bar2, Constant.NUMBER_BATTERY);
            }

            SetText(content); 
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

        void SetListView(float[] battery_voltage,
                         float[] temperature,
                         bool[] status_voltage,
                         bool[] status_temperature,
                         bool[] status_emer_bar1,
                         bool[] status_emer_bar2,
                         int size)
        {
            if (this.CustomListView_Battery.InvokeRequired)
            {
                SetTable d = new SetTable(SetListView);
                this.Invoke(d, battery_voltage, temperature, status_voltage, status_temperature, status_emer_bar1, status_emer_bar2, 16);
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    Battery temp = new Battery();
                    temp.voltage = battery_voltage[i];
                    temp.temperature = temperature[i];
                    temp.status_balance = status_temperature[i];
                    temp.warning = status_emer_bar2[i];
                    Display.Add_row_data_battery(i + 1, temp,this);
                    access_db.insert_battery("Battery", temp, i + 1);
                }
            }

        }
    }
}
