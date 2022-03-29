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
    public partial class SuaNhanVien : Form
    {
        private string maNV_glob;

        public SuaNhanVien(string maNV)
        {
            this.maNV_glob = maNV;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string glob_uid = LoginForm.uid_global;
            //PopupForm popup = new PopupForm();
            string name = textBox1.Text;
            string gtinh = comboBox1.Text;
            string sdt = textBox2.Text;
            int luong = Convert.ToInt32(textBox3.Text);
            string dia_chi = textBox4.Text;
            
                
                try
                 {
                if (name != null && dateTimePicker1.Text != null && gtinh != null && sdt != null && luong != null && dia_chi != null)
                {
                    ConnectDB ketnoi = new ConnectDB();
                    SqlConnection databaseConnection = ketnoi.ketnoiDB();
                    string Query = "update qlycuahang.nhanvien set ten='" + name + "',ngaySinh='" + dateTimePicker1.Text + "',gioiTinh='" + gtinh + "',luong='" + luong + "',sDT='" + sdt + "',diaChi='" + dia_chi + "' where maNV='" + maNV_glob + "';";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                   
                    SqlCommand MyCommand2 = new SqlCommand(Query, databaseConnection);
                    SqlDataReader MyReader2;
                    databaseConnection.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Updated");
                    
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
