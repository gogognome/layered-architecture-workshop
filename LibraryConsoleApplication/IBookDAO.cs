using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    interface IBookDAO
    {
        Book AddBook(Book book);
        List<Book> GetBooks();
        Book GetBookById(long bookId);
    }
}