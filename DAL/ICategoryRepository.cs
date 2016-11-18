using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category Category);
        void Save();
    }
}
