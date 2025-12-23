using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling user-related logic (authentication, password encryption).
    /// </summary>
    internal class UserService
    {
        UserRepository repo;
        public UserService()
        {
            repo = new UserRepository();
        }

        /// <summary>
        /// Handles login, supporting both legacy passwords (plain text) and new ones (BCrypt).
        /// </summary>
        public User Login(string username, string password)
        {
            User user = repo.GetUserByUserName(username);
            
            if (user != null)
            {
                try
                {
                    // Verify password using the BCrypt library.
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                        return user;
                }
                catch
                {
                    // If not a BCrypt hash (legacy data), perform a direct comparison.
                    if (user.Password == password)
                        return user;
                }
            }
            return null;
        }

        // Retrieves a list of all users.
        public List<User> GetAll() => repo.GetAll();

        // Adds a new employee (automatically hashes the password before saving).
        public void Add(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            repo.Add(user);
        }

        // Updates information (only re-hashes if the password has been changed).
        public void Update(User user)
        {
            if (!string.IsNullOrEmpty(user.Password) && user.Password != "********")
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }
            repo.Update(user);
        }

        // Deletes a user.
        public void Delete(int id) => repo.Delete(id);

        // Searches for users by name.
        public List<User> Search(string keyword) => repo.Search(keyword);
    }
}
