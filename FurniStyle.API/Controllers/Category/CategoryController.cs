using FurniStyle.Core.IServices.Categories;
using FurniStyle.Core.IServices.Furnis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurniStyle.API.Controllers.Category
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
        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategorisAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int? id)
        {
            if (id == null) BadRequest("Invalid Id");
            var product = await _categoryService.GetCategoryByIdAsync(id.Value);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
