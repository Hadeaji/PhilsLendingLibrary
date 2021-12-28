using PhilsLendingLibrary.Classes;
using System;
using System.Collections.Generic;

namespace PhilsLendingLibrary
{
    class Program
    {
        private static Library PhilsLibrary = new Library();
        private static Backpack<Book> PhilsBackpack = new Backpack<Book>();

        static void Main(string[] args)
        {
            LoadBooks();
            UserInterface();
        }

        private static void UserInterface()
        {
            while (true)
            {
                Console.WriteLine("WELCOME to Phil's lending library!");
                Console.WriteLine("pick an option...");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Add New Book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View Book Bag");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Library");
                        Console.WriteLine("=======");
                        PrintBooks(PhilsLibrary);
                        break;
                    case "2":
                        Console.Clear();
                        AddBook();
                        PrintBooks(PhilsLibrary);
                        break;
                    case "3":
                        Console.Clear();
                        BorrowBook();
                        PrintBooks(PhilsLibrary);
                        break;
                    case "4":
                        Console.Clear();
                        ReturnBook();
                        PrintBooks(PhilsLibrary);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Book Bag");
                        Console.WriteLine("========");
                        PrintBooks(PhilsBackpack);
                        break;
                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid Option..");
                        Console.WriteLine();
                        break;

                }
            }
        }

        private static void AddBook()
        {
            Console.WriteLine("Please Add The Book Details:");
            Console.Write("Book Title: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Author First Name: ");
            string authorFirstName = Console.ReadLine();
            Console.Write("Author Last  Name: ");
            string authorLastName = Console.ReadLine();
            Console.Write("Number Of Pages: ");
            string pages = Console.ReadLine();
            int.TryParse(pages, out int pagesNum);

            PhilsLibrary.Add(bookTitle, authorFirstName, authorLastName, pagesNum);
        }

        private static void BorrowBook()
        {
            PrintBooks(PhilsLibrary);

            Console.WriteLine("Please Enter The Title Of The Book You Want:");
            string bookTitle = Console.ReadLine();
            Book desiredBook = PhilsLibrary.Borrow(bookTitle);
            if(desiredBook != null)
            {
                PhilsBackpack.Pack(desiredBook);
            }

            Console.WriteLine();
        }

        private static void ReturnBook()
        {
            PrintBooks(PhilsBackpack);

            Console.WriteLine("Please Enter The Book You Want To Return:");
            string choice = Console.ReadLine();
            int.TryParse(choice, out int bookNumber);
            Book returnedBook = PhilsBackpack.Unpack(bookNumber - 1);
            if(returnedBook != null)
            {
                PhilsLibrary.Return(returnedBook);
            }
            Console.WriteLine();

        }


        static void LoadBooks()
        {
            PhilsLibrary.Add("Alice in Wonderland", "Lewis", "Carol", 146);
            PhilsLibrary.Add("The Great Gatsby", "F. Scott", "Fitzgerald", 218);
            PhilsLibrary.Add("To Kill a Mockingbird", "Harper", "Lee", 281);
            PhilsLibrary.Add("Lord of the Flies", "William", "Golding", 224);
        }

        private static void PrintBooks(IEnumerable<Book> Storage)
        {
            int count = 1;
            foreach(Book book in Storage)
            {
                Console.WriteLine($"{count}. {book}");
                count++;
            }
            Console.WriteLine();
        }
    }
}
