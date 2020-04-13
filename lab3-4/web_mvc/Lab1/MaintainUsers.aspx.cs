using Lab1.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class MaintainUsers : System.Web.UI.Page
    {
        UserInfoData data = new UserInfoData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            grvUserInfoList.DataSource = data.GetUserList();
            grvUserInfoList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                BirthDate = DateTime.Parse(txtBirthDate.Text),
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };
            data.InsertUserInfo(u);
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                BirthDate = DateTime.Parse(txtBirthDate.Text),
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };
            data.UpdateUserInfo(u);
            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                UserName = txtUserName.Text,
            };
            data.DeleteUserInfo(u);
            LoadData();
        }

        protected void grvUserInfoList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow selectedRow = grvUserInfoList.Rows[e.NewSelectedIndex];
            txtUserName.Text = selectedRow.Cells[1].Text;
            txtPassword.Text = selectedRow.Cells[2].Text;
            txtBirthDate.Text = selectedRow.Cells[3].Text;
            txtAddress.Text = selectedRow.Cells[4].Text;
            txtEmail.Text = selectedRow.Cells[5].Text;
        }
    }
}