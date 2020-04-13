using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
    }
    public class MyBookLibrary
    {
        List<Book> listBook;


        public MyBookLibrary()
        {
            listBook = new List<Book>();
        }

        public void AddBook()
        {
            Book newBook = new Book();

            newBook.ID = listBook.Count() + 1;

            Console.WriteLine("Nhap vao ten sach : ");
            newBook.Name = Console.ReadLine();

            Console.WriteLine("Nhap vao nha xuat ban : ");
            newBook.Publisher = Console.ReadLine();

            Console.WriteLine("Nhap vao gia tien :");
            newBook.Price = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Da them thanh cong!");
            listBook.Add(newBook);
            ListAllBook();
        }

        public void UpdateBook()
        {
            Console.WriteLine("Nhap vao id : ");
            int id = Int32.Parse(Console.ReadLine());

            Book book = listBook.Find(b => b.ID == id);

            if (book != null)
            {
                Console.WriteLine("Nhap vao ten sach : ");
                book.Name = Console.ReadLine();

                Console.WriteLine("Nhap vao nha xuat ban : ");
                book.Publisher = Console.ReadLine();

                Console.WriteLine("Nhap vao gia tien :");
                book.Price = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Da cap nhat thanh cong!");
                ListAllBook();
            }
            else
            {
                Console.WriteLine("Id nhap vao khong ton tai!");
            }
        }

        public void DeleteBook()
        {
            Console.WriteLine("Nhap vao id : ");
            int id = Int32.Parse(Console.ReadLine());

            Book book = listBook.Find(b => b.ID == id);

            Console.WriteLine("Ban co muon xoa sach co id " + id + "khong? ");
            string answer = Console.ReadLine();

            if (answer.Equals("yes"))
            {
                if (book != null)
                {
                    listBook.Remove(book);

                    Console.WriteLine("Da xoa thanh cong!");
                    ListAllBook();
                }
                else
                {
                    Console.WriteLine("Id nhap vao khong ton tai!");
                }
            }
        }

        public void ListAllBook()
        {
            foreach(var b in listBook)
            {
                Console.WriteLine("ID : " + b.ID);
                Console.WriteLine("Name : " + b.Name);
                Console.WriteLine("Price : " + b.Price);
                Console.WriteLine("Pulisher : " + b.Publisher);
            }
        }
    }
}
