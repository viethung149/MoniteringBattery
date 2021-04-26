
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
            this.LargerIconImageList = new System.Windows.Forms.ImageList(this.components);
            this.TimerModifyBattery = new System.Windows.Forms.Timer(this.components);
            this.TimerModifPackage = new System.Windows.Forms.Timer(this.components);
            this.timerModifyPheripheral = new System.Windows.Forms.Timer(this.components);
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.tabBattery = new System.Windows.Forms.TabPage();
            this.CustomListView_Battery = new System.Windows.Forms.ListView();
            this.tabPackage = new System.Windows.Forms.TabPage();
            this.CustomListView_Package = new System.Windows.Forms.ListView();
            this.tabPheripheral = new System.Windows.Forms.TabPage();
            this.CustomListView_Pheripheral = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConnectWifi = new System.Windows.Forms.Button();
            this.btnDisconnecWifi = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.btnRelay3 = new System.Windows.Forms.Button();
            this.btnRelay2 = new System.Windows.Forms.Button();
            this.btnRelay1 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.Port = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CustomTabControl.SuspendLayout();
            this.tabBattery.SuspendLayout();
            this.tabPackage.SuspendLayout();
            this.tabPheripheral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LargerIconImageList
            // 
            this.LargerIconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.LargerIconImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.LargerIconImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TimerModifyBattery
            // 
            this.TimerModifyBattery.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerModifPackage
            // 
            this.TimerModifPackage.Enabled = true;
            this.TimerModifPackage.Tick += new System.EventHandler(this.TimerModifPackage_Tick);
            // 
            // timerModifyPheripheral
            // 
            this.timerModifyPheripheral.Enabled = true;
            this.timerModifyPheripheral.Tick += new System.EventHandler(this.timerModifyPheripheral_Tick);
            // 
            // CustomTabControl
            // 
            this.CustomTabControl.Controls.Add(this.tabBattery);
            this.CustomTabControl.Controls.Add(this.tabPackage);
            this.CustomTabControl.Controls.Add(this.tabPheripheral);
            this.CustomTabControl.Location = new System.Drawing.Point(2, 191);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(417, 256);
            this.CustomTabControl.TabIndex = 1;
            // 
            // tabBattery
            // 
            this.tabBattery.Controls.Add(this.CustomListView_Battery);
            this.tabBattery.Location = new System.Drawing.Point(4, 22);
            this.tabBattery.Name = "tabBattery";
            this.tabBattery.Padding = new System.Windows.Forms.Padding(3);
            this.tabBattery.Size = new System.Drawing.Size(409, 230);
            this.tabBattery.TabIndex = 0;
            this.tabBattery.Text = "Monitering Battery";
            this.tabBattery.UseVisualStyleBackColor = true;
            // 
            // CustomListView_Battery
            // 
            this.CustomListView_Battery.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.CustomListView_Battery.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.CustomListView_Battery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomListView_Battery.HideSelection = false;
            this.CustomListView_Battery.Location = new System.Drawing.Point(3, 3);
            this.CustomListView_Battery.Name = "CustomListView_Battery";
            this.CustomListView_Battery.Size = new System.Drawing.Size(403, 224);
            this.CustomListView_Battery.TabIndex = 0;
            this.CustomListView_Battery.UseCompatibleStateImageBehavior = false;
            // 
            // tabPackage
            // 
            this.tabPackage.Controls.Add(this.CustomListView_Package);
            this.tabPackage.Location = new System.Drawing.Point(4, 22);
            this.tabPackage.Name = "tabPackage";
            this.tabPackage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPackage.Size = new System.Drawing.Size(409, 230);
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
            this.CustomListView_Package.Size = new System.Drawing.Size(403, 224);
            this.CustomListView_Package.TabIndex = 1;
            this.CustomListView_Package.UseCompatibleStateImageBehavior = false;
            // 
            // tabPheripheral
            // 
            this.tabPheripheral.Controls.Add(this.CustomListView_Pheripheral);
            this.tabPheripheral.Location = new System.Drawing.Point(4, 22);
            this.tabPheripheral.Name = "tabPheripheral";
            this.tabPheripheral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPheripheral.Size = new System.Drawing.Size(409, 230);
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
            this.CustomListView_Pheripheral.Size = new System.Drawing.Size(403, 224);
            this.CustomListView_Pheripheral.TabIndex = 0;
            this.CustomListView_Pheripheral.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(419, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 225);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConnectWifi);
            this.panel2.Controls.Add(this.btnDisconnecWifi);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(185, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 192);
            this.panel2.TabIndex = 3;
            // 
            // btnConnectWifi
            // 
            this.btnConnectWifi.Location = new System.Drawing.Point(19, 141);
            this.btnConnectWifi.Name = "btnConnectWifi";
            this.btnConnectWifi.Size = new System.Drawing.Size(66, 23);
            this.btnConnectWifi.TabIndex = 16;
            this.btnConnectWifi.Text = "connect";
            this.btnConnectWifi.UseVisualStyleBackColor = true;
            // 
            // btnDisconnecWifi
            // 
            this.btnDisconnecWifi.Location = new System.Drawing.Point(107, 141);
            this.btnDisconnecWifi.Name = "btnDisconnecWifi";
            this.btnDisconnecWifi.Size = new System.Drawing.Size(67, 23);
            this.btnDisconnecWifi.TabIndex = 17;
            this.btnDisconnecWifi.Text = "disconnect";
            this.btnDisconnecWifi.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SSID";
            // 
            // panel1
            // 
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
            this.panel1.Size = new System.Drawing.Size(173, 192);
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
            this.btnRefresh.Location = new System.Drawing.Point(8, 166);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
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
            this.btnConnectSerial.Location = new System.Drawing.Point(97, 166);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Size = new System.Drawing.Size(66, 23);
            this.btnConnectSerial.TabIndex = 5;
            this.btnConnectSerial.Text = "connect";
            this.btnConnectSerial.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.btnRelay3);
            this.groupBox2.Controls.Add(this.btnRelay2);
            this.groupBox2.Controls.Add(this.btnRelay1);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTROL";
            // 
            // btnFan2
            // 
            this.btnFan2.Location = new System.Drawing.Point(6, 126);
            this.btnFan2.Name = "btnFan2";
            this.btnFan2.Size = new System.Drawing.Size(75, 23);
            this.btnFan2.TabIndex = 6;
            this.btnFan2.Text = "Fan 2";
            this.btnFan2.UseVisualStyleBackColor = true;
            // 
            // btnFan1
            // 
            this.btnFan1.Location = new System.Drawing.Point(6, 97);
            this.btnFan1.Name = "btnFan1";
            this.btnFan1.Size = new System.Drawing.Size(75, 23);
            this.btnFan1.TabIndex = 5;
            this.btnFan1.Text = "Fan 1";
            this.btnFan1.UseVisualStyleBackColor = true;
            // 
            // btnRelay3
            // 
            this.btnRelay3.Location = new System.Drawing.Point(256, 97);
            this.btnRelay3.Name = "btnRelay3";
            this.btnRelay3.Size = new System.Drawing.Size(75, 23);
            this.btnRelay3.TabIndex = 4;
            this.btnRelay3.Text = "Relay 3";
            this.btnRelay3.UseVisualStyleBackColor = true;
            // 
            // btnRelay2
            // 
            this.btnRelay2.Location = new System.Drawing.Point(256, 68);
            this.btnRelay2.Name = "btnRelay2";
            this.btnRelay2.Size = new System.Drawing.Size(75, 23);
            this.btnRelay2.TabIndex = 3;
            this.btnRelay2.Text = "Relay 2";
            this.btnRelay2.UseVisualStyleBackColor = true;
            // 
            // btnRelay1
            // 
            this.btnRelay1.Location = new System.Drawing.Point(256, 39);
            this.btnRelay1.Name = "btnRelay1";
            this.btnRelay1.Size = new System.Drawing.Size(75, 23);
            this.btnRelay1.TabIndex = 2;
            this.btnRelay1.Text = "Relay 1";
            this.btnRelay1.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 48);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // Port
            // 
            this.Port.BaudRate = 19200;
            this.Port.PortName = "COM4";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(425, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(357, 185);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CustomTabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CustomTabControl.ResumeLayout(false);
            this.tabBattery.ResumeLayout(false);
            this.tabPackage.ResumeLayout(false);
            this.tabPheripheral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ImageList LargerIconImageList;
        public System.Windows.Forms.Timer TimerModifyBattery;
        public System.Windows.Forms.Timer TimerModifPackage;
        public System.Windows.Forms.Timer timerModifyPheripheral;
        public System.Windows.Forms.TabControl CustomTabControl;
        public System.Windows.Forms.TabPage tabBattery;
        public System.Windows.Forms.TabPage tabPackage;
        public System.Windows.Forms.ListView CustomListView_Package;
        public System.Windows.Forms.TabPage tabPheripheral;
        public System.Windows.Forms.ListView CustomListView_Pheripheral;
        public System.Windows.Forms.ListView CustomListView_Battery;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button btnConnectSerial;
        public System.Windows.Forms.ComboBox cbParity;
        public System.Windows.Forms.ComboBox cbData;
        public System.Windows.Forms.ComboBox cbBaurate;
        public System.Windows.Forms.ComboBox cbComport;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnConnectWifi;
        public System.Windows.Forms.Button btnDisconnecWifi;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnFan2;
        public System.Windows.Forms.Button btnFan1;
        public System.Windows.Forms.Button btnRelay3;
        public System.Windows.Forms.Button btnRelay2;
        public System.Windows.Forms.Button btnRelay1;
        public System.Windows.Forms.Button btnLoad;
        public System.Windows.Forms.Button btnStart;
        public System.IO.Ports.SerialPort Port;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbStop;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}

