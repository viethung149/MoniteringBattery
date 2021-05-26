using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listView_Test
{
    static class Data_chart
    {
        public static void add_point(string NameChart, int X, int Y, Chart_Form f)
        {
            f.chart1.Series[NameChart].Points.AddXY(X, Y);
        }
    }
}
