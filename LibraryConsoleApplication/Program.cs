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
            foreach (string book in new[] { "J.K. Rowling/Harry Potter and the Philosopher's Stone", "Terry Pratchett & Neil Gaiman/Good Omens", "Stephen King/Rita Hayworth and Shawshank Redemption" })
            {
                bookDao.AddBook(new Book
                {
                    Author = book.Split('/')[0],
                    Title = book.Split('/')[1]
                });
            }
        }
    }
}
