using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bank_Managment_System
{
    public partial class login : Form
    {

        static MySqlConnection conn = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
        MySqlCommand cmd = conn.CreateCommand();
        //private void InitializeComponent()
        //{
        //    server = "localhost";
        //    database = "connectcsharptomysql";
        //    uid = "username";
        //    password = "password";
        //    string connectionString;
        //    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        //    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        //    connection = new MySqlConnection(connectionString);
        //}

        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            try
            {
                conn.Open();
                cmd.CommandText = "SELECT * from login where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                cmd.CommandType = CommandType.Text;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        this.Hide();

                        homepage homee = new homepage();
                        homee.ShowDialog();
                    }
                    else { MessageBox.Show("Incorrect Username and password!!"); }
                }
                conn.Close();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

