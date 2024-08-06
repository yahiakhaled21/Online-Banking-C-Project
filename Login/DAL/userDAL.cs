using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Bank;

namespace Login.DAL
{
    internal class userDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region SELECT data from database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Accounts";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region INSERT Data into Database
        public bool Insert(Account u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "INSERT INTO Accounts(accountNumber,balance,id,name,email,phonenum,password,address) VALUES (@accountNumber,@balance,@id,@name,@email,@phonenum,@password,@address)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@accountNumber", u._AccountNumber);
                cmd.Parameters.AddWithValue("@balance", u._Balance);
                cmd.Parameters.AddWithValue("@id", u._ID);
                cmd.Parameters.AddWithValue("@name", u._Name);
                cmd.Parameters.AddWithValue("@email", u._Email);
                cmd.Parameters.AddWithValue("@phonenum", u._PhoneNum);
                cmd.Parameters.AddWithValue("@password", u._Password);
                cmd.Parameters.AddWithValue("@address", u._Address);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region UPDATE data in database
        public bool Update(Account u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "UPDATE Accounts SET balance=@balance,id=@id,name=@name,email=@email,phonenum=@phonenum,password=@password,address=@address WHERE accountNumber=@accountNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@accountNumber", u._AccountNumber);
                cmd.Parameters.AddWithValue("@balance", u._Balance);
                cmd.Parameters.AddWithValue("@id", u._ID);
                cmd.Parameters.AddWithValue("@name", u._Name);
                cmd.Parameters.AddWithValue("@email", u._Email);
                cmd.Parameters.AddWithValue("@phonenum", u._PhoneNum);
                cmd.Parameters.AddWithValue("@password", u._Password);
                cmd.Parameters.AddWithValue("@address", u._Address);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region DELETE Data from Database
        public bool Delete(Account u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                String sql = "DELETE FROM Accounts WHERE accountNumber=@accountNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@accountNumber", u._AccountNumber);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
    }
}
