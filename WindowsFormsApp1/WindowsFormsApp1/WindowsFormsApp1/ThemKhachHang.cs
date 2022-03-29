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
    public partial class ThemKhachHang : Form
    {
        public ThemKhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String glob_uid = LoginForm.uid_global;
            string name = textBox1.Text;
            string sdt = textBox2.Text;
            string tieu_chi = textBox3.Text;
            string dia_chi = textBox4.Text;
            if (name != null  && tieu_chi != null && sdt != null &&  dia_chi != null)
            {
                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();
                //databaseConnection.Open();
                string query_getID = "SELECT max(maKH) as MAXID FROM qlycuahang.khachhang;";
                //string query_getID_res = "SELECT MAXID FROM qlycuahang.nhanvien;";

                SqlCommand commandDatabase = new SqlCommand(query_getID, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                string ID_KH_Curr;
                string id_num = "";
                try
                {
                    // Open the database
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ID_KH_Curr = reader.GetString(0);

                            for (int i = 2; i < ID_KH_Curr.Length; i++)
                            {
                                id_num += ID_KH_Curr[i];
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không tồn tại trong hệ thống.");
                    }
                    reader.Close();
                    int tmp = Convert.ToInt32(id_num);
                    tmp = tmp + 1;
                    string id_result = "KH" + tmp;
                    string query = "insert into qlycuahang.khachhang(ten, diaChi, sDT, tieuChi, macN, loaiNha, maKH) values('" + name + "','" + dia_chi + "','" + sdt + "','"  + tieu_chi + "','"+ glob_uid + "','LN1','" + id_result +  "');";
                    SqlCommand MyCommand2 = new SqlCommand(query, databaseConnection);
                    SqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Thêm thành công");
                    databaseConnection.Close();
                    Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Loi");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Visible = false;
        }
    }
}
