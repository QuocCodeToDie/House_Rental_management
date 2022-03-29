using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            String name = usernameBox.Text;
            String pass = passwordBox.Text;
            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();


            String query2 = "INSERT INTO qlycuahang.user (username, password, userType) VALUES ( '" + name + "', '" + pass + "', '" +0+ "');";

            SqlCommand commandDatabase = new SqlCommand(query2, databaseConnection);
            try
            {
                databaseConnection.Open();
                int status = commandDatabase.ExecuteNonQuery();
                if (status==1)
                {
                    MessageBox.Show("Dang ki thanh cong!");
                }
                databaseConnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm firstform = new LoginForm();
            firstform.Show();
        }
    }
}
