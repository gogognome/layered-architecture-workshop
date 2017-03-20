using System;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class BookService
    {
        private readonly BookDAO bookDao;

        public BookService(BookDAO bookDao)
        {
            this.bookDao = bookDao;
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
    }
}
