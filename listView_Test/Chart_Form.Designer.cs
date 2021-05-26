
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnScale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbPheri = new System.Windows.Forms.ComboBox();
            this.cbWhat = new System.Windows.Forms.ComboBox();
            this.cbWay = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(12, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 327);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(776, 327);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnScale);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.cbPheri);
            this.panel2.Controls.Add(this.cbWhat);
            this.panel2.Controls.Add(this.cbWay);
            this.panel2.Location = new System.Drawing.Point(12, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnScale
            // 
            this.btnScale.Location = new System.Drawing.Point(21, 56);
            this.btnScale.Name = "btnScale";
            this.btnScale.Size = new System.Drawing.Size(75, 23);
            this.btnScale.TabIndex = 8;
            this.btnScale.Text = "Auto Scale ";
            this.btnScale.UseVisualStyleBackColor = true;
            this.btnScale.Click += new System.EventHandler(this.btnScale_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pheripheral Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "What Monitoring";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Way Monitoring";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(568, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // cbPheri
            // 
            this.cbPheri.FormattingEnabled = true;
            this.cbPheri.Items.AddRange(new object[] {
            "Package 1- Relay 1",
            "Package 2 - Relay 2 ",
            "Fan 1 - Relay 3",
            "Fan 2 - Relay 4"});
            this.cbPheri.Location = new System.Drawing.Point(368, 20);
            this.cbPheri.Name = "cbPheri";
            this.cbPheri.Size = new System.Drawing.Size(121, 21);
            this.cbPheri.TabIndex = 2;
            // 
            // cbWhat
            // 
            this.cbWhat.FormattingEnabled = true;
            this.cbWhat.Items.AddRange(new object[] {
            "Package 1",
            "Package 2",
            "battery 1 - Package 1",
            "battery 2 - Package 1",
            "battery 3 - Package 1",
            "battery 4 - Package 1",
            "battery 1 - Package 2",
            "battery 2 - Package 2",
            "battery 3 - Package 2",
            "battery 4 - Package 2"});
            this.cbWhat.Location = new System.Drawing.Point(178, 20);
            this.cbWhat.Name = "cbWhat";
            this.cbWhat.Size = new System.Drawing.Size(121, 21);
            this.cbWhat.TabIndex = 1;
            // 
            // cbWay
            // 
            this.cbWay.FormattingEnabled = true;
            this.cbWay.Items.AddRange(new object[] {
            "Real Time",
            "Now ",
            "Another"});
            this.cbWay.Location = new System.Drawing.Point(21, 20);
            this.cbWay.Name = "cbWay";
            this.cbWay.Size = new System.Drawing.Size(121, 21);
            this.cbWay.TabIndex = 0;
            // 
            // Chart_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Chart_Form";
            this.Text = "Chart_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chart_Form_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbPheri;
        private System.Windows.Forms.ComboBox cbWhat;
        private System.Windows.Forms.ComboBox cbWay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnScale;
    }
}