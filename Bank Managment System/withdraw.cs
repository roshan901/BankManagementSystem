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

namespace Bank_Managment_System
{
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void withdraw_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccno.Text) | String.IsNullOrEmpty(textBoxAmountW.Text) | String.IsNullOrEmpty(dateTimePickerWithdraw.Text))
            {
                MessageBox.Show("Enter All the TextBoxes Required !!");
                return;
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
                string insertQuery = "INSERT INTO withdraw(Account_Number,Withdrawed_Amount,Withdrawed_Date) VALUES ('" + textBoxAccno.Text + "','" + textBoxAmountW.Text + "','" + this.dateTimePickerWithdraw.Text + "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        string query = "UPDATE `customer` SET `Amount`=Amount-'" + textBoxAmountW.Text + "' WHERE `Account_Number`='" + Convert.ToInt32(textBoxAccno.Text) + "'";
                        command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Withdrawn Successfully !!");
                    }
                    else
                    {
                        MessageBox.Show("Information Not Added Check the Values");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


        
   
