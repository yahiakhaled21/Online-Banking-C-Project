using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.DAL;
using Bank;

namespace Login
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
        Account l = new Account();
        userDAL dal = new userDAL();

        private void Database_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgv.DataSource = dt;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            l._AccountNumber = cardtxt.Text;
            bool success = dal.Delete(l);
            if (success == true)
            {
                MessageBox.Show("User Deleted Successfully.");
                DataTable dt = dal.Select();
                dgv.DataSource = dt;
                Clear();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
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
            if (success == true)
            {
                MessageBox.Show("Addition Successful", "Success");
                DataTable dt = dal.Select();
                dgv.DataSource = dt;
                Clear();

            }
            else
            {
                MessageBox.Show("Addition Failed", "Failure");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            l._AccountNumber = cardtxt.Text;
            l._Password = passwordtxt.Text;
            l._Name = Nametxt.Text;
            l._Email = emailtxt.Text;
            l._PhoneNum = numtxt.Text;
            l._Address = addresstxt.Text;
            l._ID = IDtxt.Text;
            bool success = dal.Update(l);
            if (success == true)
            {
                MessageBox.Show("User Updated Successfully.");
                DataTable dt = dal.Select();
                dgv.DataSource = dt;
                Clear();
            }

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form3 = new LoginForm();
            form3.Show();
        }
        public void Clear()
        {
            cardtxt.Text = "";
            passwordtxt.Text = "";
            Nametxt.Text = "";
            emailtxt.Text = "";
            numtxt.Text = "";
            addresstxt.Text = "";
            IDtxt.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
