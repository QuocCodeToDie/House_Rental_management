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
    public partial class ThemNha : Form
    {
        public ThemNha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string tinhtrangnha = textBox1.Text;
            string maNVQL = textBox2.Text;
            string soluongphong =textBox3.Text;
            int res,res2,res3;
            bool check = Int32.TryParse(soluongphong, out res);
           
           

            string machinhanh = textBox4.Text;
            string maloainha = textBox6.Text;
            string quan = textBox7.Text +" ";
            string duong = textBox8.Text;
            string thanhpho = textBox9.Text;

            string giathue = textBox10.Text;
            bool check2 = Int32.TryParse(giathue, out res2);

            string giaban =textBox11.Text;
            bool check3 = Int32.TryParse(giaban, out res3);

         

            string khuvuc = textBox5.Text;
            string dieukien = textBox12.Text;
            
            if (tinhtrangnha != null && maNVQL != null && res != null && machinhanh != null && maloainha != null && quan != null && duong != null&& thanhpho != null && res2 != null && res3 != null && dieukien != null)
            {
                ConnectDB ketnoi = new ConnectDB();
                SqlConnection databaseConnection = ketnoi.ketnoiDB();
                //databaseConnection.Open();
                string query_getID = "SELECT max(maN) as MAXID FROM qlycuahang.nha;";
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
                            
                            for (int i = 1; i < ID_KH_Curr.Length; i++)
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
                    string id_result = "N" + tmp;
                    

                    string curr_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                   
                    string curr_date_p_1 = DateTime.Now.Date.AddYears(1).ToString("yyyy-MM-dd");
                    

                    string query = "insert into qlycuahang.nha(maN, tinhTrangNha, maNVQL, soLuongPhong, macN, ngayDB, ngayHH, luotXem, maLN, quan, duong, thanhPho, khuVuc, giaThue1T, giaBan, dieuKienBan) values('" + id_result + "','" + tinhtrangnha + "','" + maNVQL + "','" + res + "','" + machinhanh + "','"+ curr_date + "','"+ curr_date_p_1+ "',0,'" + maloainha + "','"+quan+"','"+duong+"','"+thanhpho+"','"+ khuvuc + "','"+res2+"','"+res3+"','"+dieukien+"');";
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
