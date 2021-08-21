
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnConnectWifi = new System.Windows.Forms.Button();
            this.btnDisconnecWifi = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.lbpass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnFan2 = new System.Windows.Forms.Button();
            this.btnFan1 = new System.Windows.Forms.Button();
            this.btnRelay2 = new System.Windows.Forms.Button();
            this.btnRelay1 = new System.Windows.Forms.Button();
            this.Port = new System.IO.Ports.SerialPort(this.components);
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.cBCurrentChart2 = new System.Windows.Forms.CheckBox();
            this.cBTemperatureChart2 = new System.Windows.Forms.CheckBox();
            this.cBVoltageChart2 = new System.Windows.Forms.CheckBox();
            this.cBCurrentChart1 = new System.Windows.Forms.CheckBox();
            this.btnExecuteMonitoringChart2 = new System.Windows.Forms.Button();
            this.btnExecuteMonitoringChart1 = new System.Windows.Forms.Button();
            this.cBTemperatureChart1 = new System.Windows.Forms.CheckBox();
            this.cBVoltageChart1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSelectObjChart2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSelectObjChart1 = new System.Windows.Forms.ComboBox();
            this.timerChangeChart1 = new System.Windows.Forms.Timer(this.components);
            this.timerChangeChart2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(283, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONNECT";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnConnectWifi);
            this.panel2.Controls.Add(this.btnDisconnecWifi);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSSID);
            this.panel2.Controls.Add(this.lbpass);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(195, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 192);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // btnConnectWifi
            // 
            this.btnConnectWifi.BackColor = System.Drawing.Color.Lime;
            this.btnConnectWifi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnectWifi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectWifi.ForeColor = System.Drawing.Color.Black;
            this.btnConnectWifi.Location = new System.Drawing.Point(3, 165);
            this.btnConnectWifi.Name = "btnConnectWifi";
            this.btnConnectWifi.Size = new System.Drawing.Size(77, 23);
            this.btnConnectWifi.TabIndex = 16;
            this.btnConnectWifi.Text = "Connect";
            this.btnConnectWifi.UseVisualStyleBackColor = false;
            this.btnConnectWifi.Click += new System.EventHandler(this.btnConnectWifi_Click);
            // 
            // btnDisconnecWifi
            // 
            this.btnDisconnecWifi.BackColor = System.Drawing.Color.Red;
            this.btnDisconnecWifi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDisconnecWifi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnecWifi.ForeColor = System.Drawing.Color.Black;
            this.btnDisconnecWifi.Location = new System.Drawing.Point(96, 165);
            this.btnDisconnecWifi.Name = "btnDisconnecWifi";
            this.btnDisconnecWifi.Size = new System.Drawing.Size(77, 23);
            this.btnDisconnecWifi.TabIndex = 17;
            this.btnDisconnecWifi.Text = "Disconnect";
            this.btnDisconnecWifi.UseVisualStyleBackColor = false;
            this.btnDisconnecWifi.Click += new System.EventHandler(this.btnDisconnecWifi_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(78, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "WIFI";
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(78, 30);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(95, 23);
            this.txtSSID.TabIndex = 6;
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass.ForeColor = System.Drawing.Color.Black;
            this.lbpass.Location = new System.Drawing.Point(3, 70);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(69, 15);
            this.lbpass.TabIndex = 14;
            this.lbpass.Text = "PASSWORD";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(78, 62);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(95, 23);
            this.txtPass.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "SSID";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.pictureBox1);
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
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 193);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "STOP BIT";
            // 
            // cbStop
            // 
            this.cbStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(67, 137);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(106, 24);
            this.cbStop.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "SERIAL PORT";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Lime;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(3, 165);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbComport
            // 
            this.cbComport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbComport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComport.FormattingEnabled = true;
            this.cbComport.Location = new System.Drawing.Point(67, 29);
            this.cbComport.Name = "cbComport";
            this.cbComport.Size = new System.Drawing.Size(106, 24);
            this.cbComport.TabIndex = 0;
            // 
            // cbBaurate
            // 
            this.cbBaurate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbBaurate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBaurate.FormattingEnabled = true;
            this.cbBaurate.Location = new System.Drawing.Point(67, 56);
            this.cbBaurate.Name = "cbBaurate";
            this.cbBaurate.Size = new System.Drawing.Size(106, 24);
            this.cbBaurate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "PARITY";
            // 
            // cbData
            // 
            this.cbData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(67, 83);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(106, 24);
            this.cbData.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "DATA";
            // 
            // cbParity
            // 
            this.cbParity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(67, 110);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(106, 24);
            this.cbParity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "BAUDRATE";
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.BackColor = System.Drawing.Color.Lime;
            this.btnConnectSerial.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnectSerial.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectSerial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectSerial.Location = new System.Drawing.Point(90, 165);
            this.btnConnectSerial.Margin = new System.Windows.Forms.Padding(0);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Size = new System.Drawing.Size(83, 23);
            this.btnConnectSerial.TabIndex = 5;
            this.btnConnectSerial.Text = "Connect";
            this.btnConnectSerial.UseVisualStyleBackColor = false;
            this.btnConnectSerial.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "PORT";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.pictureBox5);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.btnChart);
            this.groupBox2.Controls.Add(this.btnFan2);
            this.groupBox2.Controls.Add(this.btnFan1);
            this.groupBox2.Controls.Add(this.btnRelay2);
            this.groupBox2.Controls.Add(this.btnRelay1);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(952, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 219);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTROL";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.InitialImage = null;
            this.pictureBox5.Location = new System.Drawing.Point(6, 164);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 28;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(6, 17);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.Location = new System.Drawing.Point(6, 193);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(88, 23);
            this.btnChart.TabIndex = 0;
            this.btnChart.Text = "More Monitor";
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnFan2
            // 
            this.btnFan2.BackColor = System.Drawing.Color.Aqua;
            this.btnFan2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFan2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFan2.Location = new System.Drawing.Point(6, 138);
            this.btnFan2.Name = "btnFan2";
            this.btnFan2.Size = new System.Drawing.Size(88, 23);
            this.btnFan2.TabIndex = 6;
            this.btnFan2.Text = "Fan 2";
            this.btnFan2.UseVisualStyleBackColor = false;
            this.btnFan2.Click += new System.EventHandler(this.btnFan2_Click);
            // 
            // btnFan1
            // 
            this.btnFan1.BackColor = System.Drawing.Color.Aqua;
            this.btnFan1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFan1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFan1.Location = new System.Drawing.Point(6, 108);
            this.btnFan1.Name = "btnFan1";
            this.btnFan1.Size = new System.Drawing.Size(88, 23);
            this.btnFan1.TabIndex = 5;
            this.btnFan1.Text = "Fan 1";
            this.btnFan1.UseVisualStyleBackColor = false;
            this.btnFan1.Click += new System.EventHandler(this.btnFan1_Click);
            // 
            // btnRelay2
            // 
            this.btnRelay2.BackColor = System.Drawing.Color.Aqua;
            this.btnRelay2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelay2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelay2.Location = new System.Drawing.Point(6, 78);
            this.btnRelay2.Name = "btnRelay2";
            this.btnRelay2.Size = new System.Drawing.Size(88, 23);
            this.btnRelay2.TabIndex = 3;
            this.btnRelay2.Text = "Relay 2";
            this.btnRelay2.UseVisualStyleBackColor = false;
            this.btnRelay2.Click += new System.EventHandler(this.btnRelay2_Click);
            // 
            // btnRelay1
            // 
            this.btnRelay1.BackColor = System.Drawing.Color.Aqua;
            this.btnRelay1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelay1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelay1.Location = new System.Drawing.Point(6, 48);
            this.btnRelay1.Name = "btnRelay1";
            this.btnRelay1.Size = new System.Drawing.Size(88, 23);
            this.btnRelay1.TabIndex = 2;
            this.btnRelay1.Text = "Relay 1";
            this.btnRelay1.UseVisualStyleBackColor = false;
            this.btnRelay1.Click += new System.EventHandler(this.btnRelay1_Click);
            // 
            // Port
            // 
            this.Port.BaudRate = 19200;
            this.Port.PortName = "COM4";
            this.Port.ReceivedBytesThreshold = 135;
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
            this.tabBattery.Text = "Moniter Battery";
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
            this.tabPackage.Text = "Monitor Package";
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
            this.tabPheripheral.Text = "Monitor Relay";
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
            this.chart1.BorderlineColor = System.Drawing.Color.Gray;
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
            this.chart2.BorderlineColor = System.Drawing.Color.Gray;
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
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.pictureBox7);
            this.groupBox4.Controls.Add(this.pictureBox6);
            this.groupBox4.Controls.Add(this.cBCurrentChart2);
            this.groupBox4.Controls.Add(this.cBTemperatureChart2);
            this.groupBox4.Controls.Add(this.cBVoltageChart2);
            this.groupBox4.Controls.Add(this.cBCurrentChart1);
            this.groupBox4.Controls.Add(this.btnExecuteMonitoringChart2);
            this.groupBox4.Controls.Add(this.btnExecuteMonitoringChart1);
            this.groupBox4.Controls.Add(this.cBTemperatureChart1);
            this.groupBox4.Controls.Add(this.cBVoltageChart1);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.cbSelectObjChart2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cbSelectObjChart1);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(666, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 220);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "REAL TIME CHART";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(191, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(82, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.InitialImage = null;
            this.pictureBox7.Location = new System.Drawing.Point(52, 194);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(36, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 28;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.InitialImage = null;
            this.pictureBox6.Location = new System.Drawing.Point(52, 95);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(36, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 27;
            this.pictureBox6.TabStop = false;
            // 
            // cBCurrentChart2
            // 
            this.cBCurrentChart2.AutoSize = true;
            this.cBCurrentChart2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBCurrentChart2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCurrentChart2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBCurrentChart2.Location = new System.Drawing.Point(213, 171);
            this.cBCurrentChart2.Name = "cBCurrentChart2";
            this.cBCurrentChart2.Size = new System.Drawing.Size(60, 18);
            this.cBCurrentChart2.TabIndex = 26;
            this.cBCurrentChart2.Text = "Current";
            this.cBCurrentChart2.UseVisualStyleBackColor = true;
            // 
            // cBTemperatureChart2
            // 
            this.cBTemperatureChart2.AutoSize = true;
            this.cBTemperatureChart2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBTemperatureChart2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBTemperatureChart2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBTemperatureChart2.Location = new System.Drawing.Point(96, 171);
            this.cBTemperatureChart2.Name = "cBTemperatureChart2";
            this.cBTemperatureChart2.Size = new System.Drawing.Size(87, 18);
            this.cBTemperatureChart2.TabIndex = 25;
            this.cBTemperatureChart2.Text = "Temperature";
            this.cBTemperatureChart2.UseVisualStyleBackColor = true;
            // 
            // cBVoltageChart2
            // 
            this.cBVoltageChart2.AutoSize = true;
            this.cBVoltageChart2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cBVoltageChart2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBVoltageChart2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBVoltageChart2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBVoltageChart2.Location = new System.Drawing.Point(16, 171);
            this.cBVoltageChart2.Name = "cBVoltageChart2";
            this.cBVoltageChart2.Size = new System.Drawing.Size(61, 18);
            this.cBVoltageChart2.TabIndex = 24;
            this.cBVoltageChart2.Text = "Voltage";
            this.cBVoltageChart2.UseVisualStyleBackColor = true;
            // 
            // cBCurrentChart1
            // 
            this.cBCurrentChart1.AutoSize = true;
            this.cBCurrentChart1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBCurrentChart1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCurrentChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBCurrentChart1.Location = new System.Drawing.Point(213, 70);
            this.cBCurrentChart1.Name = "cBCurrentChart1";
            this.cBCurrentChart1.Size = new System.Drawing.Size(60, 18);
            this.cBCurrentChart1.TabIndex = 23;
            this.cBCurrentChart1.Text = "Current";
            this.cBCurrentChart1.UseVisualStyleBackColor = true;
            // 
            // btnExecuteMonitoringChart2
            // 
            this.btnExecuteMonitoringChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExecuteMonitoringChart2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecuteMonitoringChart2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteMonitoringChart2.Location = new System.Drawing.Point(96, 195);
            this.btnExecuteMonitoringChart2.Name = "btnExecuteMonitoringChart2";
            this.btnExecuteMonitoringChart2.Size = new System.Drawing.Size(135, 25);
            this.btnExecuteMonitoringChart2.TabIndex = 7;
            this.btnExecuteMonitoringChart2.Text = "Monitoring Chart 2";
            this.btnExecuteMonitoringChart2.UseVisualStyleBackColor = false;
            this.btnExecuteMonitoringChart2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExecuteMonitoringChart1
            // 
            this.btnExecuteMonitoringChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExecuteMonitoringChart1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExecuteMonitoringChart1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteMonitoringChart1.Location = new System.Drawing.Point(96, 95);
            this.btnExecuteMonitoringChart1.Name = "btnExecuteMonitoringChart1";
            this.btnExecuteMonitoringChart1.Size = new System.Drawing.Size(135, 26);
            this.btnExecuteMonitoringChart1.TabIndex = 6;
            this.btnExecuteMonitoringChart1.Text = "Monitoring Chart 1";
            this.btnExecuteMonitoringChart1.UseVisualStyleBackColor = false;
            this.btnExecuteMonitoringChart1.Click += new System.EventHandler(this.btnExecuteMonitoring_Click);
            // 
            // cBTemperatureChart1
            // 
            this.cBTemperatureChart1.AutoSize = true;
            this.cBTemperatureChart1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBTemperatureChart1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBTemperatureChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBTemperatureChart1.Location = new System.Drawing.Point(96, 70);
            this.cBTemperatureChart1.Name = "cBTemperatureChart1";
            this.cBTemperatureChart1.Size = new System.Drawing.Size(87, 18);
            this.cBTemperatureChart1.TabIndex = 22;
            this.cBTemperatureChart1.Text = "Temperature";
            this.cBTemperatureChart1.UseVisualStyleBackColor = true;
            // 
            // cBVoltageChart1
            // 
            this.cBVoltageChart1.AutoSize = true;
            this.cBVoltageChart1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cBVoltageChart1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cBVoltageChart1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBVoltageChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cBVoltageChart1.Location = new System.Drawing.Point(12, 70);
            this.cBVoltageChart1.Name = "cBVoltageChart1";
            this.cBVoltageChart1.Size = new System.Drawing.Size(61, 18);
            this.cBVoltageChart1.TabIndex = 21;
            this.cBVoltageChart1.Text = "Voltage";
            this.cBVoltageChart1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(13, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 14);
            this.label13.TabIndex = 9;
            this.label13.Text = "Select Object";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(13, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "Select Object";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Monitoring Chart 2";
            // 
            // cbSelectObjChart2
            // 
            this.cbSelectObjChart2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSelectObjChart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectObjChart2.FormattingEnabled = true;
            this.cbSelectObjChart2.Location = new System.Drawing.Point(96, 142);
            this.cbSelectObjChart2.Name = "cbSelectObjChart2";
            this.cbSelectObjChart2.Size = new System.Drawing.Size(177, 23);
            this.cbSelectObjChart2.TabIndex = 4;
            this.cbSelectObjChart2.SelectedIndexChanged += new System.EventHandler(this.cbSelectObjChart2_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Monitoring Chart 1";
            // 
            // cbSelectObjChart1
            // 
            this.cbSelectObjChart1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbSelectObjChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectObjChart1.FormattingEnabled = true;
            this.cbSelectObjChart1.Location = new System.Drawing.Point(96, 41);
            this.cbSelectObjChart1.Name = "cbSelectObjChart1";
            this.cbSelectObjChart1.Size = new System.Drawing.Size(177, 23);
            this.cbSelectObjChart1.TabIndex = 2;
            this.cbSelectObjChart1.SelectedIndexChanged += new System.EventHandler(this.cbSelectObjChart1_SelectedIndexChanged);
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.pictureBox8);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 221);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "INFORMATION";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(67, 175);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 15);
            this.label23.TabIndex = 39;
            this.label23.Text = "0964029461";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(6, 175);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 15);
            this.label22.TabIndex = 38;
            this.label22.Text = "PHONE";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(67, 148);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(179, 15);
            this.label21.TabIndex = 37;
            this.label21.Text = "hung.hoang.viet@hcmut.edu.vn";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(6, 148);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 15);
            this.label20.TabIndex = 36;
            this.label20.Text = "EMAIL";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(-1, 27);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(36, 27);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 17;
            this.pictureBox8.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(34, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(241, 15);
            this.label19.TabIndex = 35;
            this.label19.Text = "HO CHI MINH UNIVERSITY OF TECHNOLOGY";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(67, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 15);
            this.label18.TabIndex = 34;
            this.label18.Text = "1711626";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(67, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 15);
            this.label17.TabIndex = 33;
            this.label17.Text = "HOANG VIET HUNG";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(6, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 15);
            this.label16.TabIndex = 32;
            this.label16.Text = "ID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(6, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 15);
            this.label15.TabIndex = 31;
            this.label15.Text = "STUDENT";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(6, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "THESIS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "BATTERY MONITORING SYSTEM";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(1, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1051, 226);
            this.panel3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 489);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitoring Battery System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pbChart1;
        private System.Windows.Forms.PictureBox pbChart2;
        private System.Windows.Forms.Timer timerChangeChart1;
        private System.Windows.Forms.Timer timerChangeChart2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pictureBox8;
        public System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel3;
    }
}

