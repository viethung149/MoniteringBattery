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
                command.Parameters.Add("@error_voltage", OleDbType.WChar).Value = battery_infor.warning_voltage.ToString();
                command.Parameters.Add("@error_temperature", OleDbType.WChar).Value = battery_infor.warning_temperature.ToString();
                command.Parameters.Add("@Time", OleDbType.WChar).Value = DateTime.Now.ToString("yyyy:MM:dd hh:mm:ss");
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
            command.CommandText = "insert into " + TableName + " values(@NamePackage,@Capacity,@Temperature,@Balance,@LoadCharge,@ConnectDisconnect,@Time)";
            command.Parameters.Add("@NamePackage", OleDbType.WChar).Value = namepackage;
            command.Parameters.Add("@Capacity", OleDbType.Double).Value = package_infor.capacity;
            command.Parameters.Add("@Temperature", OleDbType.Double).Value = package_infor.temperater;
            command.Parameters.Add("@Balance", OleDbType.WChar).Value = package_infor.status_balance.ToString();
            command.Parameters.Add("@LoadCharge", OleDbType.WChar).Value = package_infor.status_active.ToString();
            command.Parameters.Add("@ConnectDisconnect", OleDbType.WChar).Value = package_infor.status_connect.ToString();
            command.Parameters.Add("@Time", OleDbType.WChar).Value = DateTime.Now.ToString("yyyy:MM:dd hh:mm:ss");
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("insert package infor to database success");
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
            command.Parameters.Add("@Time", OleDbType.WChar).Value = DateTime.Now.ToString("yyyy:MM:dd hh:mm:ss");
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
    }
}
