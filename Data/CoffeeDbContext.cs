using Coffee_Shop2.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop2.Data
{
    public class CoffeeDbContext : DbContext
    {
        internal object Coffee;
        internal object CoffeeShop;

        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) :base(options) 
        {
            
        }
        public DbSet<Coffee> CoffeeShope { get; set; }
    }

  
}
