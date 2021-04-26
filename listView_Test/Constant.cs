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
        public const  int NUMBER_PHERI = 5;

        public const int TAB_BATTERY_COLUMN = 4;
    }
    public struct Battery
    {
        public float voltage;
        public float temperature;
        public bool warning;
        public bool status_balance;
    }
    public struct Package
    {
        public float capacity;
        public float temperater;
        public float current;
        public int status_active;
        public bool status_balance;
        public bool status_connect;
    }
    public struct Peripheral
    {
        public bool status_connect;
    }
}
