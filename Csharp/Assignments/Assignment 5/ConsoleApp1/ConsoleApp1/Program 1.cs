using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Book
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }


        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}, Author Name: {AuthorName}");
        }
    }


    public class BookShelf
    {
        private Book[] books;


        public BookShelf(int numberOfBooks)
        {
            books = new Book[numberOfBooks];
        }


        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                {
                    Console.WriteLine("Invalid index.");
                    return null;
                }
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Length)
                {
                    Console.WriteLine("Invalid index.");
                    return;
                }
                books[index] = value;
            }
        }


        public void DisplayAllBooks()
        {
            Console.WriteLine("Books in the BookShelf:");
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    books[i].Display();
                }
                else
                {
                    Console.WriteLine($"Book {i + 1}: No book assigned.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            BookShelf shelf = new BookShelf(5);

            shelf[0] = new Book("Sundarakandha", "Valmiki");
            shelf[1] = new Book("Karthika puranam", "Gollapudi");
            shelf[2] = new Book("Bhagawatam", "Pothana");
            shelf[3] = new Book("Soundarya lahari", "Sankaracharya");
            shelf[4] = new Book("Guru charitra", "Ekkirala bharadwaj");
            

            shelf.DisplayAllBooks();

            Console.ReadLine();
        }
    }
}

