using System;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class BookService : IBookService
    {
        private readonly IBookDAO bookDao;
        private readonly IBorrowedBookDAO borrowedBookDao;

        public BookService(IBookDAO bookDao, IBorrowedBookDAO borrowedBookDao)
        {
            this.bookDao = bookDao;
            this.borrowedBookDao = borrowedBookDao;
        }

        public Book AddBook(Book book)
        {
            Validate(book);
            return bookDao.AddBook(book);
        }

        private static void Validate(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Title must be filled in", "book");
            }
            if (string.IsNullOrWhiteSpace(book.Author))
            {
                throw new ArgumentException("Author must be filled in", "book");
            }
        }

        public List<Book> GetBooks()
        {
            return bookDao.GetBooks();
        }

        public BorrowedBook Borrow(Book book, User user)
        {
            Validate(book, user);

            var borrowedBook = new BorrowedBook
            {
                BookID = book.Id,
                UserID = user.Id,
                BorrowedAt = DateTime.Now,
                DueDate = DateTime.Now + TimeSpan.FromDays(21)
            };

            return borrowedBookDao.AddBorrowedBook(borrowedBook);
        }

        private static void Validate(Book book, User user)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
        }

        public Book GetBookById(long bookId)
        {
            return bookDao.GetBookById(bookId);
        }

        public IEnumerable<BorrowedBook> GetBorrowedBooks()
        {
            return borrowedBookDao.GetBorrowedBooks();
        }
    }
}
