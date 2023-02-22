using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models.Dining
{
    [Index(nameof(Name),IsUnique =true)]
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int NumberOfChair { get; set; } = 0;
        public bool IsReserved { get; set; } = false;
        public int FloorId { get; set; }
        public Floor Floor{ get; set; }
        public List<Chair> Chairs { get; set; } = new();
    }
}