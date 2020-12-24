using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


namespace Bank_Managment_System
{
    public partial class Transfer : Form
    {
        static MySqlConnection conn = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
        MySqlCommand cmd = conn.CreateCommand();

        public Transfer()
        {
            InitializeComponent();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxAmount.Text) | string.IsNullOrEmpty(textBoxFrom.Text) | String.IsNullOrEmpty(textBoxTo.Text) | String.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Enter All the TextBoxes Required !!");
                return;
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
                string insertQuery = "INSERT INTO transfer VALUES ('" + this.dateTimePicker1.Text + "','" + textBoxFrom.Text + "','" + textBoxTo.Text + "','" + textboxAmount.Text + "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        string query = "UPDATE `customer` SET `Amount`=Amount+'" + textboxAmount.Text + "' WHERE `Account_Number`='" + Convert.ToInt32(textBoxTo.Text) + "'";
                        command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        query = "UPDATE `customer` SET `Amount`=Amount-'" + textboxAmount.Text + "' WHERE `Account_Number`='" + Convert.ToInt32(textBoxFrom.Text) + "'";
                        command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Transfered Successfully!!");
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
