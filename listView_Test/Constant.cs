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
        // maker size
        public const int MAKER_SIZE = 8;
        // constant for draw chart
        public const int MAX_Y_PHERI = 10;
        public const int MAX_CURREN = 3;
        public const int MAX_VOLTAGE = 20;
        public const int MAX_TEMPERATURE = 100;
        // index package
        public const int INDEX_PACKAGE1 = 0;
        public const int INDEX_PACKAGE2 = 1;
        public const int INDEX_ALL = 2;
        // index cell
        public const int CELL1_PACKAGE1 = 0;
        public const int CELL2_PACKAGE1 = 1;
        public const int CELL3_PACKAGE1 = 2;
        public const int CELL4_PACKAGE1 = 3;
        public const int CELL1_PACKAGE2 = 4;
        public const int CELL2_PACKAGE2 = 5;
        public const int CELL3_PACKAGE2 = 6;
        public const int CELL4_PACKAGE2 = 7;
        public const  int NUMBER_BATTERY = 16;
        public const  int NUMBER_PACKET = 2;
        public const  int NUMBER_PHERI = 16;
        public const int TAB_BATTERY_COLUMN = 5;
        public const int SIZE_BUFFER_TX = 6;
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
        public string name_peripheral;
    }
}
