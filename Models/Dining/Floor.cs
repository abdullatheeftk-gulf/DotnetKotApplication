using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models.Dining
{
    [Index(nameof(Name),IsUnique =true)]
    public class Floor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Vat { get; set; } = 0f;
        public List<Table> Tables { get; set; } = new();
    }
}