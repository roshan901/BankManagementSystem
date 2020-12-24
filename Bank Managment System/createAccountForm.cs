using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Bank_Managment_System
{
    public partial class createaccountform : Form
    {
        Validation validate = new Validation();
        string pictureFileName;
        public createaccountform()
        {

            InitializeComponent();
        }

        private void createaccountform_Load(object sender, EventArgs e)
        {

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            File.Copy(openFileDialog1.FileName, Application.StartupPath + "\\images\\" + openFileDialog1.SafeFileName);

            if (string.IsNullOrEmpty(textBoxName.Text) | string.IsNullOrEmpty(dateTimePicker1.Text) | String.IsNullOrEmpty(comboBoxGender.Text) | String.IsNullOrEmpty(textBoxAddress.Text) | String.IsNullOrEmpty(textBoxPhone_Number.Text) | String.IsNullOrEmpty(textBoxNationality.Text) | String.IsNullOrEmpty(textBoxEmail_Address.Text) | String.IsNullOrEmpty(textBoxCitizenship_no.Text) | String.IsNullOrEmpty(comboBoxAccount_Type.Text) | String.IsNullOrEmpty(textBoxEmail_Address.Text) | String.IsNullOrEmpty(comboBoxAccount_Type.Text) | String.IsNullOrEmpty(dateTimePicker2.Text) | String.IsNullOrEmpty(textBoxAmount.Text))
            {
                MessageBox.Show("Enter All the TextBoxes Required !!");
                return;
            }
            else if (validate.EmailValid(textBoxEmail_Address.Text) == false)
            {
                MessageBox.Show("Invalid email");
            }

            else

            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;userid=root;database=bank_system;SslMode=none");
                string insertQuery = "INSERT INTO customer(Name,DOB,Address,Phone_Number,Gender,Nationality,Email_address,Citizenship_No,Account_Number,Account_Type,Date_Of_Account_Created,Amount,Photo) VALUES ('" + textBoxName.Text + "','" + this.dateTimePicker1.Text + "','" + textBoxAddress.Text + "','" + Convert.ToInt32(textBoxPhone_Number.Text) + "','" + comboBoxGender.Text + "','" + textBoxNationality.Text + "','" + textBoxEmail_Address.Text + "','" + textBoxCitizenship_no.Text + "','" + Convert.ToInt32(this.textBoxAccount_Number.Text) + "','" + this.comboBoxAccount_Type.Text + "','" + this.dateTimePicker2.Text + "','" + textBoxAmount.Text + "','" + openFileDialog1.SafeFileName+ "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Customer Information Added Succesfully !!");
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    // Confirm user wants to close
                    switch (MessageBox.Show(this, "Are you sure you want to exit?", "Closing", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            e.Cancel = true;
                            break;
                        default:
                            System.Environment.Exit(1);
                            break;
                    }
                }
            }
            catch { }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        private void textBoxAddress_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space || e.KeyChar == ',' || char.IsDigit(e.KeyChar));
        }

        private void textBoxNationality_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBoxEmail_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            //   e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);


        }

        private void textBoxPhone_Number_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxCitizenship_no_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBoxAccount_Number_key_press(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }

        private void textBoxAmount_keyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPhone_Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxAccount_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_Address_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                // Name = textBoxName.Text;
                //string pictureFileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureFileName = textBoxName.Text + openFileDialog1.SafeFileName.Substring(openFileDialog1.SafeFileName.LastIndexOf('.'), 4);
                //object browseFileDialog = null;
              //  File.Copy(openFileDialog1.FileName, Application.StartupPath + "\\images\\" + openFileDialog1.SafeFileName);
            }
        }

        private void textBoxAccount_Number_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
