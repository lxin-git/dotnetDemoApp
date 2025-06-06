using DemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}