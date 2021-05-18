using farfetchQ1.Models;
using Microsoft.EntityFrameworkCore;

namespace farfetchQ1.Data
{
    public class DataContext : DbContext {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase();
        }
    
        public DbSet<Product> Products { get; set; }
    }
}