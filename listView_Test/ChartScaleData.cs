using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace listView_Test
{
    class ChartScaleData
    {
        public Chart chart;
        public int chartIndex;
        public double xBaseMin, xBaseMax, xBaseInt, xBaseMinorInt;
        public double yBaseMin, yBaseMax, yBaseInt, yBaseMinorInt;
        public bool isZoomed = false;
        public bool scalesAreValid = false;  //only true after the chart has been drawn once;

        public ChartScaleData(Chart chart)
        {
            this.chart = chart;
        }
        //store AXIS Y
        public void UpdateAxisBaseDataX()
        {
            xBaseMinorInt = chart.ChartAreas[0].AxisX.MinorTickMark.Interval;
            xBaseInt = chart.ChartAreas[0].AxisX.Interval;
            xBaseMax = chart.ChartAreas[0].AxisX.Maximum;
            xBaseMin = chart.ChartAreas[0].AxisX.Minimum;
        }
        // store AXIS X
        public void UpdateAxisBaseDataY()
        {
            yBaseMinorInt = chart.ChartAreas[0].AxisY.MinorTickMark.Interval;
            yBaseInt = chart.ChartAreas[0].AxisY.Interval;
            yBaseMax = chart.ChartAreas[0].AxisY.Maximum;
            yBaseMin = chart.ChartAreas[0].AxisY.Minimum;
        }

        public void UpdateAxisBaseData()
        {
            UpdateAxisBaseDataX();
            UpdateAxisBaseDataY();
        }

        public void ResetAxisScaleX()
        {
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = xBaseMinorInt;
            chart.ChartAreas[0].AxisX.Interval = xBaseInt;
            chart.ChartAreas[0].AxisX.Maximum = xBaseMax;
            chart.ChartAreas[0].AxisX.Minimum = xBaseMin;
        }

        public void ResetAxisScaleY()
        {
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = yBaseMinorInt;
            chart.ChartAreas[0].AxisY.Interval = yBaseInt;
            chart.ChartAreas[0].AxisY.Maximum = yBaseMax;
            chart.ChartAreas[0].AxisY.Minimum = yBaseMin;
        }

        public void ResetAxisScale()
        {
            ResetAxisScaleX();
            ResetAxisScaleY();
        }

        public RectangleF chartAreaRectangleF
        {
            get
            {
                Rectangle cr = chart.ClientRectangle;
                RectangleF rfp = chart.ChartAreas[0].Position.ToRectangleF();
                //rfp is the chart area rectangle as percentages of the entire chart ClientRectangle
                float chAreaX = rfp.Left * cr.Width / 100f;
                float chAreaY = rfp.Top * cr.Height / 100f;
                float chAreaW = rfp.Width * cr.Width / 100f;
                float chAreaH = rfp.Height * cr.Height / 100f;
                return new RectangleF(chAreaX, chAreaY, chAreaW, chAreaH);
            }
        }

        public Rectangle chartAreaRectangle { get { return Rectangle.Round(chartAreaRectangleF); } }

        public RectangleF innerPlotRectangleF
        {
            get
            {
                RectangleF rfi = chart.ChartAreas[0].InnerPlotPosition.ToRectangleF();
                //rfi is the inner plot area rectangle as percentages of the chart area rectangle 
                RectangleF chArea = chartAreaRectangleF;
                float ipX = chArea.X + rfi.Left * chArea.Width / 100f;
                float ipY = chArea.Y + rfi.Top * chArea.Height / 100f;
                float ipW = rfi.Width * chArea.Width / 100f;
                float ipH = rfi.Height * chArea.Height / 100f;
                return new RectangleF(ipX, ipY, ipW, ipH);
            }
        }

        public Rectangle innerPlotRectangle { get { return Rectangle.Round(innerPlotRectangleF); } }
    }
}
