using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    
    public partial class LoginForm : Form
    {
        public static String uid_global = "";
        public static String userType_global = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            String user_name_in = usernameBox.Text;
            String pass_word_in = passwordBox.Text;
            
            //String uid;

            String user_name_DB;
            String pass_word_DB;

            ConnectDB ketnoi = new ConnectDB();
            SqlConnection databaseConnection = ketnoi.ketnoiDB();
            String query = "SELECT  * FROM qlycuahang.userTB WHERE username='" + user_name_in+"'";
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
                        
                        string[] row = { reader.GetString(0).Trim(), reader.GetString(1).Trim(), reader.GetString(2).Trim(), reader.GetString(3).Trim() };

                       
                        if (row[0].Length >= 6)
                        {
                            string[] subs = row[0].Split('-');
                            MessageBox.Show(subs[0] + " " + subs[1]);
                            uid_global = "cN" + subs[1];
                        }
                        else
                        {
                            uid_global = row[0];
                        }
                        
                        user_name_DB = row[1];
                        pass_word_DB = row[2];
                        userType_global = row[3];
                        if (pass_word_in == pass_word_DB)
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            this.Hide();
                            MainForm mainF = new MainForm();
                            mainF.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username/password is not existed in the DB!.");
                }
                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm secondtform = new RegisterForm();
            secondtform.Show();
        }
    }
}
