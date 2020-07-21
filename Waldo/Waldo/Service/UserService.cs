using Waldo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            List<User> lsUsers = new List<User>();

            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users");
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                User s = null;

                while (reader.Read())
                {
                    s = new User();
                    s.Username = reader["Username"].ToString();
                    s.Password = reader["Password"].ToString();
                    lsUsers.Add(s);
                }
            }

            db.Close();

            return lsUsers;
       }

        public User GetUser(int UserId)
        {
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserId = @UserId");
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@UserId", DbType = System.Data.DbType.Int32, Value = UserId });

            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                if (reader.Read())
                {
                    User s = new User();
                    s.Username = reader["Username"].ToString();
                    s.Password = reader["Password"].ToString();
                    db.Close();
                    return s;
                }
            }

            db.Close();

            return null;
        }

        public Boolean AddUser(User newUser)
        {
            //int count = users.Count;
            ////User x = new User();
            ////x.Username = username;
            ////x.Password = password;
            ////users.Add(x);

            //users.Add(newUser);
            //if (users.Count > count)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            string user = newUser.Username;
            string pass = newUser.Password;

            using (SqlConnection db = new SqlConnection())
            {
                db.ConnectionString = "Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                db.Open();

                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM Users WHERE Username = @Name) INSERT INTO Users(Username, Password) VALUES(@Name, @Pass)");
                cmd.Connection = db;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", DbType = System.Data.DbType.String, Value = user });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Pass", DbType = System.Data.DbType.String, Value = pass });
                cmd.ExecuteNonQuery();
            }

            return true;
        }
    }
}
