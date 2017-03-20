using System;

namespace LibraryConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookDao = new BookDAO();
            var userDao = new UserDAO();
            var borrowedBookDao = new BorrowedBookDAO();

            var bookService = new BookService(bookDao, borrowedBookDao);
            var userService = new UserService(userDao);
            var libraryView = new LibraryView(bookService, userService);

            AddSampleBooks(bookDao);
            AddSampleUsers(userDao);

            libraryView.MainLoop();
        }
 
        private static void AddSampleBooks(IBookDAO bookDao)
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

        private static void AddSampleUsers(IUserDAO userDao)
        {
            foreach (string user in new[] { "Piet Puk", "Jan Jansen" })
            {
                userDao.AddUser(new User { Name = user });
            }
        }

    }
}
