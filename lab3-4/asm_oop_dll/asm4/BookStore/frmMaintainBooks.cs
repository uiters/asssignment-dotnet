using BookStoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class FrmMaintainBooks : Form
    {
        private readonly IBookService bookService = FrmLogin.bookService;
        public FrmMaintainBooks()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMaintainBooks_Load(object sender, EventArgs e)
        {
            LoadBook();
        }

        private void LoadBook()
        {
            dataView.Rows.Clear();
            List<Book> books = bookService.GetAllBook();
            books.ForEach(AddRowToView);
            AddTotalPrice(books);
        }

        private void AddRowToView(Book book)
        {
            DataGridViewRow row = (DataGridViewRow)dataView.RowTemplate.Clone();
            row.CreateCells(dataView, book.BookId, book.BookName, book.BookPrice);
            dataView.Rows.Add(row);
        }

        private void AddTotalPrice(List<Book> books)
        {
            float totalPrice = books.Sum(book => book.BookPrice);
            DataGridViewRow row = (DataGridViewRow)dataView.RowTemplate.Clone();
            row.CreateCells(dataView, "", "", totalPrice);
            dataView.Rows.Add(row);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = tryGetBook();
            if (book == null)
            {
                ShowError("Some fields is wrong");
            } else
            {
                try
                {
                    if (bookService.AddBook(book))
                    {
                        ShowSuccess("Add success");
                        LoadBook();
                    } else ShowError("Add failed");
                }
                catch 
                {
                    ShowError("Add failed");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book book = tryGetBook();
            if (book == null)
            {
                ShowError("Some fields is wrong");
            }
            else
            {
                try
                {
                    if (bookService.EditBook(book))
                    {
                        ShowSuccess("Edit success");
                        LoadBook();
                    }
                    else ShowError("Edit failed");
                }
                catch
                {
                    ShowError("Edit failed");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txbID.Text);

                if (bookService.DeleteBook(id))
                {
                    ShowSuccess("Delete success");
                    LoadBook();
                }
                else ShowError("Delete failed");
            }
            catch
            {
                ShowError("Delete failed");
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "What happend", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Book tryGetBook()
        {
            try
            {
                return new Book(Convert.ToInt32(txbID.Text), txbName.Text, Convert.ToSingle(txbPrice.Text));
            } catch
            {
                return null;
            }
        }

        private void dataView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                var row = dataView.SelectedRows[0];
                if (row.Index != dataView.Rows.Count - 1)
                    SetData(row);
            }
        }

        private void SetData(DataGridViewRow row)
        {
            txbID.Text = row.Cells[0].Value.ToString();
            txbName.Text = row.Cells[1].Value.ToString();
            txbPrice.Text = row.Cells[2].Value.ToString();
        }
    }
}
