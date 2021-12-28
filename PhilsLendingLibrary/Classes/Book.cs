using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsLendingLibrary.Classes
{
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumberOfPages { get; set; }

        public Book(string title, string firstName, string lastName, int numberOfPages)
        {
            Title = title;
            Author = new Author(firstName, lastName);
            NumberOfPages = numberOfPages;
        }

        public override string ToString()
        {
            return $"{Title} - {Author.FirstName} {Author.LastName}";
        }

    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
