using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStoreLibrary
{
    public class Book
    {
        private int bookId;
        private string bookName;
        private float bookPrice;

        public Book(int bookId, string bookName, float bookPrice)
        {
            this.bookId = bookId;
            this.bookName = bookName;
            this.bookPrice = bookPrice;
        }

        public Book(DataRow row)
        {
            bookId = Convert.ToInt32(row["BookID"]);
            bookName = Convert.ToString(row["BookName"]);
            bookPrice = Convert.ToSingle(row["BookPrice"]);
        }

        public float BookPrice { get => bookPrice; set => bookPrice = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public int BookId { get => bookId; set => bookId = value; }
    }
}
