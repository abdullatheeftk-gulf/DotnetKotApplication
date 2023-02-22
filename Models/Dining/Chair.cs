using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models.Dining
{
    [Index(nameof(Name),IsUnique =true)]
    public class Chair
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}