using PhilsLendingLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsLendingLibrary.Classes
{
    public class Library : ILibrary
    {
        private readonly Dictionary<string, Book> Storage = new Dictionary<string, Book>();
        public int Count => Storage.Count;

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            Book newBook = new Book(title, firstName, lastName, numberOfPages);
            Storage.Add(newBook.Title, newBook);
        }

        public Book Borrow(string title)
        {
            Storage.TryGetValue(title, out Book borrowedBook);
            Storage.Remove(title);
            return borrowedBook;
        }

        public void Return(Book book)
        {
            Storage.Add(book.Title, book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach(Book book in Storage.Values)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
