using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotnetKotApplication.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; } = 0f;
        public float Stock { get; set; } = 0f;
        public string Remark { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Category> Categories { get; set; } = new();
    }
}