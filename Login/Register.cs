using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank;
using Login.DAL;


namespace Login
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        Account l = new Account();
        userDAL dal = new userDAL();

        private void BalanceLabel2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            l._AccountNumber = cardtxt.Text;
            l._Password = passwordtxt.Text;
            l._Name = Nametxt.Text;
            l._Email = emailtxt.Text;
            l._PhoneNum = numtxt.Text;
            l._Address = addresstxt.Text;
            l._ID = IDtxt.Text;
            l._Balance = 0.00;
            bool success = dal.Insert(l);
            if(success == true)
            {
                MessageBox.Show("Registration Successful","Success");
                this.Hide();
                LoginForm form3 = new LoginForm();
                form3.Show();

            }
            else
            {
                MessageBox.Show("Registration Failed", "Failure");
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form3 = new LoginForm();
            form3.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
