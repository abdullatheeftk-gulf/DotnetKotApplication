using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetKotApplication.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> option):base(option)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Chair> Chairs { get; set; }
    }
}