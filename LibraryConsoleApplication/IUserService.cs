using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    interface IUserService
    {
        User AddUser(User user);
        List<User> GetUsers();
        User GetUserById(long userId);
    }
}