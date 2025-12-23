using CoffeeShop.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing product categories.
    /// </summary>
    internal class CategoryRepository : BaseRepository
    {
        // Retrieves all active categories.
        public List<Category> GetAll()
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = "SELECT * FROM Categories WHERE Enable = 1";
                return connection.Query<Category>(sql).ToList();
            }
        }

        // Finds a category by its exact name.
        public Category GetByName(string name)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = "SELECT * FROM Categories WHERE Name = @name AND Enable = 1";
                return connection.QueryFirstOrDefault<Category>(sql, new { name });
            }
        }

        // Adds a new category (Enable defaults to 1).
        public void Add(Category category)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = @"INSERT INTO Categories (Name, Enable)
                               VALUES (@Name, 1)";
                connection.Execute(sql, new { category.Name });
            }
        }

        // Updates the name of a category.
        public void Update(Category category)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = @"UPDATE Categories
                               SET Name = @Name
                               WHERE Id = @Id";
                connection.Execute(sql, new
                {
                    category.Id,
                    category.Name
                });
            }
        }

        // Deletes a category (soft delete).
        public void Delete(int categoryId)
        {
            using (SqlConnection connection = CreateConnection())
            {
                string sql = @"UPDATE Categories SET Enable = 0 WHERE Id = @Id";
                connection.Execute(sql, new { Id = categoryId });
            }
        }
    }
}
