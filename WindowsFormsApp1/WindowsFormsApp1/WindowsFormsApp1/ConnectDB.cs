using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ConnectDB
    {
        internal SqlConnection ketnoiDB()
        {
            //String connection_String = "server=localhost;username=root;password=thanh35062496;database=qlycuahang";
            // string connection_String = "Data Source=DESKTOP-6ILC4V9\\SQLEXPRESS;Initial Catalog=qlycuahang;Integrated Security=True";
            //String query = "SELECT  * FROM" +"`"+ dbname + "`" + "WHERE user_name='" + user_name_in + "'";
            //
            // Data Source=DESKTOP-6ILC4V9\SQLEXPRESS;Initial Catalog=qlycuahang;Integrated Security=True;
            //
            //string source = @"Data Source=DESKTOP-6ILC4V9\SQLEXPRESS";
            string connection_String = @"Data Source=DESKTOP-6ILC4V9\SQLEXPRESS;Initial Catalog=qlycuahang;Integrated Security=True";
            SqlConnection databaseConnection = new SqlConnection(connection_String);
            return databaseConnection;
        }




    }
}
