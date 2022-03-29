using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class LostUpdate
    {
        internal void LostUpdate_1(BindingSource bSource1, BindingSource bSource2)
        {
            string script_lostdate_1_T1 = File.ReadAllText(@"G:\Lost-Update\Lost Update\Lost Update 1\Tran 1.sql");
            string script_lostdate_1_T2 = File.ReadAllText(@"G:\Lost-Update\Lost Update\Lost Update 1\Tran 2.sql");
            Console.WriteLine(script_lostdate_1_T1);
            string qr_1 = @"update qlycuahang.Nha set soLuongPhong = soLuongPhong-1 where maN = 'N1'";
            string qr_2 = @"update qlycuahang.Nha set soLuongPhong = soLuongPhong-2 where maN = 'N1'";
            
            
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            /*
            SqlTransaction transaction;
            databaseConnection.Open();
            transaction = databaseConnection.BeginTransaction();
            */
            //T1

            SqlDataAdapter MyDA = new SqlDataAdapter();
            MyDA.SelectCommand = new SqlCommand(script_lostdate_1_T1, databaseConnection);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            bSource1 = new BindingSource();
            bSource1.DataSource = table;
            //T2
            SqlDataAdapter MyDA2 = new SqlDataAdapter();
            MyDA2.SelectCommand = new SqlCommand(script_lostdate_1_T2, databaseConnection);
            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);
            bSource2 = new BindingSource();
            bSource2.DataSource = table;
            
            

        }

    }
    
}
