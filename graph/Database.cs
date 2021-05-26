using System;
using System.Collections.Generic;
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
    }
}
