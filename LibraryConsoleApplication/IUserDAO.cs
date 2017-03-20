using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    interface IUserDAO
    {
        User AddUser(User user);
        List<User> GetUsers();
        User GetUserById(long userId);
    }
}