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
    public partial class SuaKhachHang : Form
    {
        private string maKH_glob;
        public SuaKhachHang(string maKH)
        {
            this.maKH_glob = maKH;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string glob_uid = LoginForm.uid_global;
            //PopupForm popup = new PopupForm();
            string name = textBox1.Text;
            string tieu_chi = textBox3.Text;
            string sdt = textBox2.Text;
          
            string dia_chi = textBox4.Text;

            MessageBox.Show(maKH_glob);
            try
            {
                if (name != null  &&  sdt != null && tieu_chi != null && dia_chi != null)
                {
                    ConnectDB ketnoi = new ConnectDB();
                    SqlConnection databaseConnection = ketnoi.ketnoiDB();
                    string Query = "update qlycuahang.khachhang set ten='" + name + "',diaChi='" + dia_chi + "',sDT='" + sdt + "',tieuChi='" + tieu_chi +  "' where maKH='" + maKH_glob + "';";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
