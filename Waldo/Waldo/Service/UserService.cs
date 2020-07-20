using Waldo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waldo.Service
{
    public class UserService
    {
       List<User> users = new List<User>();

        public UserService()
        {
            User x = new User();
            x.Username = "stang10";
            x.Password = "test1";
            users.Add(x);

            x = new User();
            x.Username = "hwaa18";
            x.Password = "test2";
            users.Add(x);
        }

        public List<User> GetUsers()
       {
            return users;
       }

        public User GetUser(int UserId)
        {
            if (UserId < users.Count)
            {
                return users[UserId];
            } else
            {
                return null;
            }
        }

        public Boolean AddUser(User newUser)
        {
            int count = users.Count;
            //User x = new User();
            //x.Username = username;
            //x.Password = password;
            //users.Add(x);

            users.Add(newUser);
            if (users.Count > count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
