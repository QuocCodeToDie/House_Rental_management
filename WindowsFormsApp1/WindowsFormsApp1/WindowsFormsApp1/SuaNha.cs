using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SuaNha : Form
    {
        private string maN_glob;
        public SuaNha(string maN_glob)
        {
            this.maN_glob = maN_glob;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tinhtrangnha = textBox1.Text;
            string soluongphong = textBox2.Text;
            int res, res2, res3;
            bool check = Int32.TryParse(soluongphong, out res);
            string maloainha = textBox6.Text;
            string quan = textBox7.Text;
            string duong = textBox8.Text;
            string thanhpho = textBox9.Text;
            string giathue = textBox10.Text;
            bool check2 = Int32.TryParse(giathue, out res2);
            string giaban = textBox11.Text;
            bool check3 = Int32.TryParse(giaban, out res3);
            string khuvuc = textBox5.Text;
            string dieukien = textBox12.Text;
            try
            {
                if (tinhtrangnha != null  && res != null && maloainha != null && quan != null && duong != null && thanhpho != null && res2 != null && res3 != null && dieukien != null)
                {
                    ConnectDB ketnoi = new ConnectDB();
                    SqlConnection databaseConnection = ketnoi.ketnoiDB();
                    string Query = "update qlycuahang.nha set tinhTrangNha='" + tinhtrangnha + "',soLuongPhong='" + soluongphong + "',maLN='" + maloainha + "',quan='" + quan + "',duong='"+duong+ "',thanhPho='" + thanhpho + "',khuVuc='"+khuvuc+ "',giaThue1T='"+giathue+"',giaBan='"+giaban+ "',dieuKienBan='"+dieukien+"' where maN='" + maN_glob + "';";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  

                    SqlCommand MyCommand2 = new SqlCommand(Query, databaseConnection);
                    SqlDataReader MyReader2;
                    databaseConnection.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    Visible = false;
                    while (MyReader2.Read())
                    {
                    }
                    databaseConnection.Close();//Connection closed here  
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống thông tin!");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
