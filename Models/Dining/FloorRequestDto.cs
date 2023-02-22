using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Models.Dining
{
    public class FloorRequestDto
    {
        public string Name { get; set; }
        public float Vat { get; set; } = 0f;
    }
}