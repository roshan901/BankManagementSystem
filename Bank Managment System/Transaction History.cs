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
    public partial class Transaction_History : Form
    {
        static MySqlConnection conn = new MySqlConnection("server=localhost; database=bank_system; userid='root'; password=''; SslMode=none;");
        MySqlCommand cmd = conn.CreateCommand();

        public Transaction_History()
        {
            InitializeComponent();
        }

        private void textBoxAccno_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                using (conn)
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Deposited_Amount, Deposited_Date FROM deposit WHERE Account_Number = '" + textBoxAccno.Text + "'";
                        cmd.CommandType = CommandType.Text;

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    dataGridView1.Rows.Add(reader["Deposited_Date"], reader["Deposited_Amount"]);
                                }
                            }
                        }
                    }
                }
                int rowCount = dataGridView1.RowCount; int abc = 0;
                using (conn)
                {
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Withdrawed_Amount, Withdrawed_Date FROM withdraw WHERE Account_Number = '" + textBoxAccno.Text + "'";
                        cmd.CommandType = CommandType.Text;

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (rowCount >= abc)
                                    {
                                        dataGridView1.Rows[abc].Cells[2].Value = reader["Withdrawed_Date"].ToString();
                                        dataGridView1.Rows[abc].Cells[3].Value = reader["Withdrawed_Amount"].ToString();
                                        abc++;
                                    }
                                    else
                                    {
                                        dataGridView1.Rows.Add("", "", reader["Withdrawed_Date"], reader["Withdrawed_Amount"]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            //try
            //{
            //    conn.Open();
            //    cmd = new MySqlCommand("select * from withdraw where Account_Number='" + textBoxAccno.Text + "'", conn);
            //    MySqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            dataGridView1.Rows.Clear();
            //            dataGridView1.Refresh();
            //            string myConnectionString = "datasource=localhost;user=root;database=bank_system;SslMode=none";
            //            MySqlConnection conn = new MySqlConnection(myConnectionString);
            //            //  MySqlCommand cmd = new MySqlCommand("SELECT Deposited_Date,Deposited_Amount FROM deposit", conn);
            //            MySqlCommand cmd = new MySqlCommand("SELECT Withdrawed_Date,Withdrawed_Amount FROM withdraw", conn);
            //            // cmd.CommandType = CommandType.Text;
            //            cmd.CommandType = CommandType.Text;

            //        }
            //        //    } }
            //        //try
            //        //{
            //       // conn.Open();
            //     //   using (MySqlDataReader reade = cmd.ExecuteReader())
            //     //   {
            //       //     while (reade.Read())
            //            {
            //                dataGridView1.Rows.Add(reader["Withdrawed_Date"], reader["Withdrawed_Amount"]);
            //            }

            //    }
            //    else if (string.IsNullOrEmpty(textBoxAccno.Text))
            //    {
            //        MessageBox.Show("Enter All the TextBoxes Required !!");
            //        return;
            //    }

            //}
            // catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        conn.Close();
            //    }  
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
