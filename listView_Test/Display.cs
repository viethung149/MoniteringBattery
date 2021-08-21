using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections;
using System.Data.OleDb;
namespace listView_Test
{
    public class Display
    {

        public static void Add_row_data_battery(int row, Battery battery_data,Form1 f)
        {
            // row is less than 8 and greater than 0
            if (row <= Constant.NUMBER_BATTERY && row >= 0)
            {
                f.CustomListView_Battery.Items[row-1].UseItemStyleForSubItems = false;
                string[] arr = new string[Constant.TAB_BATTERY_COLUMN];
                arr[0] = battery_data.voltage.ToString();
                arr[1] = battery_data.temperature.ToString();
                //arr[2] = battery_data.status_balance == true ? "Blancing" : "Not Blancing";
                arr[2] = battery_data.warning_voltage == true ? "Emergency" : "Normal";
                arr[3] = battery_data.warning_temperature == true ? "Emergency" : "Normal";
                while (f.CustomListView_Battery.Items[row - 1].SubItems.Count != 1)
                {
                    f.CustomListView_Battery.Items[row - 1].SubItems.RemoveAt(1);
                }
                for (int i =0;i<Constant.TAB_BATTERY_COLUMN;i++)
                {
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem() { Text = arr[i] };
                    f.CustomListView_Battery.Items[row - 1].SubItems.Add(subItem);
                    if (arr[i] =="Emergency")
                    {
                        f.CustomListView_Battery.Items[row-1].SubItems[i+1].BackColor = Color.Red;
                      
                    }
                    else
                    {
                        f.CustomListView_Battery.Items[row - 1].SubItems[i + 1].BackColor = Color.White;
                       
                    }
                }
           
            }

        }
        public static void Add_row_data_package(int row, Package package, Form1 f)
        {
            if (row <= Constant.NUMBER_PACKET && row >= 0)
            {
                f.CustomListView_Package.Items[row - 1].UseItemStyleForSubItems = false;
                string[] arr = new string[6];
                arr[0] = package.capacity.ToString();
                arr[1] = package.temperater.ToString();
                arr[2] = package.current.ToString();
                //arr[3] = package.status_balance == true ? "Blancing" : "Not Blancing";
                if (package.status_connect == 0) { arr[3] = "Disconnect"; }
                else if (package.status_connect == 1) { arr[3] = "Connect"; }
                else if (package.status_connect == 2) { arr[3] = "Charge"; }
                else if (package.status_connect == 3) { arr[3] = "Discharge"; }
                arr[4] = package.warning == true ? "Emergency" : "Normal";
                while (f.CustomListView_Package.Items[row - 1].SubItems.Count != 1)
                {
                    f.CustomListView_Package.Items[row - 1].SubItems.RemoveAt(1);
                }
                for (int i = 0; i < 6; i++)
                {
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem() { Text = arr[i] };
                    f.CustomListView_Package.Items[row - 1].SubItems.Add(subItem);
                    if (arr[i] == "Emergency")
                    {
                        f.CustomListView_Package.Items[row - 1].SubItems[i + 1].BackColor = Color.Red;
                       // f.CustomListView_Package.Items[row - 1].SubItems[0].BackColor = Color.Red;
                    }
                    else
                    {
                        f.CustomListView_Package.Items[row - 1].SubItems[i + 1].BackColor = Color.White;
                       // f.CustomListView_Package.Items[row - 1].SubItems[0].BackColor = Color.White;
                    }
                }
            }
        }
        public static void Add_row_data_pheripheral(int row, Peripheral pheri, Form1 f)
        {
            if (row <= 4 && row >= 0)
            {
                f.CustomListView_Pheripheral.Items[row - 1].UseItemStyleForSubItems = false;
                string[] arr = new string[1];
                arr[0] = pheri.status_connect == true ? "ON" : "OFF";
                while (f.CustomListView_Pheripheral.Items[row - 1].SubItems.Count != 1)
                {
                    f.CustomListView_Pheripheral.Items[row - 1].SubItems.RemoveAt(1);
                }
                foreach (var item in arr)
                {

                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem() { Text = item };
                    f.CustomListView_Pheripheral.Items[row - 1].SubItems.Add(subItem);
                    if (item == "ON")
                    {
                        f.CustomListView_Pheripheral.Items[row - 1].SubItems[1].BackColor = Color.GreenYellow;
                    }
                    else {
                        f.CustomListView_Pheripheral.Items[row - 1].SubItems[1].BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
