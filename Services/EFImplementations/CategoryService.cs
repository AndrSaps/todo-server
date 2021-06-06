using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataLayer.Entityes;
using ToDo.Repository;
using ToDo.Services.Interfaces;

namespace ToDo.Services.EFImplementations
{
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<CategoryModel> categoryRepository;
        private readonly IRepository<TaskModel> taskRepository;

        public CategoryService(IRepository<CategoryModel> categoryRepository, IRepository<TaskModel> taskRepository)
        {
            this.categoryRepository = categoryRepository;
            this.taskRepository = taskRepository;
        }

        public void AddCategory(CategoryModel NewCategory)
        {
            categoryRepository.AddItem(NewCategory);
        }

        public Boolean DeleteCategory(int CategoryToDelete)
        {
            CategoryModel TempCategory = categoryRepository.GetItemById(CategoryToDelete);
            foreach (TaskModel task in taskRepository.GetAll())
            {
                if (task.CategoryID == CategoryToDelete)
                {
                    return false;
                }
            }
            categoryRepository.DeleteItem(TempCategory);
            return true;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public CategoryModel GetCategory(int CategoryID)
        {
            if (CategoryID != 0)
            {
                return categoryRepository.GetItemById(CategoryID);
            }
            else return null;
        }

        public void UpdateCategory(CategoryModel NewCategory)
        {
            categoryRepository.UpdateItem(NewCategory);
        }
    }
}
