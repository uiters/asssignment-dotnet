using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BookService
{
    /// <summary>
    /// Summary description for BookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Book> GetBookList()
        {
            BookDataContext bookData = new BookDataContext();
            return bookData.Books.ToList();
        }

        [WebMethod]
        public void AddBook(Book newBook)
        {
            try
            {
                BookDataContext bookData = new BookDataContext();
                bookData.Books.InsertOnSubmit(newBook);
                bookData.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        [WebMethod]
        public void Update(Book updateBook)
        {
            try
            {
                BookDataContext bookData = new BookDataContext();
                Book book = bookData.Books.SingleOrDefault(b => b.BookID.Equals(updateBook.BookID));
                book.BookPrice = updateBook.BookPrice;
                book.BookTitle = updateBook.BookTitle;
                bookData.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        [WebMethod]
        public void Delete(Book deleteBook)
        {
            try
            {
                BookDataContext bookData = new BookDataContext();
                Book book = bookData.Books.SingleOrDefault(b => b.BookID.Equals(deleteBook.BookID));
                bookData.Books.DeleteOnSubmit(deleteBook);
                bookData.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        [WebMethod]
        public List<Book> SearchBook(Book bookinfo)
        {
            try
            {
                BookDataContext bookData = new BookDataContext();
                var result = from b in bookData.Books
                             where b.BookID.Equals(bookinfo.BookID)
                             orderby b.BookPrice descending
                             select b;

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
