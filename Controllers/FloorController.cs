using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorController : ControllerBase
    {
        private readonly DataContext _context;
        public FloorController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddFloorController(FloorRequestDto floorRequestDto)
        {
            try
            {
                var floor = new Floor
                {
                    Name = floorRequestDto.Name,
                    Vat = floorRequestDto.Vat
                };
                _context.Floors.Add(floor);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, floor.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFloors()
        {
            try
            {
                var floors = await _context.Floors.ToListAsync();
                var floorResponseDtos = new List<FloorResponseDto>();
                foreach (var item in floors)
                {
                    var floorResponseDto = new FloorResponseDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Vat = item.Vat
                    };
                    floorResponseDtos.Add(floorResponseDto);
                }
                return Ok(floorResponseDtos);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("getTables/{id}")]
        public async Task<IActionResult> GetTablesOfAFloor(int id)
        {
            try
            {
                var tables = await _context.Tables.Where(t=>t.FloorId==id).ToListAsync();
                var floorTableDtos = new List<FloorTablesDto>();
                foreach(var item in tables)
                {
                    var floorTablesDto = new FloorTablesDto
                    {
                      Id = item.Id,
                      Name = item.Name,
                      NumberOfChair = item.FloorId,
                      IsReserved = item.IsReserved,
                      FloorId = item.FloorId
                    };
                    floorTableDtos.Add(floorTablesDto);
                }
                return Ok(floorTableDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}