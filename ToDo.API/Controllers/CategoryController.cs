using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDo.DataLayer.Entityes;
using ToDo.Services.Interfaces;

namespace ToDo.API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> GetCategories()
        {
            return categoryService.GetCategories().ToList();
        }

        [HttpGet("{id}")]
        public CategoryModel GetCategory(int CategoryID)
        {
            return categoryService.GetCategory(CategoryID);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CategoryModel NewCategory)
        {
            if (ModelState.IsValid)
            {
                categoryService.AddCategory(NewCategory);
                return Ok(NewCategory);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{CategoryId}")]
        public IActionResult DeleteCategory(int CategoryId)
        {

            if (categoryService.DeleteCategory(CategoryId))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCategory(int Id,string Name,string Color)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            CategoryModel categoryModel = categoryService.GetCategory(Id);
            if (categoryModel == null)
            {
                return BadRequest();
            }
            CategoryModel NewCategory = new CategoryModel
            {
                ID = Id,
                Name = Name,
                Color = Color
            };


            if (ModelState.IsValid)
            {
                categoryService.UpdateCategory(NewCategory);
                return Ok(NewCategory);
            }
            return BadRequest(ModelState);
        }
    }
}