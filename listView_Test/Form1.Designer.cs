
namespace listView_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LargerIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.TimerModifyBattery = new System.Windows.Forms.Timer(this.components);
            this.TimerModifPackage = new System.Windows.Forms.Timer(this.components);
            this.timerModifyPheripheral = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConnectWifi = new System.Windows.Forms.Button();
            this.btnDisconnecWifi = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.lbpass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbComport = new System.Windows.Forms.ComboBox();
            this.cbBaurate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnectSerial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFan2 = new System.Windows.Forms.Button();
            this.btnFan1 = new System.Windows.Forms.Button();
            this.btnRelay2 = new System.Windows.Forms.Button();
            this.btnRelay1 = new System.Windows.Forms.Button();
            this.Port = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.tabBattery = new System.Windows.Forms.TabPage();
            this.CustomListView_Battery = new System.Windows.Forms.ListView();
            this.tabPackage = new System.Windows.Forms.TabPage();
            this.CustomListView_Package = new System.Windows.Forms.ListView();
            this.tabPheripheral = new System.Windows.Forms.TabPage();
            this.CustomListView_Pheripheral = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbChart1 = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pbChart2 = new System.Windows.Forms.PictureBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBCurrentChart2 = new System.Windows.Forms.CheckBox();
            this.cBTemperatureChart2 = new System.Windows.Forms.CheckBox();
            this.cBVoltageChart2 = new System.Windows.Forms.CheckBox();
            this.cBCurrentChart1 = new System.Windows.Forms.CheckBox();
            this.cBTemperatureChart1 = new System.Windows.Forms.CheckBox();
            this.cBVoltageChart1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExecuteMonitoringChart2 = new System.Windows.Forms.Button();
            this.btnExecuteMonitoringChart1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSelectObjChart2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSelectObjChart1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.timerChangeChart1 = new System.Windows.Forms.Timer(this.components);
            this.timerChangeChart2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.tabBattery.SuspendLayout();
            this.tabPackage.SuspendLayout();
            this.tabPheripheral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LargerIconImageList
            // 
            this.LargerIconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargerIconImageList.ImageStream")));
            this.LargerIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.LargerIconImageList.Images.SetKeyName(0, "cellIcon.png");
            this.LargerIconImageList.Images.SetKeyName(1, "packageIcon.png");
            this.LargerIconImageList.Images.SetKeyName(2, "pheripheralIcon.png");
            // 
            // TimerModifyBattery
            // 
            this.TimerModifyBattery.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerModifPackage
            // 
            this.TimerModifPackage.Tick += new System.EventHandler(this.TimerModifPackage_Tick);
            // 
            // timerModifyPheripheral
            // 
            this.timerModifyPheripheral.Tick += new System.EventHandler(this.timerModifyPheripheral_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnConnectWifi);
            this.panel2.Controls.Add(this.btnDisconnecWifi);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSSID);
            this.panel2.Controls.Add(this.lbpass);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(185, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 197);
            this.panel2.TabIndex = 3;
            // 
            // btnConnectWifi
            // 
            this.btnConnectWifi.Location = new System.Drawing.Point(19, 166);
            this.btnConnectWifi.Name = "btnConnectWifi";
            this.btnConnectWifi.Size = new System.Drawing.Size(66, 23);
            this.btnConnectWifi.TabIndex = 16;
            this.btnConnectWifi.Text = "connect";
            this.btnConnectWifi.UseVisualStyleBackColor = true;
            this.btnConnectWifi.Click += new System.EventHandler(this.btnConnectWifi_Click);
            // 
            // btnDisconnecWifi
            // 
            this.btnDisconnecWifi.Location = new System.Drawing.Point(102, 166);
            this.btnDisconnecWifi.Name = "btnDisconnecWifi";
            this.btnDisconnecWifi.Size = new System.Drawing.Size(67, 23);
            this.btnDisconnecWifi.TabIndex = 17;
            this.btnDisconnecWifi.Text = "disconnect";
            this.btnDisconnecWifi.UseVisualStyleBackColor = true;
            this.btnDisconnecWifi.Click += new System.EventHandler(this.btnDisconnecWifi_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "wifi";
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(78, 30);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(100, 20);
            this.txtSSID.TabIndex = 6;
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Location = new System.Drawing.Point(3, 65);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(53, 13);
            this.lbpass.TabIndex = 14;
            this.lbpass.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(78, 62);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SSID";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbStop);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cbComport);
            this.panel1.Controls.Add(this.cbBaurate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbData);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbParity);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnConnectSerial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 198);
            this.panel1.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Stop";
            // 
            // cbStop
            // 
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(57, 140);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(106, 21);
            this.cbStop.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Serial Port";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Lime;
            this.btnRefresh.Location = new System.Drawing.Point(8, 166);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbComport
            // 
            this.cbComport.FormattingEnabled = true;
            this.cbComport.Location = new System.Drawing.Point(57, 30);
            this.cbComport.Name = "cbComport";
            this.cbComport.Size = new System.Drawing.Size(106, 21);
            this.cbComport.TabIndex = 0;
            // 
            // cbBaurate
            // 
            this.cbBaurate.FormattingEnabled = true;
            this.cbBaurate.Location = new System.Drawing.Point(57, 59);
            this.cbBaurate.Name = "cbBaurate";
            this.cbBaurate.Size = new System.Drawing.Size(106, 21);
            this.cbBaurate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Parity";
            // 
            // cbData
            // 
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(57, 86);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(106, 21);
            this.cbData.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(57, 113);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(106, 21);
            this.cbParity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Baudrate";
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.BackColor = System.Drawing.Color.Lime;
            this.btnConnectSerial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectSerial.Location = new System.Drawing.Point(97, 166);
            this.btnConnectSerial.Margin = new System.Windows.Forms.Padding(0);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Size = new System.Drawing.Size(66, 23);
            this.btnConnectSerial.TabIndex = 5;
            this.btnConnectSerial.Text = "connect";
            this.btnConnectSerial.UseVisualStyleBackColor = false;
            this.btnConnectSerial.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Com port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFan2);
            this.groupBox2.Controls.Add(this.btnFan1);
            this.groupBox2.Controls.Add(this.btnRelay2);
            this.groupBox2.Controls.Add(this.btnRelay1);
            this.groupBox2.Location = new System.Drawing.Point(749, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 222);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTROL";
            // 
            // btnFan2
            // 
            this.btnFan2.Location = new System.Drawing.Point(6, 101);
            this.btnFan2.Name = "btnFan2";
            this.btnFan2.Size = new System.Drawing.Size(75, 23);
            this.btnFan2.TabIndex = 6;
            this.btnFan2.Text = "Fan 2";
            this.btnFan2.UseVisualStyleBackColor = true;
            this.btnFan2.Click += new System.EventHandler(this.btnFan2_Click);
            // 
            // btnFan1
            // 
            this.btnFan1.Location = new System.Drawing.Point(6, 72);
            this.btnFan1.Name = "btnFan1";
            this.btnFan1.Size = new System.Drawing.Size(75, 23);
            this.btnFan1.TabIndex = 5;
            this.btnFan1.Text = "Fan 1";
            this.btnFan1.UseVisualStyleBackColor = true;
            this.btnFan1.Click += new System.EventHandler(this.btnFan1_Click);
            // 
            // btnRelay2
            // 
            this.btnRelay2.Location = new System.Drawing.Point(6, 43);
            this.btnRelay2.Name = "btnRelay2";
            this.btnRelay2.Size = new System.Drawing.Size(75, 23);
            this.btnRelay2.TabIndex = 3;
            this.btnRelay2.Text = "Relay 2";
            this.btnRelay2.UseVisualStyleBackColor = true;
            this.btnRelay2.Click += new System.EventHandler(this.btnRelay2_Click);
            // 
            // btnRelay1
            // 
            this.btnRelay1.Location = new System.Drawing.Point(6, 15);
            this.btnRelay1.Name = "btnRelay1";
            this.btnRelay1.Size = new System.Drawing.Size(75, 23);
            this.btnRelay1.TabIndex = 2;
            this.btnRelay1.Text = "Relay 1";
            this.btnRelay1.UseVisualStyleBackColor = true;
            this.btnRelay1.Click += new System.EventHandler(this.btnRelay1_Click);
            // 
            // Port
            // 
            this.Port.BaudRate = 19200;
            this.Port.PortName = "COM4";
            this.Port.ReceivedBytesThreshold = 135;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(896, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(149, 194);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnChart);
            this.groupBox3.Location = new System.Drawing.Point(645, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(98, 222);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(0, 15);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 0;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 248);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.splitContainer2);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Location = new System.Drawing.Point(1, 239);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1051, 248);
            this.panel4.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CustomTabControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1048, 248);
            this.splitContainer2.SplitterDistance = 380;
            this.splitContainer2.TabIndex = 8;
            // 
            // CustomTabControl
            // 
            this.CustomTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomTabControl.Controls.Add(this.tabBattery);
            this.CustomTabControl.Controls.Add(this.tabPackage);
            this.CustomTabControl.Controls.Add(this.tabPheripheral);
            this.CustomTabControl.ImageList = this.LargerIconImageList;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(378, 246);
            this.CustomTabControl.TabIndex = 1;
            // 
            // tabBattery
            // 
            this.tabBattery.Controls.Add(this.CustomListView_Battery);
            this.tabBattery.ImageIndex = 0;
            this.tabBattery.Location = new System.Drawing.Point(4, 23);
            this.tabBattery.Name = "tabBattery";
            this.tabBattery.Padding = new System.Windows.Forms.Padding(3);
            this.tabBattery.Size = new System.Drawing.Size(370, 219);
            this.tabBattery.TabIndex = 0;
            this.tabBattery.Text = "Monitering Battery";
            this.tabBattery.UseVisualStyleBackColor = true;
            // 
            // CustomListView_Battery
            // 
            this.CustomListView_Battery.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.CustomListView_Battery.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.CustomListView_Battery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomListView_Battery.HideSelection = false;
            this.CustomListView_Battery.Location = new System.Drawing.Point(3, 3);
            this.CustomListView_Battery.Name = "CustomListView_Battery";
            this.CustomListView_Battery.Size = new System.Drawing.Size(364, 213);
            this.CustomListView_Battery.TabIndex = 0;
            this.CustomListView_Battery.UseCompatibleStateImageBehavior = false;
            // 
            // tabPackage
            // 
            this.tabPackage.Controls.Add(this.CustomListView_Package);
            this.tabPackage.ImageIndex = 1;
            this.tabPackage.Location = new System.Drawing.Point(4, 23);
            this.tabPackage.Name = "tabPackage";
            this.tabPackage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPackage.Size = new System.Drawing.Size(370, 219);
            this.tabPackage.TabIndex = 1;
            this.tabPackage.Text = "Package_Monitoring";
            this.tabPackage.UseVisualStyleBackColor = true;
            // 
            // CustomListView_Package
            // 
            this.CustomListView_Package.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomListView_Package.HideSelection = false;
            this.CustomListView_Package.Location = new System.Drawing.Point(3, 3);
            this.CustomListView_Package.Name = "CustomListView_Package";
            this.CustomListView_Package.Size = new System.Drawing.Size(364, 213);
            this.CustomListView_Package.TabIndex = 1;
            this.CustomListView_Package.UseCompatibleStateImageBehavior = false;
            // 
            // tabPheripheral
            // 
            this.tabPheripheral.Controls.Add(this.CustomListView_Pheripheral);
            this.tabPheripheral.ImageIndex = 2;
            this.tabPheripheral.Location = new System.Drawing.Point(4, 23);
            this.tabPheripheral.Name = "tabPheripheral";
            this.tabPheripheral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPheripheral.Size = new System.Drawing.Size(370, 219);
            this.tabPheripheral.TabIndex = 2;
            this.tabPheripheral.Text = "Monitering Pheripheral";
            this.tabPheripheral.UseVisualStyleBackColor = true;
            // 
            // CustomListView_Pheripheral
            // 
            this.CustomListView_Pheripheral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomListView_Pheripheral.HideSelection = false;
            this.CustomListView_Pheripheral.Location = new System.Drawing.Point(3, 3);
            this.CustomListView_Pheripheral.Name = "CustomListView_Pheripheral";
            this.CustomListView_Pheripheral.Size = new System.Drawing.Size(364, 213);
            this.CustomListView_Pheripheral.TabIndex = 0;
            this.CustomListView_Pheripheral.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbChart1);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbChart2);
            this.splitContainer1.Panel2.Controls.Add(this.chart2);
            this.splitContainer1.Size = new System.Drawing.Size(664, 248);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 0;
            // 
            // pbChart1
            // 
            this.pbChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbChart1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbChart1.ErrorImage")));
            this.pbChart1.Image = ((System.Drawing.Image)(resources.GetObject("pbChart1.Image")));
            this.pbChart1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbChart1.InitialImage")));
            this.pbChart1.Location = new System.Drawing.Point(297, 212);
            this.pbChart1.Name = "pbChart1";
            this.pbChart1.Size = new System.Drawing.Size(33, 30);
            this.pbChart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChart1.TabIndex = 10;
            this.pbChart1.TabStop = false;
            this.pbChart1.Visible = false;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(333, 246);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp);
            // 
            // pbChart2
            // 
            this.pbChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbChart2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbChart2.ErrorImage")));
            this.pbChart2.Image = ((System.Drawing.Image)(resources.GetObject("pbChart2.Image")));
            this.pbChart2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbChart2.InitialImage")));
            this.pbChart2.Location = new System.Drawing.Point(288, 214);
            this.pbChart2.Name = "pbChart2";
            this.pbChart2.Size = new System.Drawing.Size(33, 30);
            this.pbChart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbChart2.TabIndex = 11;
            this.pbChart2.TabStop = false;
            this.pbChart2.Visible = false;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(323, 246);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            this.chart2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseDoubleClick);
            this.chart2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseDown);
            this.chart2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseMove);
            this.chart2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBCurrentChart2);
            this.groupBox4.Controls.Add(this.cBTemperatureChart2);
            this.groupBox4.Controls.Add(this.cBVoltageChart2);
            this.groupBox4.Controls.Add(this.cBCurrentChart1);
            this.groupBox4.Controls.Add(this.cBTemperatureChart1);
            this.groupBox4.Controls.Add(this.cBVoltageChart1);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnExecuteMonitoringChart2);
            this.groupBox4.Controls.Add(this.btnExecuteMonitoringChart1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.cbSelectObjChart2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cbSelectObjChart1);
            this.groupBox4.Location = new System.Drawing.Point(388, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(251, 221);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Real Time Chart";
            // 
            // cBCurrentChart2
            // 
            this.cBCurrentChart2.AutoSize = true;
            this.cBCurrentChart2.Location = new System.Drawing.Point(188, 144);
            this.cBCurrentChart2.Name = "cBCurrentChart2";
            this.cBCurrentChart2.Size = new System.Drawing.Size(60, 17);
            this.cBCurrentChart2.TabIndex = 26;
            this.cBCurrentChart2.Text = "Current";
            this.cBCurrentChart2.UseVisualStyleBackColor = true;
            // 
            // cBTemperatureChart2
            // 
            this.cBTemperatureChart2.AutoSize = true;
            this.cBTemperatureChart2.Location = new System.Drawing.Point(90, 144);
            this.cBTemperatureChart2.Name = "cBTemperatureChart2";
            this.cBTemperatureChart2.Size = new System.Drawing.Size(86, 17);
            this.cBTemperatureChart2.TabIndex = 25;
            this.cBTemperatureChart2.Text = "Temperature";
            this.cBTemperatureChart2.UseVisualStyleBackColor = true;
            // 
            // cBVoltageChart2
            // 
            this.cBVoltageChart2.AutoSize = true;
            this.cBVoltageChart2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cBVoltageChart2.Location = new System.Drawing.Point(16, 144);
            this.cBVoltageChart2.Name = "cBVoltageChart2";
            this.cBVoltageChart2.Size = new System.Drawing.Size(62, 17);
            this.cBVoltageChart2.TabIndex = 24;
            this.cBVoltageChart2.Text = "Voltage";
            this.cBVoltageChart2.UseVisualStyleBackColor = true;
            // 
            // cBCurrentChart1
            // 
            this.cBCurrentChart1.AutoSize = true;
            this.cBCurrentChart1.Location = new System.Drawing.Point(188, 74);
            this.cBCurrentChart1.Name = "cBCurrentChart1";
            this.cBCurrentChart1.Size = new System.Drawing.Size(60, 17);
            this.cBCurrentChart1.TabIndex = 23;
            this.cBCurrentChart1.Text = "Current";
            this.cBCurrentChart1.UseVisualStyleBackColor = true;
            // 
            // cBTemperatureChart1
            // 
            this.cBTemperatureChart1.AutoSize = true;
            this.cBTemperatureChart1.Location = new System.Drawing.Point(90, 74);
            this.cBTemperatureChart1.Name = "cBTemperatureChart1";
            this.cBTemperatureChart1.Size = new System.Drawing.Size(86, 17);
            this.cBTemperatureChart1.TabIndex = 22;
            this.cBTemperatureChart1.Text = "Temperature";
            this.cBTemperatureChart1.UseVisualStyleBackColor = true;
            // 
            // cBVoltageChart1
            // 
            this.cBVoltageChart1.AutoSize = true;
            this.cBVoltageChart1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cBVoltageChart1.Location = new System.Drawing.Point(16, 74);
            this.cBVoltageChart1.Name = "cBVoltageChart1";
            this.cBVoltageChart1.Size = new System.Drawing.Size(62, 17);
            this.cBVoltageChart1.TabIndex = 21;
            this.cBVoltageChart1.Text = "Voltage";
            this.cBVoltageChart1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "- Select Object";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "- Select object";
            // 
            // btnExecuteMonitoringChart2
            // 
            this.btnExecuteMonitoringChart2.Location = new System.Drawing.Point(141, 185);
            this.btnExecuteMonitoringChart2.Name = "btnExecuteMonitoringChart2";
            this.btnExecuteMonitoringChart2.Size = new System.Drawing.Size(104, 23);
            this.btnExecuteMonitoringChart2.TabIndex = 7;
            this.btnExecuteMonitoringChart2.Text = "Monitoring Chart 2";
            this.btnExecuteMonitoringChart2.UseVisualStyleBackColor = true;
            this.btnExecuteMonitoringChart2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExecuteMonitoringChart1
            // 
            this.btnExecuteMonitoringChart1.Location = new System.Drawing.Point(16, 185);
            this.btnExecuteMonitoringChart1.Name = "btnExecuteMonitoringChart1";
            this.btnExecuteMonitoringChart1.Size = new System.Drawing.Size(104, 23);
            this.btnExecuteMonitoringChart1.TabIndex = 6;
            this.btnExecuteMonitoringChart1.Text = "Monitoring Chart 1";
            this.btnExecuteMonitoringChart1.UseVisualStyleBackColor = true;
            this.btnExecuteMonitoringChart1.Click += new System.EventHandler(this.btnExecuteMonitoring_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Monitoring Chart 2";
            // 
            // cbSelectObjChart2
            // 
            this.cbSelectObjChart2.FormattingEnabled = true;
            this.cbSelectObjChart2.Location = new System.Drawing.Point(96, 115);
            this.cbSelectObjChart2.Name = "cbSelectObjChart2";
            this.cbSelectObjChart2.Size = new System.Drawing.Size(121, 21);
            this.cbSelectObjChart2.TabIndex = 4;
            this.cbSelectObjChart2.SelectedIndexChanged += new System.EventHandler(this.cbSelectObjChart2_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Monitoring Chart 1";
            // 
            // cbSelectObjChart1
            // 
            this.cbSelectObjChart1.FormattingEnabled = true;
            this.cbSelectObjChart1.Location = new System.Drawing.Point(96, 41);
            this.cbSelectObjChart1.Name = "cbSelectObjChart1";
            this.cbSelectObjChart1.Size = new System.Drawing.Size(121, 21);
            this.cbSelectObjChart1.TabIndex = 2;
            this.cbSelectObjChart1.SelectedIndexChanged += new System.EventHandler(this.cbSelectObjChart1_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Image = ((System.Drawing.Image)(resources.GetObject("label14.Image")));
            this.label14.Location = new System.Drawing.Point(1004, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "label14";
            // 
            // timerChangeChart1
            // 
            this.timerChangeChart1.Interval = 500;
            this.timerChangeChart1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timerChangeChart2
            // 
            this.timerChangeChart2.Interval = 500;
            this.timerChangeChart2.Tick += new System.EventHandler(this.timerChangeChart2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 489);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring Battery System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.CustomTabControl.ResumeLayout(false);
            this.tabBattery.ResumeLayout(false);
            this.tabPackage.ResumeLayout(false);
            this.tabPheripheral.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ImageList LargerIconImageList;
        public System.Windows.Forms.Timer TimerModifyBattery;
        public System.Windows.Forms.Timer TimerModifPackage;
        public System.Windows.Forms.Timer timerModifyPheripheral;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.TextBox txtPass;
        public System.Windows.Forms.TextBox txtSSID;
        public System.Windows.Forms.Button btnConnectSerial;
        public System.Windows.Forms.ComboBox cbParity;
        public System.Windows.Forms.ComboBox cbData;
        public System.Windows.Forms.ComboBox cbBaurate;
        public System.Windows.Forms.ComboBox cbComport;
        public System.Windows.Forms.Label lbpass;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnConnectWifi;
        public System.Windows.Forms.Button btnDisconnecWifi;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnFan2;
        public System.Windows.Forms.Button btnFan1;
        public System.Windows.Forms.Button btnRelay2;
        public System.Windows.Forms.Button btnRelay1;
        public System.IO.Ports.SerialPort Port;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbStop;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.TabControl CustomTabControl;
        public System.Windows.Forms.TabPage tabBattery;
        public System.Windows.Forms.ListView CustomListView_Battery;
        public System.Windows.Forms.TabPage tabPackage;
        public System.Windows.Forms.ListView CustomListView_Package;
        public System.Windows.Forms.TabPage tabPheripheral;
        public System.Windows.Forms.ListView CustomListView_Pheripheral;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExecuteMonitoringChart1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbSelectObjChart2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSelectObjChart1;
        private System.Windows.Forms.Button btnExecuteMonitoringChart2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cBCurrentChart2;
        private System.Windows.Forms.CheckBox cBTemperatureChart2;
        private System.Windows.Forms.CheckBox cBVoltageChart2;
        private System.Windows.Forms.CheckBox cBCurrentChart1;
        private System.Windows.Forms.CheckBox cBTemperatureChart1;
        private System.Windows.Forms.CheckBox cBVoltageChart1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pbChart1;
        private System.Windows.Forms.PictureBox pbChart2;
        private System.Windows.Forms.Timer timerChangeChart1;
        private System.Windows.Forms.Timer timerChangeChart2;
    }
}

