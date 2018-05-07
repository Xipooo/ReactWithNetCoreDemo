using Microsoft.EntityFrameworkCore;

namespace DemoBE.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options) : base(options){}
        public DbSet<HomePage> HomePages { get; set;}
    }
}