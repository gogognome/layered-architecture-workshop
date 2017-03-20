using System;
using System.Linq;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class BookDAO
    {
        private List<Book> books = new List<Book>();
        private static long nextId = 1;

        public Book AddBook(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
            return book;
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(long bookId)
        {
            var book = books.Where(b => b.Id == bookId).FirstOrDefault();
            if (book == null)
            {
                throw new ArgumentException($"No book found with id {bookId}");
            }
            return book;
        }
    }
}
