using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; } = 0f;
        public float Stock { get; set; } = 0f;
        public string Remark { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = new();
    }
}