using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SaleApp
{
    public partial class MaintainUser : System.Web.UI.Page
    {
        UserInfo add = new UserInfo();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UML28IP;Initial Catalog=Manager;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gvUserInfoList.DataBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            add.UserName = txUserName.Text;
            add.Password = txPassword.Text;
            add.BirthDate = txBirthDate.Text;
            add.Address = txAddress.Text;
            add.Email = txEmail.Text;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into UserInfo values('"+add.UserName+"','"+add.Password+"','"+add.BirthDate+"','"+add.Address+"','"+add.Email+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            add.UserName = txUserName.Text;
            add.Password = txPassword.Text;
            add.BirthDate = txBirthDate.Text;
            add.Address = txAddress.Text;
            add.Email = txEmail.Text;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE UserInfo SET UserName='"+add.UserName+"',Password='"+add.Password+"',BirthDate='"+add.BirthDate+"',Address='"+add.Address+"',Email='"+add.Email+"' WHERE UserName='"+preUN.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM UserInfo WHERE UserName = '"+preUN.Text+"'";
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        protected void gvUserInfoList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow selectedRow = gvUserInfoList.Rows[e.NewSelectedIndex];
            txUserName.Text = selectedRow.Cells[1].Text;
            txPassword.Text = selectedRow.Cells[2].Text;
            txBirthDate.Text = selectedRow.Cells[3].Text;
            txAddress.Text = selectedRow.Cells[4].Text;
            txEmail.Text = selectedRow.Cells[5].Text;
            preUN.Text = selectedRow.Cells[1].Text;
        }
    }

    internal class UserInfo
    {

    public String UserName, Password, BirthDate, Address, Email;
    public UserInfo()
        {
        }

    }
}