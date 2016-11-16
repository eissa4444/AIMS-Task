using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Warehouse GetCategoryById(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateWarehouse(Category Category);
        void Save();
    }
}
