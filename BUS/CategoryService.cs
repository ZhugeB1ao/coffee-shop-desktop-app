using CoffeeShop.DAO;
using CoffeeShop.DTO;
using System.Collections.Generic;

namespace CoffeeShop.BUS
{
    /// <summary>
    /// Service class for handling product category logic.
    /// </summary>
    internal class CategoryService
    {
        private CategoryRepository repo;

        public CategoryService()
        {
            repo = new CategoryRepository();
        }

        // Retrieves all categories.
        public List<Category> GetAll() => repo.GetAll();

        // Finds a category by its exact name.
        public Category GetByName(string name) => repo.GetByName(name);
        
        // Checks if a category name already exists.
        public bool IsNameExists(string name) => repo.GetByName(name) != null;

        // Adds a new category.
        public void Add(Category category) => repo.Add(category);

        // Updates category information.
        public void Update(Category category) => repo.Update(category);

        // Deletes a category.
        public void Delete(int categoryId) => repo.Delete(categoryId);

        public List<Category> FindByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            keyword = keyword.Trim().ToLower();

            List<Category> all = repo.GetAll();

            return all
                .FindAll(c => c.Name != null &&
                              c.Name.ToLower().Contains(keyword));
        }
    }
}
