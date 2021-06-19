
namespace listView_Test
{
    partial class Chart_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnScale = new System.Windows.Forms.Button();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cBCurrent = new System.Windows.Forms.CheckBox();
            this.cBTemperature = new System.Windows.Forms.CheckBox();
            this.cBVoltage = new System.Windows.Forms.CheckBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.cbWay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecuteMonitoring = new System.Windows.Forms.Button();
            this.cbWhat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPheri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.reportPrinter1 = new MindFusion.Reporting.WinForms.ReportPrinter(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(12, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 442);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1068, 442);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(12, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1068, 205);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnScale);
            this.groupBox1.Controls.Add(this.dateTimePickerDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePickerTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cBCurrent);
            this.groupBox1.Controls.Add(this.cBTemperature);
            this.groupBox1.Controls.Add(this.cBVoltage);
            this.groupBox1.Controls.Add(this.dateTimePickerFrom);
            this.groupBox1.Controls.Add(this.cbWay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExecuteMonitoring);
            this.groupBox1.Controls.Add(this.cbWhat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbPheri);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 195);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monitor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Selec Date Monitor";
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(373, 145);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(75, 23);
            this.btnScale.TabIndex = 8;
            this.btnScale.Text = "Auto Scale ";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(373, 15);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDate.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "To Time";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTo.Location = new System.Drawing.Point(373, 78);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.ShowUpDown = true;
            this.dateTimePickerTo.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerTo.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "From time";
            // 
            // cBCurrent
            // 
            this.cBCurrent.AutoSize = true;
            this.cBCurrent.Location = new System.Drawing.Point(129, 151);
            this.cBCurrent.Name = "cBCurrent";
            this.cBCurrent.Size = new System.Drawing.Size(98, 17);
            this.cBCurrent.TabIndex = 14;
            this.cBCurrent.Text = "Monitor Current";
            this.cBCurrent.UseVisualStyleBackColor = true;
            // 
            // cBTemperature
            // 
            this.cBTemperature.AutoSize = true;
            this.cBTemperature.Location = new System.Drawing.Point(129, 128);
            this.cBTemperature.Name = "cBTemperature";
            this.cBTemperature.Size = new System.Drawing.Size(124, 17);
            this.cBTemperature.TabIndex = 13;
            this.cBTemperature.Text = "Monitor Temperature";
            this.cBTemperature.UseVisualStyleBackColor = true;
            // 
            // cBVoltage
            // 
            this.cBVoltage.AutoSize = true;
            this.cBVoltage.Location = new System.Drawing.Point(129, 105);
            this.cBVoltage.Name = "cBVoltage";
            this.cBVoltage.Size = new System.Drawing.Size(100, 17);
            this.cBVoltage.TabIndex = 12;
            this.cBVoltage.Text = "Monitor Voltage";
            this.cBVoltage.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(373, 47);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.ShowUpDown = true;
            this.dateTimePickerFrom.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerFrom.TabIndex = 8;
            // 
            // cbWay
            // 
            this.cbWay.FormattingEnabled = true;
            this.cbWay.Location = new System.Drawing.Point(129, 14);
            this.cbWay.Name = "cbWay";
            this.cbWay.Size = new System.Drawing.Size(121, 21);
            this.cbWay.TabIndex = 0;
            this.cbWay.SelectedIndexChanged += new System.EventHandler(this.cbWay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Way Monitoring";
            // 
            // btnExecuteMonitoring
            // 
            this.btnExecuteMonitoring.Location = new System.Drawing.Point(272, 145);
            this.btnExecuteMonitoring.Name = "btnExecuteMonitoring";
            this.btnExecuteMonitoring.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteMonitoring.TabIndex = 7;
            this.btnExecuteMonitoring.Text = "Monitor";
            this.btnExecuteMonitoring.UseVisualStyleBackColor = true;
            this.btnExecuteMonitoring.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbWhat
            // 
            this.cbWhat.FormattingEnabled = true;
            this.cbWhat.Location = new System.Drawing.Point(129, 46);
            this.cbWhat.Name = "cbWhat";
            this.cbWhat.Size = new System.Drawing.Size(121, 21);
            this.cbWhat.TabIndex = 1;
            this.cbWhat.SelectedIndexChanged += new System.EventHandler(this.cbWhat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pheripheral Information";
            // 
            // cbPheri
            // 
            this.cbPheri.FormattingEnabled = true;
            this.cbPheri.Location = new System.Drawing.Point(129, 78);
            this.cbPheri.Name = "cbPheri";
            this.cbPheri.Size = new System.Drawing.Size(121, 21);
            this.cbPheri.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "What Monitoring";
            // 
            // reportPrinter1
            // 
            this.reportPrinter1.Report = null;
            // 
            // Chart_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 667);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Chart_Form";
            this.Text = "Chart_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chart_Form_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPheri;
        private System.Windows.Forms.ComboBox cbWhat;
        private System.Windows.Forms.ComboBox cbWay;
        private System.Windows.Forms.Button btnExecuteMonitoring;
        private System.Windows.Forms.Button btnScale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.CheckBox cBCurrent;
        private System.Windows.Forms.CheckBox cBTemperature;
        private System.Windows.Forms.CheckBox cBVoltage;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private MindFusion.Reporting.WinForms.ReportPrinter reportPrinter1;
    }
}