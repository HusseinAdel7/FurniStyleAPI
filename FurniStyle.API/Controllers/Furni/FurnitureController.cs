using FurniStyle.Core.IServices.Furnis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurniStyle.API.Controllers.Furni
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IFurniService _furniService;

        public FurnitureController(IFurniService furniService)
        {
            _furniService = furniService;
        }
        [HttpGet("AllFurniture")]
        public async Task< IActionResult> GetAllFurniture()
        {
           var result = await _furniService.GetAllFurnisAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFurnitureById(int? id)
        {
            if (id == null) BadRequest("Invalid Id");
            var product = await _furniService.GetFurniByIdAsync(id.Value);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
