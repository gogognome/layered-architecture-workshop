using System;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class BorrowedBookDAO
    {
        private List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();
        private static long nextId = 1;

        public BorrowedBook AddBorrowedBook(BorrowedBook borrowedBook)
        {
            borrowedBook.Id = nextId++;
            borrowedBooks.Add(borrowedBook);
            return borrowedBook;
        }

        public List<BorrowedBook> GetBorrowedBooks()
        {
            return borrowedBooks;
        }
    }
}
