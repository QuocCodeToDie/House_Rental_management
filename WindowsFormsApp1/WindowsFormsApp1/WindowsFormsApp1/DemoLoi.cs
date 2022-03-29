using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DemoLoi : Form
    {
        private void DirtyRead_1_T1()
        {
            BindingSource bSource = new BindingSource();
            string query1 = "SELECT * FROM qlycuahang.nha WHERE maNVQL='NV1'";
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            databaseConnection.Open();
            SqlDataAdapter MyDA = new SqlDataAdapter();
            MyDA.SelectCommand = new SqlCommand(query1, databaseConnection);
            DataTable table = new DataTable();
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.Invoke(new Action(() => { dataGridView1.DataSource = bSource; }));
            
            databaseConnection.Close();
        }
        private void DirtyRead_2_T1()
        {
            string query1 = "SELECT * FROM qlycuahang.nha WHERE maNVQL='NV1'";
            string query2 = "update qlycuahang.nha set giaThue1T='1000000' WHERE maNVQL='NV1'";
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            databaseConnection.Open();
            SqlCommand MyCommand2 = new SqlCommand(query2, databaseConnection);
            SqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            MyReader2.Close();

            SqlDataAdapter MyDA2 = new SqlDataAdapter();
            MyDA2.SelectCommand = new SqlCommand(query1, databaseConnection);
            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;
            dataGridView2.Invoke(new Action(() => { dataGridView2.DataSource = bSource2; }));
            databaseConnection.Close();
        }
        public DemoLoi()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkBox1.Checked)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            switch (selected) {
                case "Dirty read 1":
                    richTextBox1.Text = "-	Nhân viên đang tư vấn thuê nhà cho khách hàng, nhưng chủ nhà lại thay đổi giá thuê nhưng chưa commit. Hệ thống không kịp cập nhật lại giá nhà cho nhân viên.";
                    break;
                case "Dirty read 2":
                    richTextBox1.Text = "-	Chủ nhà thay đổi tình trạng nhà nhưng chưa commit, trong lúc khách hàng đã lựa chọn được căn nhà này.";
                    break;
                case "Dirty read 3":
                    richTextBox1.Text = "-	Chủ nhà trao quyền quản lý nhà cho người thân nhưng chưa cập nhật lại thông tin cá nhân + số tiền thuê mà người thân mong muốn nhưng lại chưa commit ,… Trong lúc đó khách hàng liên lạc thuê nhà thông qua chủ nhà cũ.";
                    break;
                case "Lost update 1":
                    richTextBox1.Text = "-	Hai khách hàng cùng lúc muốn thuê một nhà, họ đã thành công hoàn thành hết thủ tục. Tuy nhiên số lượng phòng không kịp cập nhật.";
                    break;
                case "Lost update 2":
                    richTextBox1.Text = "-	Công ty A trong lúc nhầm lẫn đã phân công nhân viên B cùng lúc ở 2 chi nhánh. ";
                    break;
                case "Lost update 3":
                    richTextBox1.Text = "-	Chủ nhà muốn cập nhật thông tin về nhà thuê mới tuy nhiên lại bấm nhầm cập nhật 2 lần.";
                    break;
                case "Unrepeatable Read 1":
                    richTextBox1.Text = "-	Khách hàng đang xem thông tin của chủ nhà, trong lúc này chủ nhà thay đổi số điện thoại của mình và commit, sau khi khách hàng xem lại thì số điện thoại đã thay đổi.";
                    break;
                case "Unrepeatable Read 2":
                    richTextBox1.Text = "-	Khách hàng đăng ký xem nhà thành công, tuy nhiên chủ nhà lại xóa nhà thuê ra khỏi danh sách";
                    break;
                case "Unrepeatable Read 3":
                    richTextBox1.Text = "-	Khách hàng đăng ký xem nhà với yêu cầu khu vực ngoại ô, tuy nhiên chủ nhà lại thay đổi lại từ ngoại ô thành chợ vì nhầm lẫn.";
                    break;
                case "Phantom 1":
                    richTextBox1.Text = "-	Khách hàng yêu cầu nhà cho thuê phải có số phòng <2,  tuy nhiên sau khi hoàn tất thủ tục chủ nhà lại xây dựng thêm 1 phòng.";
                    break;
                case "Phantom 2":
                    richTextBox1.Text = "-	Khách hàng select các căn nhà với giá tiền thuê 1 tháng <1.000.000Đ(tìm thấy 4 căn), tuy nhiên, khi đã commit thì chủ nhà thứ 4 lại tăng giá lên >1.000.000đ.";
                    break;
                case "Phantom 3":
                    richTextBox1.Text = "-	Khách hàng đang xem những nhà ở khu vực thành phố Hồ Chi Minh, trong lúc đó chủ nhà vừa thêm vào danh sách thêm 1 nhà thuê.";
                    break;
            }
                

        }

        private void demoBtt_Click(object sender, EventArgs e)
        {           
            string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            bool btt_1 = this.checkBox1.Checked;
            bool btt_2 = this.checkBox2.Checked;
            if(btt_1 != true && btt_2 != true)
            {
                MessageBox.Show("Bạn chưa tích vào ô nào cả!");
            }else if (selected == null)
            {
                MessageBox.Show("Bạn chưa chọn lỗi!");
            }
            switch (selected)
            {
                case "Dirty read 1":
                    string query1 = "SELECT * FROM qlycuahang.nha WHERE maNVQL='NV1'";
                    string query2 = "update qlycuahang.nha set giaThue1T='1000000' WHERE maNVQL='NV1'";
                    textBox1.Text = query1;
                    textBox2.Text = query2;
                    DirtyRead dr1 = new DirtyRead();
                    if (btt_1)
                    {                     
                        Thread dr1_T1 = new Thread(new ThreadStart(DirtyRead_1_T1));
                        Thread dr1_T2 = new Thread(new ThreadStart(DirtyRead_2_T1));
                        dr1_T1.Start();
                        dr1_T2.Start();                                              
                    }
                    else
                    {
                        Thread dr1_T1 = new Thread(new ThreadStart(DirtyRead_1_T1));
                        Thread dr1_T2 = new Thread(new ThreadStart(DirtyRead_2_T1));
                        dr1_T1.Start();
                        Thread.Sleep(1000);
                        dr1_T2.Start();
                    }
                    
              
                    break;
                case "Dirty read 2":
                    
                    break;
                case "Dirty read 3":
                   
                    break;
                case "Lost update 1":
                    LostUpdate lu1 = new LostUpdate();
                    BindingSource bSource3 = new BindingSource();
                    BindingSource bSource4 = new BindingSource();
                    lu1.LostUpdate_1(bSource3, bSource4);
                    if (btt_1)
                    {
                        dataGridView1.DataSource = bSource3;
                        dataGridView2.DataSource = bSource4;
                       
                    }
                    else
                    {
                        
                    }
                    break;
                case "Lost update 2":
                    
                    break;
                case "Lost update 3":
                    
                    break;
                case "Unrepeatable Read 1":
                    
                    break;
                case "Unrepeatable Read 2":
                    
                    break;
                case "Unrepeatable Read 3":
                    
                    break;
                case "Phantom 1":
                    
                    break;
                case "Phantom 2":
                    
                    break;
                case "Phantom 3":
                    
                    break;
            }
        }

        
    }
}
