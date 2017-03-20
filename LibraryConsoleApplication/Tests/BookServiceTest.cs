using System;
using NUnit.Framework;

namespace LibraryConsoleApplication.Tests
{
    [TestFixture]
    public class BookServiceTest
    {
        private IBookDAO bookDaoMock;
        private IBorrowedBookDAO borrowedBookDaoMock;
        private IBookService bookService;

        private Book book;
        private User user;

        [SetUp]
        public void SetUp()
        {
            bookDaoMock = new BookDAO();
            borrowedBookDaoMock = new BorrowedBookDAO();
            bookService = new BookService(bookDaoMock, borrowedBookDaoMock);

            book = new Book { Id = 1, Author = "Piet Puk", Title = "Once upon a time..." };
            user = new User { Id = 2, Name = "Jan Jansen" };
        }

        [Test]
        public void Borrow_BookAbsent_Fails()
        {
            Assert.Throws<ArgumentNullException>(() => bookService.Borrow(null, user));
        }

        [Test]
        public void Borrow_UserAbsent_Fails()
        {
            Assert.Throws<ArgumentNullException>(() => bookService.Borrow(book, null));
        }

        [Test]
        public void Borrow_ValidParemeters_ReturnsBorrowedBook()
        {
            var borrowedBook = bookService.Borrow(book, user);

            Assert.AreEqual(book.Id, borrowedBook.BookID);
            Assert.AreEqual(user.Id, borrowedBook.UserID);
            Assert.AreEqual(DateTime.Now.Ticks, borrowedBook.BorrowedAt.Ticks, TimeSpan.FromSeconds(1).Ticks);
            Assert.AreEqual((DateTime.Now + TimeSpan.FromDays(21)).Ticks, borrowedBook.DueDate.Ticks, TimeSpan.FromSeconds(1).Ticks);
        }
    }

}
