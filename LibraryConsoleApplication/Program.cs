using System;

namespace LibraryConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookDao = new BookDAO();
            var bookService = new BookService(bookDao);
            var libraryView = new LibraryView(bookService);

            AddSampleBooks(bookDao);

            libraryView.MainLoop();
        }

        private static void AddSampleBooks(BookDAO bookDao)
        {
            foreach (string book in new[] { "Harry Potter and the Philosopher's Stone", "Good Omens", "Rita Hayworth and Shawshank Redemption" })
            {
                bookDao.AddBook(book);
            }
        }
    }
}
