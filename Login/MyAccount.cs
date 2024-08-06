using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login;

namespace Bank
{
    public partial class MyAccount : Form
    {
        public MyAccount(string username)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
            InitializeComponent();
            SqlConnection conn = new SqlConnection(myconnstrng);
            Account l = new Account();
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT accountNumber,balance,id,name,email,phonenum,password,address FROM Accounts WHERE accountNumber='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    l._AccountNumber = dt.Rows[0]["accountNumber"].ToString();
                    l._Name = dt.Rows[0]["name"].ToString();
                    l._Email = dt.Rows[0]["email"].ToString();
                    l._PhoneNum = dt.Rows[0]["phonenum"].ToString();
                    l._Address = dt.Rows[0]["address"].ToString();
                    l._ID = dt.Rows[0]["id"].ToString();
                    l._Balance = Convert.ToDouble(dt.Rows[0]["balance"]);
                }
                CardNumberLabel2.Text = l._AccountNumber;
                NameLabel2.Text = l._Name;
                EmailLabel2.Text = l._Email;
                PhoneNumberLabel2.Text = l._PhoneNum;
                AddressLabel2.Text = l._Address;
                IDLabel2.Text = l._ID;
                BalanceLabel2.Text = l._Balance.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void CardNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void MyAccount_Load(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form2 = new LoginForm();
            form2.Show();
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deposit form2 = new Deposit(CardNumberLabel2.Text);
            form2.Show();
        }

        private void IDTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Withdraw form2 = new Withdraw(CardNumberLabel2.Text);
            form2.Show();
        }

        private void CardNumberLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
