
namespace graph
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lineChart = new MindFusion.Charting.WinForms.LineChart();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(587, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "get Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // lineChart
            // 
            this.lineChart.AllowPan = false;
            this.lineChart.LegendElementLabelKind = MindFusion.Charting.LabelKinds.OuterLabel;
            this.lineChart.LegendSpacing = 10D;
            this.lineChart.LegendTitle = "Legend";
            this.lineChart.Location = new System.Drawing.Point(12, 79);
            this.lineChart.Margin = new System.Windows.Forms.Padding(4);
            this.lineChart.Name = "lineChart";
            this.lineChart.Padding = new System.Windows.Forms.Padding(4);
            this.lineChart.ShowLegend = true;
            this.lineChart.Size = new System.Drawing.Size(636, 324);
            this.lineChart.SubtitleFontName = null;
            this.lineChart.SubtitleFontSize = null;
            this.lineChart.SubtitleFontStyle = null;
            this.lineChart.TabIndex = 6;
            this.lineChart.Text = "lineChart1";
            this.lineChart.Theme.UniformSeriesFill = new MindFusion.Drawing.SolidBrush("#FF90EE90");
            this.lineChart.Theme.UniformSeriesStroke = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.lineChart.Theme.UniformSeriesStrokeThickness = 2D;
            this.lineChart.TitleFontName = null;
            this.lineChart.TitleFontSize = null;
            this.lineChart.TitleFontStyle = null;
            this.lineChart.DataItemClicked += new System.EventHandler<MindFusion.Charting.HitResult>(this.lineChart_DataItemClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 415);
            this.Controls.Add(this.lineChart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private MindFusion.Charting.WinForms.LineChart lineChart;
    }
}

