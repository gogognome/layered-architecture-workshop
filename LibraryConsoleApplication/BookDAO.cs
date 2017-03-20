using System;
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

    }
}
