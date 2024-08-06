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
using Bank;
using Login.DAL;

namespace Login
{
    public partial class Deposit : Form
    {
        public Deposit(string username)
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
            accountNumberLabel.Text = l._AccountNumber;
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
        Account l = new Account();
        userDAL dal = new userDAL();
        private void BalanceTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            string username = accountNumberLabel.Text;
            this.Close();
            MyAccount form3 = new MyAccount(username);
            form3.Show();
        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
                SqlConnection conn = new SqlConnection(myconnstrng);
                Account l = new Account();
                DataTable dt = new DataTable();
                string username = accountNumberLabel.Text;
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
                    l._Password = dt.Rows[0]["password"].ToString();
                    l._Balance += double.Parse(AmountToDepsoitTxt.Text);
                }
                bool success = dal.Update(l);
                if (success == true)
                {
                    MessageBox.Show("Deposit Successful", "Success");
                    BalanceLabel2.Text = l._Balance.ToString();

                }
                else
                {
                    MessageBox.Show("Deposit Failed", "Failure");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter a valid amount.");
            }

        }

        private void AmountLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Deposit_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
