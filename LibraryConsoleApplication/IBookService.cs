using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    interface IBookService
    {
        Book AddBook(Book book);
        BorrowedBook Borrow(Book book, User user);
        List<Book> GetBooks();
        Book GetBookById(long bookId);
        IEnumerable<BorrowedBook> GetBorrowedBooks();
    }
}