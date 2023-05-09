using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Data
{
    public class CustomerDbContext :DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerLogin> CustomerLogin { get; set; }
    }
}
