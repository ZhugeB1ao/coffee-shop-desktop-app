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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            User user = repo.GetUserByUserName(username);
            
            if (user != null)
            {
                // First attempt: Verify using BCrypt.
                try
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                        return user;
                }
                catch
                {
                    // If the stored password is not a valid BCrypt hash, 
                    // this exception is expected. We proceed to the fallback check.
                }

                // Second attempt: Fallback to plain text comparison (Legacy support).
                if (user.Password == password)
                {
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

        // Partial update for Account Management: Role and Password.
        public void UpdateAccount(int id, string role, string password)
        {
            string hashedPassword = null;
            if (!string.IsNullOrEmpty(password) && password != "********")
            {
                hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            }
            else
            {
                // If password is empty or hidden, we fetch the old one to avoid overwriting with null/empty.
                // However, the DAO method we wrote updates the field. 
                // Let's refine the logic to only update password if provided.
                User oldUser = repo.GetAll().FirstOrDefault(u => u.Id == id);
                hashedPassword = oldUser?.Password;
            }
            repo.UpdateAccount(id, role, hashedPassword);
        }

        // Partial update for User Information: personal details (excludes password/role).
        public void UpdatePersonalInfo(User user)
        {
            repo.UpdatePersonalInfo(user);
        }

        // Deletes a user.
        public void Delete(int id) => repo.Delete(id);

        // Searches for users by name.
        public List<User> Search(string keyword) => repo.Search(keyword);
    }
}
