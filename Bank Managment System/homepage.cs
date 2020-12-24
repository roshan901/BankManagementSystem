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
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           createaccountform  createForm = new createaccountform();
            createForm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void homepage_Load(object sender, EventArgs e)
        {

        }

        private void homepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer customerdetails = new Customer();
            customerdetails.ShowDialog();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            deposit depositcash = new deposit();
            depositcash.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            withdraw withdrawcash = new withdraw();
            withdrawcash.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
           Transfer transfermoney = new Transfer();
            transfermoney.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Transaction_History transaction = new Transaction_History();
            transaction.ShowDialog();
        }
    }
}
