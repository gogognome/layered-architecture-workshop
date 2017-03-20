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

        public void AddBook(string book)
        {
            if (string.IsNullOrWhiteSpace(book))
            {
                throw new ArgumentException("Title must be filled in", "book");
            }
            bookDao.AddBook(book);
        }

        public List<string> GetBooks()
        {
            return bookDao.GetBooks();
        }
    }
}
