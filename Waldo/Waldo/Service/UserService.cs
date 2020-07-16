using Waldo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waldo.Service
{
    public class UserService
    {
       public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            User x = new User();
            x.Username = "stang10";
            x.Password = "test1";
            users.Add(x);

            x = new User();
            x.Username = "hwaa18";
            x.Password = "test2";
            users.Add(x);

            return users;

        }

        public User GetUser(int UserId)
        {
            User x = new User();
            if (UserId == 1)
            {
                x.Username = "stang10";
                x.Password = "test1";
                return x;
            }
            if (UserId == 2)
            {
                x.Username = "hwaa18";
                x.Password = "test2";
                return x;
            }
            return null;
        }
    }
}
