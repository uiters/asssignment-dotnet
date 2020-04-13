using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1.App_Code
{
    public class UserInfoData
    {
        string strConnection =
            "Data Source=DESKTOP-CSD9U4B\\SQLEXPRESS;Initial Catalog=SaleManager;Integrated Security=True";
        
        public UserInfoData() { }
        public void InsertUserInfo(UserInfo userInfo)
        {
            SqlConnection conn = new SqlConnection(strConnection);
            string SQL = "Insert UserInfo values (@UserName,@Password,@BirthDate,@Address,@Email)";
            SqlCommand cmd = new SqlCommand(SQL, conn);

            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            cmd.Parameters.AddWithValue("@Address", userInfo.Address);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateUserInfo(UserInfo userInfo)
        {
            SqlConnection conn = new SqlConnection(strConnection);
            string SQL = "Update UserInfo set [Password]=@Password, BirthDate = @BirthDate," +
                "[Address] = @Address, Email = @Email where UserName = @UserName";
            SqlCommand cmd = new SqlCommand(SQL, conn);

            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            cmd.Parameters.AddWithValue("@Address", userInfo.Address);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteUserInfo(UserInfo userInfo)
        {
            SqlConnection conn = new SqlConnection(strConnection);
            string SQL = "Delete UserInfo where UserName= @UserName";
            SqlCommand cmd = new SqlCommand(SQL, conn);

            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        public List<UserInfo> GetUserList()
        {
            List<UserInfo> data = new List<UserInfo>();
            string SQL = "SELECT * from UserInfo";
            SqlConnection conn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dynamic u = new UserInfo()
                    {
                        UserName = rd["UserName"].ToString(),
                        Password = rd["Password"].ToString(),
                        BirthDate = DateTime.Parse(rd["BirthDate"].ToString()),
                        Address = rd["Address"].ToString(),
                        Email = rd["Email"].ToString(),
                    };
                    data.Add(u);
                }
            }
            return data;
        }
    }
}