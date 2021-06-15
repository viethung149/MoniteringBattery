using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph
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
        // get infor battery 
        // table name : name of table in the database
        // ID_ battery: infor cells
        // 
        public int Get_Infor_Battery(String table_name,
                                       int ID_battery,
                                       ref float[] buffer_voltage,
                                       ref float[] buffer_temperature,
                                       ref DateTime[] buffer_datetime,
                                       DateTime inDate)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "SELECT IDbattery, Voltage, Temperature, Time FROM " + "Battery" + " WHERE Battery.IDbattery = @ID";
            command.Parameters.Add("@ID", OleDbType.Integer).Value = ID_battery;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            {
                DateTime db_dateTime = DateTime.Parse(row["Time"].ToString());
                if (DateTime.Compare(db_dateTime.Date,inDate.Date) == 0) {
                buffer_voltage[index_row] = float.Parse(row["Voltage"].ToString());
                buffer_temperature[index_row] = float.Parse(row["Temperature"].ToString());
                buffer_datetime[index_row] = db_dateTime;
                Console.WriteLine("Voltage battery {0} is {1} Temperature is {2} at Time {3}",row["IDbattery"],
                buffer_voltage[index_row].ToString(), buffer_temperature[index_row].ToString(), buffer_datetime[index_row].ToString("yyyy:MM:dd HH:mm:ss"));
                index_row++;
                }
                //Console.WriteLine("Data after convert is {0}, {1}, {2}", Voltage, Temperature, Time);
            }
            return index_row;
        }
        public int Get_Infor_Package(  string namePackage,
                                       ref float[] buffer_voltage,
                                       ref float[] buffer_temperature,
                                       ref float[] buffer_current,
                                       ref DateTime[] buffer_datetime,
                                       DateTime inDate)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.Connection = Conn;
            command.CommandText = "SELECT Capacity, Temperature,Ampe, Time FROM " + "Package WHERE  Package.Time > @inDate AND  Package.Time<@nextDate AND Package.NamePackage = @namePackage ORDER BY Time ASC";
            command.Parameters.Add("@inDate", OleDbType.Date).Value = inDate.Date;
            command.Parameters.Add("@nextDate", OleDbType.Date).Value = inDate.Date.AddDays(1);
            command.Parameters.Add("@namePackage", OleDbType.VarChar).Value = namePackage;
            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(table);
            int index_row = 0;
            foreach (DataRow row in table.Rows)
            { 
                    //buffer_voltage[index_row] = float.Parse(row["Capacity"].ToString());
                    //buffer_temperature[index_row] = float.Parse(row["Temperature"].ToString());
                    //buffer_current[index_row] = float.Parse(row["Current"].ToString());
                    //buffer_datetime[index_row] = DateTime.Parse(row["Time"].ToString());
                    //Console.WriteLine("Voltage battery {0} is {1} Temperature is {2} at Time {3}", row["IDbattery"],
                    //buffer_voltage[index_row].ToString(), buffer_temperature[index_row].ToString(), buffer_datetime[index_row].ToString("yyyy:MM:dd HH:mm:ss"));
                    index_row++;
                
                //Console.WriteLine("Data after convert is {0}, {1}, {2}", Voltage, Temperature, Time);
            }
            return index_row;
        }
    }
}
