using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetKotApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryDto.Name
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, category.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategoryById(int id)
        {
            try
            {
                var categoryWithProducts = await _context.Categories.Where(c => c.Id == id).Include(c => c.Products).FirstAsync();
                var categoryResponseDto = new CategoryResponseDto()
                {
                    Id = categoryWithProducts.Id,
                    Name = categoryWithProducts.Name,
                    Products = categoryWithProducts.Products
                };
                return Ok(categoryResponseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateACategory([FromBody] CategoryDto categoryDto, int id)
        {
            try
            {
                var category = await _context.Categories.Where(c => c.Id == id).FirstAsync();
                category.Name = categoryDto.Name;
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteACategory(int id)
        {
            try
            {
                var category = await _context.Categories.Where(c => c.Id == id).FirstAsync();
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}