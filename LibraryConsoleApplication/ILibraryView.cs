namespace LibraryConsoleApplication
{
    interface ILibraryView
    {
        void HandleCommand(string command);
        void MainLoop();
    }
}