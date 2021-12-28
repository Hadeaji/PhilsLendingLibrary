using PhilsLendingLibrary.Classes;
using System;
using Xunit;

namespace TestLibrary
{
    public class UnitTestBook
    {
        [Fact]
        public void TestCreatBook()
        {
            Book newBook = new Book("Alice in Wonderland", "Lewis", "Carol", 146);
            Assert.Equal("Alice in Wonderland", newBook.Title);
            Assert.Equal("Lewis", newBook.Author.FirstName);
            Assert.Equal("Carol", newBook.Author.LastName);
            Assert.Equal(146, newBook.NumberOfPages);
        }
    }
}
