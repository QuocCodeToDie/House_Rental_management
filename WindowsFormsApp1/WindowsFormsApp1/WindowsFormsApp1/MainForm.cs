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
    public partial class MainForm : Form
    {
        public static int count_selected = 0;
        public MainForm()
        {
            InitializeComponent();
            
            button3.Visible = false;



            button7.Visible = false;

            button9.Visible = false;
            button10.Visible = false;




            button15.Visible = false;
            button16.Visible = false;

            button18.Visible = false;

        }
        public string[] nvData(string uid)
        {
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            string query = "SELECT  * FROM qlycuahang.nhanvien WHERE maNV='" + uid + "'";
            SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7) };
                        return row;
                    }
                }
                else
                {
                    MessageBox.Show("uid is not existed in the DB!.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public string[] khData(string uid)
        {
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            string query = "SELECT  * FROM qlycuahang.khachhang WHERE maKH='" + uid + "'";
            SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            // Let's do it !
            try
            {
                // Open the database
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6) };
                        return row;
                    }
                }
                else
                {
                    MessageBox.Show("Uid is not existed in the DB!.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private void khachHang_Click(object sender, EventArgs e)
        {
            String glob_uid = LoginForm.uid_global;
            String glob_type = LoginForm.userType_global;
            button7.Visible = false;

            button9.Visible = false;
            button10.Visible = false;


 
            button15.Visible = false;
            button16.Visible = false;

            button18.Visible = false;
           
            if (glob_type.Equals("0"))
            {

                
                button3.Visible = true;



                dataGridViewKH.Visible = true;
                dataGridView2.Visible = true;
                textBox2.Text = "Thông tin khách hàng";
                textBox2.Visible = true;
                textBox3.Text = "Nhà đang thuê";
                textBox3.Visible = true;
                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();

                String query = "SELECT  * FROM qlycuahang.khachhang" + " WHERE maKH='" + glob_uid + "'";
                string macN = "";
                string[] temp = khData(glob_uid);
                macN = temp[4];

                String query2 = "SELECT  * FROM qlycuahang.nha" + " WHERE macN='" + macN + "'";
                databaseConnection.Open();
                SqlDataAdapter MyDA = new SqlDataAdapter();
                MyDA.SelectCommand = new SqlCommand(query, databaseConnection);
                DataTable table = new DataTable();
                MyDA.Fill(table);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                dataGridViewKH.DataSource = bSource;

                SqlDataAdapter MyDA2 = new SqlDataAdapter();
                MyDA2.SelectCommand = new SqlCommand(query2, databaseConnection);
                DataTable table2 = new DataTable();
                MyDA2.Fill(table2);
                BindingSource bSource2 = new BindingSource();
                bSource2.DataSource = table2;
                dataGridView2.DataSource = bSource2;
                databaseConnection.Close();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập.");
            }

        }

        private void nha_Click(object sender, EventArgs e)
        {
            //String glob_uid = LoginForm.uid_global;
            //String glob_type = LoginForm.userType_global;
            String query = "SELECT  * FROM qlycuahang.nha";
            dataGridViewKH.Visible = true;
            dataGridView2.Visible = false;
            textBox2.Text = "Thông tin nhà";
            textBox2.Visible = true;
            textBox3.Visible = false;
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            databaseConnection.Open();

            SqlDataAdapter MyDA = new SqlDataAdapter();
            MyDA.SelectCommand = new SqlCommand(query, databaseConnection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridViewKH.DataSource = bSource;
            databaseConnection.Close();
        }

        private void chiNhanh_Click(object sender, EventArgs e)
        {

            
            button3.Visible = false;





            button15.Visible = false;
            button16.Visible = false;

            button18.Visible = false;
            
            String glob_uid = LoginForm.uid_global;
            String glob_type = LoginForm.userType_global;
            if (glob_type.Equals("2"))
            {
                button7.Visible = true;

                button9.Visible = true;
                button10.Visible = true;


                dataGridViewKH.Visible = true;
                dataGridView2.Visible = true;
                
                textBox2.Text = "Thông tin nhân viên";
                textBox2.Visible = true;
                textBox3.Text = "Thông tin khách hàng mà chi nhánh đang quản lý";
                textBox3.Visible = true;
                String query = "SELECT  * FROM qlycuahang.nhanvien WHERE macN='" + glob_uid + "'";
                //string maCN = "";
                //string[] tmp = nvData(glob_uid);
                //maCN= tmp[3];
                String query2 = "SELECT  * FROM qlycuahang.khachhang WHERE macN='" + glob_uid + "'";

                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();
                databaseConnection.Open();
                SqlDataAdapter MyDA = new SqlDataAdapter();
                MyDA.SelectCommand = new SqlCommand(query, databaseConnection);
                DataTable table = new DataTable();
                MyDA.Fill(table);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                dataGridViewKH.DataSource = bSource;

                SqlDataAdapter MyDA2 = new SqlDataAdapter();
                MyDA2.SelectCommand = new SqlCommand(query2, databaseConnection);
                DataTable table2 = new DataTable();
                MyDA2.Fill(table2);
                BindingSource bSource2 = new BindingSource();
                bSource2.DataSource = table2;
                dataGridView2.DataSource = bSource2;
                databaseConnection.Close();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chuNha_Click(object sender, EventArgs e)
        {
            String glob_uid = LoginForm.uid_global;
            String glob_type = LoginForm.userType_global;

            
            button3.Visible = false;
  


            button7.Visible = false;

            button9.Visible = false;
            button10.Visible = false;


            
            if (glob_type.Equals("3"))
            {


                button15.Visible = true;
                button16.Visible = true;

                button18.Visible = true;
                dataGridViewKH.Visible = true;
                dataGridView2.Visible = true;

                textBox2.Text = "Thông tin chủ nhà";
                textBox2.Visible = true;
                textBox3.Text = "Thông tin nhà sở hữu";
                textBox3.Visible = true;
                String query = "SELECT  * FROM qlycuahang.chunha WHERE maCN='" + glob_uid + "'";
                string maCN = "";
                //string[] tmp = nvData(glob_uid);
                //maCN = tmp[3];
                maCN = glob_uid;
                
                string query3 = "SELECT maN from qlycuahang.chunha where maCN='" + glob_uid + "'";
                

                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();
                databaseConnection.Open();
                SqlDataAdapter MyDA = new SqlDataAdapter();
                MyDA.SelectCommand = new SqlCommand(query, databaseConnection);
                DataTable table = new DataTable();
                MyDA.Fill(table);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;
                dataGridViewKH.DataSource = bSource;



                SqlCommand commandDatabase = new SqlCommand(query3, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                string maN="";
                SqlDataReader reader;
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        maN = reader.GetString(0);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không tồn tại trong hệ thống.");
                }
                reader.Close();




                String query2 = "SELECT  * FROM qlycuahang.nha WHERE maN='" + maN + "'";
                SqlDataAdapter MyDA3 = new SqlDataAdapter();
                MyDA3.SelectCommand = new SqlCommand(query2, databaseConnection);
                DataTable table2 = new DataTable();
                MyDA3.Fill(table2);
                BindingSource bSource2 = new BindingSource();
                bSource2.DataSource = table2;
                dataGridView2.DataSource = bSource2;



                databaseConnection.Close();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
            }
        }

        private void demoLoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            DemoLoi demo1 = new DemoLoi();
            demo1.Show();
        }




        private void button18_Click(object sender, EventArgs e)
        {
            
            
        }



        private void button16_Click(object sender, EventArgs e)
        {
            ThemNha popup = new ThemNha();
            popup.ShowDialog();
            popup.Dispose();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string maN = (string)dataGridViewKH.CurrentCell.Value;
            if (maN != null)
            {
                SuaNha popup = new SuaNha(maN);
                popup.ShowDialog();
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("Chọn mã nhà mà bạn muốn sửa, bằng cách click vào mã nhà đó.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ThemKhachHang popup = new ThemKhachHang();
            popup.ShowDialog();
            popup.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string maNV = (string)dataGridViewKH.CurrentCell.Value;
            if (maNV != null)
            {
                SuaNhanVien suanv = new SuaNhanVien(maNV);
                suanv.ShowDialog();
                suanv.Dispose();
            }
            else
            {
                MessageBox.Show("Chọn mã nhân viên mà bạn muốn sửa, bằng cách click vào mã nhân viên đó.");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            PopupForm popup = new PopupForm();
            popup.ShowDialog();
            popup.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string maKH = (string)dataGridViewKH.CurrentCell.Value;
            if (maKH != null)
            {
                SuaKhachHang popup = new SuaKhachHang(maKH);
                popup.ShowDialog();
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("Chọn mã khách hàng mà bạn muốn sửa, bằng cách click vào mã khách hàng đó.");
            }

        }


        private void refresh_button_Click(object sender, EventArgs e)
        {
            this.Refresh();

        }

        private void dataGridViewKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridViewKH.SelectedRows.Count > 0)
            //{
            //count_selected++;
            
            
            
           

        }
    }

}
