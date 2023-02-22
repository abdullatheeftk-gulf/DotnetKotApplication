using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        public readonly DataContext _context;
        public TableController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddTable(TableRequestDto tableRequestDto)
        {
            try
            {
                var table = new Table
                {
                    Name = tableRequestDto.Name,
                    FloorId = tableRequestDto.FloorId
                };
                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, table.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}