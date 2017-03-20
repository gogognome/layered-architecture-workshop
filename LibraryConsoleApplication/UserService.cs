using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApplication
{
    class UserService
    {
        private readonly UserDAO userDao;

        public UserService(UserDAO userDao)
        {
            this.userDao = userDao;
        }

        public User AddUser(User user)
        {
            Validate(user);
            return userDao.AddUser(user);
        }

        private static void Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                throw new ArgumentException("Name must be filled in", "user");
            }
        }

        public List<User> GetUsers()
        {
            return userDao.GetUsers();
        }

        public User GetUserById(long userId)
        {
            return userDao.GetUserById(userId);
        }
    }
}
