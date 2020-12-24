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
    public partial class deposit : Form
    {
        public deposit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccno.Text) | String.IsNullOrEmpty(textBoxAmountD.Text) | String.IsNullOrEmpty(dateTimePickerDeposit.Text))
            {
                MessageBox.Show("Enter All the TextBoxes Required !!");
                return;
            }
            else
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
                string insertQuery = "INSERT INTO deposit(Account_Number,Deposited_Amount,Deposited_Date) VALUES ('" + textBoxAccno.Text + "','" + textBoxAmountD.Text + "','" + this.dateTimePickerDeposit.Text + "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        string query = "UPDATE `customer` SET `Amount`=Amount+'" + textBoxAmountD.Text + "' WHERE `Account_Number`='" + Convert.ToInt32(textBoxAccno.Text) + "'";
                        command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deposited Sucessfully !!");
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

