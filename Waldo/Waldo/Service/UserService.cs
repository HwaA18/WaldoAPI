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

        public List<User> GetUsers()
        {
            //Create a list of User objects
            List<User> lsUsers = new List<User>();

            //Establish connection to our SQL Database, selects all users from the table, and allows us to read what is returned
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users");
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            //If any information is returned by the User table, a user object is created with the information
            //from the database columns and added to the list
            if (reader != null)
            {
                User s = null;

                while (reader.Read())
                {
                    s = new User();
                    s.Username = reader["Username"].ToString();
                    s.Password = reader["Password"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    s.Address = reader["Address"].ToString();
                    lsUsers.Add(s);
                }
            }

            //The connection to the database is closed and the list of users is returned
            db.Close();

            return lsUsers;
        }

        public User GetUser(int UserId)
        {
            //Establish connection to our SQL Database, selects the user with the id variable from the user table, and allows us to read what is returned
            SqlConnection db =
                new SqlConnection("Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            db.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserId = @UserId");
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@UserId", DbType = System.Data.DbType.Int32, Value = UserId });
            cmd.Connection = db;
            SqlDataReader reader = cmd.ExecuteReader();

            //If a user is returned by the table, its information from the columns is recorded, the database connection is closed, and the user is returned
            if (reader != null)
            {
                if (reader.Read())
                {
                    User s = new User();
                    s.Username = reader["Username"].ToString();
                    s.Password = reader["Password"].ToString();
                    s.FirstName = reader["FirstName"].ToString();
                    s.LastName = reader["LastName"].ToString();
                    s.Address = reader["Address"].ToString();
                    db.Close();
                    return s;
                }
            }

            //If no user is returned by the table, the database connection is closed and null is returned
            db.Close();

            return null;
        }

        public Boolean AddUser(User newUser)
        {
            //The fields of the supplied user are obtained
            string user = newUser.Username;
            string pass = newUser.Password;
            string first = newUser.FirstName;
            string last = newUser.LastName;
            string address = newUser.Address;

            //A connection to our SQL Database is opened
            using (SqlConnection db = new SqlConnection())
            {
                db.ConnectionString = "Server=tcp:waldoserver.database.windows.net,1433;Initial Catalog=waldo;Persist Security Info=False;User ID=waldo;Password=1234@terp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                db.Open();

                //If there is not a current user with the fields of the entered user, it is created using the supplied parameters
                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM Users WHERE Username = @Name) " +
                    "INSERT INTO Users(Username, Password, FirstName, LastName, Address) VALUES(@Name, @Pass, @First, @Last, @Address)");
                cmd.Connection = db;
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Name", DbType = System.Data.DbType.String, Value = user });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Pass", DbType = System.Data.DbType.String, Value = pass });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@First", DbType = System.Data.DbType.String, Value = first });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Last", DbType = System.Data.DbType.String, Value = last });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Address", DbType = System.Data.DbType.String, Value = address });
                cmd.ExecuteNonQuery();
            }

            //true is returned upon successful query
            return true;
        }
    }
}
