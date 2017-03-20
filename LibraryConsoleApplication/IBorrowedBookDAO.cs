using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    interface IBorrowedBookDAO
    {
        BorrowedBook AddBorrowedBook(BorrowedBook borrowedBook);
        List<BorrowedBook> GetBorrowedBooks();
    }
}