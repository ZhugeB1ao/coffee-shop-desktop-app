using CoffeeShop.DTO;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CoffeeShop.DAO
{
    /// <summary>
    /// Repository for managing data operations for the Products table.
    /// </summary>
    internal class ProductRepository : BaseRepository
    {
        // Retrieves all active products.
        public List<Product> GetAll()
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE Enable = 1";
                return connection.Query<Product>(sql).ToList();
            }
        }

        // Retrieves the list of products by category ID.
        public List<Product> GetAllByCategoryID(int categoryId)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE IdCategory = @categoryId AND Enable = 1";
                return connection.Query<Product>(sql, new { categoryId }).ToList();
            }
        }

        // Finds a product by its ID.
        public Product GetByID(int id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE Id = @id";
                return connection.QueryFirstOrDefault<Product>(sql, new { id });
            }
        }

        // Finds a product by its name.
        public Product GetByName(string name)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE Name = @name AND Enable = 1";
                return connection.QueryFirstOrDefault<Product>(sql, new { name });
            }
        }

        // Adds a new product to the menu.
        public void Add(Product product)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"INSERT INTO Products (Name, IdCategory, Price, Image, Enable)
                               VALUES (@Name, @IdCategory, @Price, @Image, 1)";
                connection.Execute(sql, product);
            }
        }

        // Updates product information (name, price, image, etc.).
        public void Update(Product product)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"UPDATE Products
                               SET Name = @Name,
                                   IdCategory = @IdCategory,
                                   Price = @Price,
                                   Image = @Image
                               WHERE Id = @Id";
                connection.Execute(sql, product);
            }
        }

        // Deletes a product (soft delete).
        public void Delete(int id)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = "UPDATE Products SET Enable = 0 WHERE Id = @id";
                connection.Execute(sql, new { id });
            }
        }

        // Searches for products by name (supports fuzzy matching).
        public List<Product> Search(string keyword)
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                string sql = @"SELECT * FROM Products 
                               WHERE Name LIKE '%' + @keyword + '%' AND Enable = 1";
                return connection.Query<Product>(sql, new { keyword }).ToList();
            }
        }
    }
}
