using Login.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login;

namespace Bank
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        Account l = new Account();
        loginDAL dal = new loginDAL();


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(UsernameTextBox.Text == "admin" && PasswordTextBox.Text == "admin")
            {
                this.Hide();
                Database form2 = new Database();
                form2.Show();
            }
            else
            {
                l._AccountNumber = UsernameTextBox.Text;
                l._Password = PasswordTextBox.Text;
                bool isSuccess = dal.loginCheck(l);
                if (isSuccess == true)
                {
                    MessageBox.Show("Login Successful.");
                    MyAccount form2 = new MyAccount(UsernameTextBox.Text);
                    form2.Show();
                    this.Hide();
                }
                
            }
            
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register form3 = new Register();
            form3.Show();
        }
    }
}
