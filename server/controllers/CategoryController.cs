using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.models;
using server.services;

namespace server.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult getAllCategories()
        {
            Console.WriteLine("hygygbuhyfyfuyh");
            IEnumerable<Category> categories = _categoryService.getAllGiftCategories();
            if (categories != null)
                return Ok(categories);
            return BadRequest(categories);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult getCategoryById(int id)
        {
            var category = _categoryService.getCategoryById(id);
            if (category != null)
                return Ok(category);
            return BadRequest(category);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult createCategory([FromBody] Category category)
        {
            Category? newcategory = _categoryService.createCategory(category);
            if (newcategory != null)
                return Ok(newcategory);
            return BadRequest(newcategory);
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult updateCategory([FromBody] Category category)
        {
            Category? updateCategory = _categoryService.updateCategory(category);
            if (updateCategory != null)
                return Ok(updateCategory);
            return BadRequest(updateCategory);
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public void deleteCategory(int id)
        {
            _categoryService.deleteCategory(id);
        }
    }
}
