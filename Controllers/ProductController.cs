using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotnetKotApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductDto productDto)
        {
            try
            {
                var product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                    Remark = productDto.Remark
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                foreach (var item in productDto.Categories)
                {
                    var category = await _context.Categories.Where(c => c.Id == item).FirstAsync();
                    category.Products.Add(product);
                }
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, product.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneProductById(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id).Include(p => p.Categories).FirstAsync();
            var productResponseDto = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Remark = product.Remark,
                Categories = product.Categories
            };
            return Ok(productResponseDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAProduct([FromBody] ProductDto productDto, int id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).Include(p => p.Categories).FirstAsync();
                product.Categories.Clear();
                await _context.SaveChangesAsync();
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Stock = productDto.Stock;
                product.Remark = productDto.Remark;
                await _context.SaveChangesAsync();
                var categories = productDto.Categories;
                foreach (var item in categories)
                {
                    var category = await _context.Categories.Where(c => c.Id == item).FirstAsync();
                    category.Products.Add(product);
                }
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getOneByName/{name}")]
        public async Task<IActionResult> SearchAProductByName(string name)
        {
            try
            {
                var product = await _context.Products.Where(p => EF.Functions.Like(p.Name,$"%{name}%")).ToListAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getOneByNameForEditing/{name}")]
        public async Task<IActionResult> SearchAProductByNameForEditing(string name)
        {
            try
            {
                var product = await _context.Products.Where(p => EF.Functions.Like(p.Name,$"%{name}%")).Include(p=>p.Categories).ToListAsync();
                var productResponseDtos = new List<ProductResponseDto>();
                foreach(var item in product){
                    var productResponseDto = new ProductResponseDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Stock = item.Stock,
                        Remark = item.Remark,
                        Categories = item.Categories
                    };
                    productResponseDtos.Add(productResponseDto);
                }
                return Ok(productResponseDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAProduct(int id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstAsync();
                _context.Products.Remove(product);
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