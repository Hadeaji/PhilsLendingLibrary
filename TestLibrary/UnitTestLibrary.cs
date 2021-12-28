using PhilsLendingLibrary.Classes;
using System;
using Xunit;

namespace TestLibrary
{
    public class UnitTestLibrary
    {
        [Fact]
        public void TestAddBorrowReturn()
        {
            // Book newBook = new Book("Alice in Wonderland", "Lewis", "Carol", 146);
            Library myLibrary = new Library();
            myLibrary.Add("Alice in Wonderland", "Lewis", "Carol", 146);
            myLibrary.Add("The Great Gatsby", "F. Scott", "Fitzgerald", 218);

            Assert.Equal(2, myLibrary.Count);

            Book firstBorrowed = myLibrary.Borrow("Alice in Wonderland");
            Book secBorrowed = myLibrary.Borrow("The Great Gatsby");

            Assert.Empty(myLibrary);
            Assert.Equal(146, firstBorrowed.NumberOfPages);
            Assert.Equal(218, secBorrowed.NumberOfPages);

            myLibrary.Return(firstBorrowed);

            Assert.Single(myLibrary);

        }
    }
}
