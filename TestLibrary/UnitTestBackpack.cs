using PhilsLendingLibrary.Classes;
using System;
using Xunit;

namespace TestLibrary
{
    public class UnitTestBackpack
    {
        [Fact]
        public void TestPackUnpack()
        {
            // Book newBook = new Book("Alice in Wonderland", "Lewis", "Carol", 146);
            Backpack<Book> myBackpack = new Backpack<Book>();
            Book testBook1 = new Book("Alice in Wonderland", "Lewis", "Carol", 146);
            Book testBook2 = new Book("The Great Gatsby", "F. Scott", "Fitzgerald", 218);

            myBackpack.Pack(testBook1);
            myBackpack.Pack(testBook2);

            Assert.Equal(2, myBackpack.Count);

            String[] booksTitles = new String[2];
            int count = 0;
            foreach(Book book in myBackpack)
            {
                booksTitles[count]= book.Title;
                count++;
            }

            Assert.Equal(booksTitles, new string[] { "Alice in Wonderland","The Great Gatsby"});

            myBackpack.Unpack(0);
            Book secBook = myBackpack.Unpack(0);

            Assert.Equal("The Great Gatsby", secBook.Title);

        }
    }
}
