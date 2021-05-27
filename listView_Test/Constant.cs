using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace listView_Test
{
    static class Constant
    {

        public const  int NUMBER_BATTERY = 16;
        public const  int NUMBER_PACKET = 3;
        public const  int NUMBER_PHERI = 4;
        public const int TAB_BATTERY_COLUMN = 5;
    }
    public struct Battery
    {
        public float voltage;
        public float temperature;
        public bool warning_voltage;
        public bool warning_temperature;
        public bool status_balance;
    }
    public struct Package
    {
        public float capacity;
        public float temperater;
        public float current;
        public bool warning;
        public bool status_balance;
        public int status_connect; // 0: disconnect 1:connect 2:load 3:discharge
    }
    public struct Peripheral
    {
        public bool status_connect;
    }
}
