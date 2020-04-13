using System;
using ClassLibrary1;

namespace BookManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBookLibrary library = new MyBookLibrary();

            Console.WriteLine("Select action : ");
            Console.WriteLine("1.Add new book");
            Console.WriteLine("2.Update a book");
            Console.WriteLine("3.Delete a book");
            Console.WriteLine("4.List all book");
            Console.WriteLine("5.Quit ");

            int choice = 0;


            while(choice != 5)
            {
                Console.WriteLine("Your choice : ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        library.AddBook();
                        break;
                    case 2:
                        library.UpdateBook();
                        break;
                    case 3:
                        library.DeleteBook();
                        break;
                    case 4:
                        library.ListAllBook();
                        break;
                    default:
                        break;
                }
            }
          

        }
    }
}
