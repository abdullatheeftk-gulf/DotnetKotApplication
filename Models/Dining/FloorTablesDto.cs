using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models.Dining
{
    public class FloorTablesDto
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfChair { get; set; } = 0;
        public bool IsReserved { get; set; } = false;
        public int FloorId { get; set; }
    }
}