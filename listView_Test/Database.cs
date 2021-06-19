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
using System.Windows.Forms;
namespace listView_Test
{

    public class Database
    {
        public string StrConn;
        public OleDbConnection Conn;
        public void connect_access()
        {
            try
            {
                
                Conn.Open();
                Console.WriteLine("connect database success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool insert_battery(string TableName, Battery battery_infor,int ID_battery) {
            if (ID_battery <= 8) { 
                OleDbCommand command = new OleDbCommand();
                command.CommandType = CommandType.Text;
                command.Connection = Conn;
                command.CommandText = "insert into " + TableName + " values(@IDbattery,@Voltage,@Temperature,@Balance,@error_voltage,@error_temperature,@Time)";
                command.Parameters.Add("@IDbattery", OleDbType.Integer).Value = ID_battery;
                command.Parameters.Add("@Voltage", OleDbType.Double).Value = battery_infor.voltage;
                command.Parameters.Add("@Temperature", OleDbType.Double).Value = battery_infor.temperature;
                command.Parameters.Add("@Balance", OleDbType.Boolean).Value = battery_infor.status_balance;
                command.Parameters.Add("@error_voltage", OleDbType.Boolean).Value = battery_infor.warning_voltage;
                command.Parameters.Add("@error_temperature", OleDbType.Boolean).Value = battery_infor.warning_temperature;
                command.Parameters.Add("@Time", OleDbType.Date).Value = DateTime.Now;
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("insert battery infor to database success");
                    return true;
                }
                else
                {
                    Console.WriteLine("insert battery infor fail");
                    return false;
                }
            }
            return true;  
        }
        public bool insert_package(string TableName, Package package_infor, string namepackage)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "insert into " + TableName + " values(@NamePackage,@Capacity,@Temperature,@Current,@Balance,@Status,@Warning,@Time)";
            command.Parameters.Add("@NamePackage", OleDbType.WChar).Value = namepackage;
            command.Parameters.Add("@Capacity", OleDbType.Double).Value = package_infor.capacity;
            command.Parameters.Add("@Temperature", OleDbType.Double).Value = package_infor.temperater;
            command.Parameters.Add("@Current", OleDbType.Double).Value = package_infor.current;
            command.Parameters.Add("@Balance", OleDbType.Boolean).Value = package_infor.status_balance;
            command.Parameters.Add("@Status", OleDbType.WChar).Value = package_infor.status_connect.ToString();
            command.Parameters.Add("@Warning", OleDbType.Boolean).Value = package_infor.warning;
            command.Parameters.Add("@Time", OleDbType.Date).Value = DateTime.Now;
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("insert package package to database success");
                return true;
            }
            else
            {
                Console.WriteLine("insert package infor fail");
                return false;
            }
        }

        public bool insert_peri(string TableName, Peripheral Peripheral_infor, string namePeri)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "insert into " + TableName + " values(@Namepheri,@Status,@Time)";
            command.Parameters.Add("@Namepheri", OleDbType.WChar).Value = namePeri;
            command.Parameters.Add("@Status", OleDbType.Boolean).Value = Peripheral_infor.status_connect;
            command.Parameters.Add("@Time", OleDbType.Date).Value = DateTime.Now;
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("insert pheripheral infor to database success");
                return true;
            }
            else
            {
                Console.WriteLine("insert pheripheral infor fail");
                return false;
            }
        }
        public int Get_Infor_Battery( int ID_battery,
                                      ref float[] buffer_voltage,
                                      ref float[] buffer_temperature,
                                      ref DateTime[] buffer_datetime,
                                      DateTime from,
                                      DateTime to)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "SELECT Voltage, Temperature, Time FROM " + "Battery" +
                                  " WHERE Battery.IDbattery = @ID AND Battery.Time > @inDate AND  Battery.Time<@nextDate ORDER BY Time ASC";
            command.Parameters.Add("@ID", OleDbType.Integer).Value = ID_battery;
            command.Parameters.Add ("@inDate", OleDbType.Date).Value = from;
            command.Parameters.Add("@nextDate", OleDbType.Date).Value = to;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            {
                buffer_voltage[index_row] = float.Parse(row["Voltage"].ToString());
                buffer_temperature[index_row] = float.Parse(row["Temperature"].ToString());
                buffer_datetime[index_row] = DateTime.Parse(row["Time"].ToString());
                Console.WriteLine("Voltage battery is {0} Temperature is {1} at Time {2}",
                buffer_voltage[index_row].ToString(), buffer_temperature[index_row].ToString(), buffer_datetime[index_row].ToString("yyyy:MM:dd HH:mm:ss"));
                index_row++;
            }
            return index_row;
        }
        public int Get_Infor_Package(string namePackage,
                                       ref float[] buffer_voltage,
                                       ref float[] buffer_temperature,
                                       ref float[] buffer_current,
                                       ref DateTime[] buffer_datetime,
                                       DateTime from,
                                       DateTime to)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "SELECT Capacity, Temperature, Ampe, Time FROM " + 
                                  "Package WHERE  Package.Time > @inDate AND  Package.Time<@nextDate AND Package.NamePackage = @namePackage ORDER BY Time ASC";
            command.Parameters.Add("@inDate", OleDbType.Date).Value = from ;
            command.Parameters.Add("@nextDate", OleDbType.Date).Value =to;
            command.Parameters.Add("@namePackage", OleDbType.VarChar).Value = namePackage;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            {
                buffer_voltage[index_row] = float.Parse(row["Capacity"].ToString());
                buffer_temperature[index_row] = float.Parse(row["Temperature"].ToString());
                buffer_current[index_row] = float.Parse(row["Ampe"].ToString());
                buffer_datetime[index_row] = DateTime.Parse(row["Time"].ToString());
                Console.WriteLine("Data is V= {0}, T= {1}, C ={2}", buffer_voltage[index_row], buffer_temperature[index_row], buffer_current[index_row]);
                index_row++;
            }
            return index_row;
        }
        public int Get_Infor_Pheri(  string namePheri,
                                       ref int[] buffer_relay,
                                       ref DateTime[] buffer_datetime,
                                       DateTime from,
                                       DateTime to)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "SELECT Status, Time FROM " +
                                  "Peripheral WHERE  Peripheral.Time > @inDate AND  Peripheral.Time<@nextDate AND Peripheral.NamePeripheral = @namePheri ORDER BY Time ASC";
            command.Parameters.Add("@inDate", OleDbType.Date).Value = from;
            command.Parameters.Add("@nextDate", OleDbType.Date).Value = to;
            command.Parameters.Add("@namePheri", OleDbType.VarChar).Value = namePheri;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            {
                buffer_relay[index_row] = bool.Parse(row["Status"].ToString())?10:0;
                buffer_datetime[index_row] = DateTime.Parse(row["Time"].ToString());
                index_row++;
            }
            return index_row;
        }
    }
}
