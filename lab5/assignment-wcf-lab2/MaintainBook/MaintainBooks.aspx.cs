using System;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using MaintainBook.localhost;

namespace MaintainBook
{
    public partial class MaintainBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            BookService bookData = new BookService();
            grvBookList.DataSource = bookData.GetBookList();
            grvBookList.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BookService bookData = new BookService();
            string id = txtBookID.Text;
            string title = txtBookTitle.Text;
            int price = int.Parse(txtBookPrice.Text);
            Book b = new Book { BookID = id, BookPrice = price, BookTitle = title };
            bookData.AddBook(b);
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BookService bookData = new BookService();
            string id = txtBookID.Text;
            string title = txtBookTitle.Text;
            int price = int.Parse(txtBookPrice.Text);
            Book b = new Book { BookID = id, BookPrice = price, BookTitle = title };
            bookData.Update(b);
            LoadData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BookService bookData = new BookService();
            string id = txtBookID.Text;
            Book b = new Book { BookID = id };
            bookData.Delete(b);
            LoadData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BookService bookData = new BookService();
            string id = txtBookID.Text;
            Book b = new Book { BookID = id };
            var result = bookData.SearchBook(b);
            grvBookList.DataSource = result;
            grvBookList.DataBind();
        }

        protected void grvBookList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = grvBookList.Rows[e.NewSelectedIndex];
            txtBookID.Text = row.Cells[1].Text;
            txtBookPrice.Text = row.Cells[3].Text;
            txtBookTitle.Text = row.Cells[2].Text;
        }
    }
}