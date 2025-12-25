using CoffeeShop.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing data operations for the Users table.
    /// </summary>
    internal class UserRepository : BaseRepository
    {
        // Retrieves user information by username.
        public User GetUserByUserName(string userName)
        {
            string sql = "SELECT * FROM Users WHERE UserName = @UserName";
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                return conn.QueryFirstOrDefault<User>(sql, new { UserName = userName });
            }
        }

        // Checks login credentials (used for plain-text password fallback or legacy checks).
        public User Login(string userName, string password)
        {
            string sql = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                return conn.QueryFirstOrDefault<User>(sql, new { UserName = userName , Password = password});
            }
        }

        // Retrieves a list of all users in the system.
        public List<User> GetAll()
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Users";
                return connection.Query<User>(sql).ToList();
            }
        }

        // Adds a new user to the database.
        public void Add(User user)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"INSERT INTO Users (UserName, DisplayName, Password, Role, CitizenId, Birthday, PhoneNumber, Picture)
                               VALUES (@UserName, @DisplayName, @Password, @Role, @CitizenId, @Birthday, @PhoneNumber, @Picture)";
                connection.Execute(sql, user);
            }
        }

        // Updates an existing user's information.
        public void Update(User user)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"UPDATE Users
                               SET UserName = @UserName,
                                    DisplayName = @DisplayName,
                                    Password = @Password,
                                    Role = @Role,
                                    CitizenId = @CitizenId,
                                    Birthday = @Birthday,
                                    PhoneNumber = @PhoneNumber,
                                    Picture = @Picture
                               WHERE Id = @Id";
                connection.Execute(sql, user);
            }
        }

        // Only updates Role and Password (used in Account Management).
        public void UpdateAccount(int id, string role, string password)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"UPDATE Users
                               SET Role = @role,
                                   Password = @password
                               WHERE Id = @id";
                connection.Execute(sql, new { id, role, password });
            }
        }

        // Updates personal information: DisplayName, CitizenId, Birthday, PhoneNumber.
        // Excludes Role, Picture, and Password.
        public void UpdatePersonalInfo(User user)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"UPDATE Users
                               SET DisplayName = @DisplayName,
                                   CitizenId = @CitizenId,
                                   Birthday = @Birthday,
                                   PhoneNumber = @PhoneNumber
                               WHERE Id = @Id";
                connection.Execute(sql, user);
            }
        }

        // Deletes a user from the system by ID.
        public void Delete(int id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "DELETE FROM Users WHERE Id = @id";
                connection.Execute(sql, new { id });
            }
        }

        // Searches for users by keyword (username).
        public List<User> Search(string keyword)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"SELECT * FROM Users 
                               WHERE UserName LIKE '%' + @keyword + '%'";
                return connection.Query<User>(sql, new { keyword }).ToList();
            }
        }
    }
}
