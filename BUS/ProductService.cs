using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System.Collections.Generic;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling product logic.
    /// </summary>
    internal class ProductService
    {
        ProductRepository repo;

        public ProductService()
        {
            repo = new ProductRepository();
        }

        // Retrieves all products.
        public List<Product> GetAll() => repo.GetAll();

        // Retrieves products by category.
        public List<Product> GetAllByCategoryID(int categoryId) => repo.GetAllByCategoryID(categoryId);
        
        // Retrieves product details by ID.
        public Product GetByID(int id) => repo.GetByID(id);
        
        // Retrieves a product by name.
        public Product GetByName(string name) => repo.GetByName(name);
        
        // Checks if a product name already exists.
        public bool IsNameExists(string name) => repo.GetByName(name) != null;
        
        // Adds a new product.
        public void Add(Product product) => repo.Add(product);

        // Updates product information.
        public void Update(Product product) => repo.Update(product);

        // Deletes a product.
        public void Delete(int id) => repo.Delete(id);

        // Searches for products.
        public List<Product> Search(string keyword) => repo.Search(keyword);
    }
}
