using System;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class BookDAO
    {
        private List<string> books = new List<string>();

        public void AddBook(string book)
        {
            books.Add(book);
        }

        public List<string> GetBooks()
        {
            return books;
        }

    }
}
