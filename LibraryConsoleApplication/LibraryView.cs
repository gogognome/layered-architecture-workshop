using System;

namespace LibraryConsoleApplication
{
    class LibraryView : ILibraryView
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private bool finished;

        public LibraryView(IBookService bookService, IUserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        public void MainLoop()
        {
            PrintHelpMessage();
            while (!finished)
            {
                Console.WriteLine("Enter a command:");
                var command = Console.ReadLine();
                HandleCommand(command);
            }
        }

        public void HandleCommand(string command)
        {
            switch (command)
            {
                case "add book":
                    AddBook();
                    break;

                case "show books":
                    ShowBooks();
                    break;

                case "add user":
                    AddUser();
                    break;

                case "show users":
                    ShowUsers();
                    break;

                case "borrow book":
                    BorrowBook();
                    break;

                case "show borrowed books":
                    ShowBorrowedBooks();
                    break;

                case "quit":
                    Quit();
                    break;

                default:
                    PrintHelpMessage();
                    break;
            }
        }

        private void PrintHelpMessage()
        {
            Console.WriteLine("help                 prints this message");
            Console.WriteLine("add book             adds a book");
            Console.WriteLine("show books           shows all books");
            Console.WriteLine("add user             adds a user");
            Console.WriteLine("show users           shows all users");
            Console.WriteLine("borrow book          let a user borrow a book");
            Console.WriteLine("show borrowed books  shows borrowed books");
            Console.WriteLine("quit                 quits this application");
        }

        private void Quit()
        {
            finished = true;
        }

        private void AddBook()
        {
            var book = new Book();
            Console.WriteLine("Enter the title of the book:");
            book.Title = Console.ReadLine();
            Console.WriteLine("Enter the author of the book:");
            book.Author = Console.ReadLine();
            try
            {
                book = bookService.AddBook(book);
                Console.WriteLine($"Book has been added and received id {book.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add book: {e.Message}");
            }
        }

        private void ShowBooks()
        {
            Console.WriteLine("Books:");
            foreach (var book in bookService.GetBooks())
            {
                Console.WriteLine($"- {book.Id}: {book.Author}, {book.Title}");
            }
        }

        private void AddUser()
        {
            var user = new User();
            Console.WriteLine("Enter the name of the user:");
            user.Name = Console.ReadLine();
            try
            {
                user = userService.AddUser(user);
                Console.WriteLine($"User has been added and received id {user.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add user: {e.Message}");
            }
        }

        private void ShowUsers()
        {
            Console.WriteLine("USers:");
            foreach (var user in userService.GetUsers())
            {
                Console.WriteLine($"- {user.Id}: {user.Name}");
            }
        }

        private void BorrowBook()
        {
            try
            {
                ShowBooks();
                Console.WriteLine("Enter the id of the book that is borrowed:");
                var bookId = Console.ReadLine();
                var book = bookService.GetBookById(long.Parse(bookId));

                ShowUsers();
                Console.WriteLine($"Enter the id of the user that borrowed the book: {book.Title}");
                var userId = Console.ReadLine();
                var user = userService.GetUserById(long.Parse(userId));

                var borrowedBook = bookService.Borrow(book, user);
                Console.WriteLine($"Book is borrowed at {borrowedBook.BorrowedAt:dd-MM-yyyy} and is due at {borrowedBook.DueDate:dd-MM-yyyy}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add borrowed book: {e.Message}");
            }
        }

        private void ShowBorrowedBooks()
        {
            foreach (var borrowedBook in bookService.GetBorrowedBooks())
            {
                var book = bookService.GetBookById(borrowedBook.BookID);
                var user = userService.GetUserById(borrowedBook.UserID);
                Console.WriteLine($"- {user.Name} borrowed {book.Title} at {borrowedBook.BorrowedAt:dd-MM-yyyy} which is due at {borrowedBook.DueDate:dd-MM-yyyy}");
            }
        }
    }
}
