using System;

namespace LibraryConsoleApplication
{
    class LibraryView
    {
        private readonly BookService bookService;
        private bool finished;

        public LibraryView(BookService bookService)
        {
            this.bookService = bookService;
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
            Console.WriteLine("help        prints this message");
            Console.WriteLine("add book    adds a book");
            Console.WriteLine("show books  shows all books");
            Console.WriteLine("quit        quits this application");
        }

        private void Quit()
        {
            finished = true;
        }

        private void AddBook()
        {
            Console.WriteLine("Enter the title of the book:");
            var book = Console.ReadLine();
            try
            {
                bookService.AddBook(book);
                Console.WriteLine("Book has been added");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add book: {e.Message}");
            }
        }

        private void ShowBooks()
        {
            Console.WriteLine("Books:");
            foreach (string book in bookService.GetBooks())
            {
                Console.WriteLine($"- {book}");
            }
        }
    }
}
