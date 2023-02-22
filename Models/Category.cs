using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; } = new();
    }
}