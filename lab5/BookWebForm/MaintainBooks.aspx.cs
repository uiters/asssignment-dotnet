using BookWebForm.localhost;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookWebForm
{
    public partial class MaintainBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        public void LoadData()
        {
            BookService BookData = new BookService();
            DataSet dsBooks = BookData.GetBookList();
            gvBookList.DataSource = dsBooks.Tables[0];
            gvBookList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BookService BookData = new BookService();
            int BookID = int.Parse(txtBookID.Text);
            string BookTitle = txtBookTitle.Text;
            float BookPrice = float.Parse(txtBookPrice.Text);
            BookData.AddBook(BookID, BookTitle, BookPrice);
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BookService BookData = new BookService();
            int BookID = int.Parse(txtBookID.Text);
            string BookTitle = txtBookTitle.Text;
            float BookPrice = float.Parse(txtBookPrice.Text);
            BookData.UpdateBook(BookID, BookTitle, BookPrice);
            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BookService BookData = new BookService();
            int BookID = int.Parse(txtBookID.Text);
            BookData.DeleteBook(BookID);
            LoadData();
        }

        protected void gvBookList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvBookList.Rows[e.NewSelectedIndex];
            txtBookID.Text = row.Cells[1].Text;
            txtBookTitle.Text = row.Cells[2].Text;
            txtBookPrice.Text = row.Cells[3].Text;
        }
    }
}