using System;
using System.Linq;
using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class UserDAO
    {
        private List<User> users = new List<User>();
        private static long nextId = 1;

        public User AddUser(User user)
        {
            user.Id = nextId++;
            users.Add(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User GetUserById(long userId)
        {
            var user = users.Where(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentException($"No user found with id {userId}");
            }
            return user;
        }
    }
}
