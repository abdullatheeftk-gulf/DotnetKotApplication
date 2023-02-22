using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Stock { get; set; }
        public string Remark { get; set; } = string.Empty;
        public List<int> Categories { get; set; } = new();
    }
}