using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql;

namespace Bank_Managment_System
{
    public partial class Customer : Form
    {
        static MySqlConnection conn = new MySqlConnection("server=localhost; database=bank_system; userid='root'; password=''; SslMode=none;");
        MySqlCommand cmd = conn.CreateCommand();
        public Customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string myConnectionString = "datasource=localhost;user=root;database=bank_system;SslMode=none";
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT Name,DOB,Address,Phone_Number,Gender,Nationality,Email_address,Citizenship_No,Account_Number,Account_Type,Date_Of_Account_Created,Amount FROM customer", conn);
            cmd.CommandType = CommandType.Text;


            try
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["Name"], reader["DOB"], reader["Address"], reader["Phone_Number"], reader["Gender"], reader["Nationality"], reader["Email_address"], reader["Citizenship_No"], reader["Account_Number"], reader["Account_Type"], reader["Date_Of_Account_Created"].ToString(), reader["Amount"]);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

