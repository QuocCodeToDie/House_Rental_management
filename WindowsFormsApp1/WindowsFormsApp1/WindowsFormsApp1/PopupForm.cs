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
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Text);
            string glob_uid = LoginForm.uid_global;
            //PopupForm popup = new PopupForm();
            string name = textBox1.Text;
            string gtinh = comboBox1.Text;
            string sdt = textBox2.Text;
            int luong = Convert.ToInt32(textBox3.Text);
            string dia_chi = textBox4.Text;
            if(name!= null && dateTimePicker1.Text!=null&&gtinh!= null && sdt != null && luong != null && dia_chi != null)
            {
                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();
                //databaseConnection.Open();
                string query_getID = "SELECT max(maNV) as MAXID FROM qlycuahang.nhanvien;";
                //string query_getID_res = "SELECT MAXID FROM qlycuahang.nhanvien;";
                
                SqlCommand commandDatabase = new SqlCommand(query_getID, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;
                string ID_NV_Curr;
                string id_num="";
                try
                {
                    // Open the database
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ID_NV_Curr=reader.GetString(0);
                            
                            for(int i = 2; i < ID_NV_Curr.Length; i++)
                            {
                                id_num += ID_NV_Curr[i];
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
                    string id_result = "NV" + tmp;
                           
                    string query = "insert into qlycuahang.nhanvien(maNV, ten, ngaySinh, macN, gioiTinh, sDT, luong, diaChi) values('" + id_result + "','" + name + "','" + dateTimePicker1.Text + "','" + glob_uid + "','" + gtinh + "','" + sdt + "','" + luong + "','" + dia_chi + "');";
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

        
    }
}
