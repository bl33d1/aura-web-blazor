using aura_shared.Models;
using Microsoft.EntityFrameworkCore;

namespace aura_web_api.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options): base(options)
        {

        }

        public DbSet<Order> Orders{ get; set; }
    }
}
