using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStoreLibrary
{
    public interface IBookService
    {
        Book GetBook(int id);
        List<Book> GetAllBook();
        bool AddBook(Book book);
        bool EditBook(Book book);
        bool DeleteBook(int id);
    }

    public class BookService : Provider, IBookService
    {
        public static string addQuery = "insert into Books(BookID, BookName, BookPrice) values( @BookID , @BookName , @BookPrice )";
        public static string updateQuery = "update Books set BookName = @BookName , BookPrice = @BookPrice where BookID = @BookID";
        public static string deleteQuery = "delete from Books where BookID = @BookID";
        public static string getAllQuery = "select * from Books";

        public BookService(DataProvider provider) : base(provider)
        {
        }

        public bool AddBook(Book book)
        {
            return DataProvider.ExecuteNoneQuery(addQuery, new object[] { book.BookId, book.BookName, book.BookPrice }) > 0;
        }

        public bool EditBook(Book book)
        {
            return DataProvider.ExecuteNoneQuery(updateQuery, new object[] { book.BookName, book.BookPrice, book.BookId }) > 0;
        }

        public List<Book> GetAllBook()
        {
            DataTable data = DataProvider.ExecuteQuery(getAllQuery);
            List<Book> books = new List<Book>();
            foreach (DataRow row in data.Rows)
            {
                books.Add(new Book(row));
            }
            return books;
        }

        public Book GetBook(int id)
        {
            DataTable data = DataProvider.ExecuteQuery(getAllQuery);
            return new Book(data.Rows[0]);
        }

        public bool DeleteBook(int id)
        {
            return DataProvider.ExecuteNoneQuery(deleteQuery, new object[] { id }) > 0;
        }
    }
}
