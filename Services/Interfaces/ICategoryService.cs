using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataLayer.Entityes;

namespace ToDo.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();

        CategoryModel GetCategory(int CategoryID);

        void AddCategory(CategoryModel NewCategory);

        void UpdateCategory(CategoryModel NewCategory);

        Boolean DeleteCategory(int CategoryToDelete);
    }
}
