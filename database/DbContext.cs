using Microsoft.EntityFrameworkCore;
using rf;
using YourProjectName.Models;

namespace YourProjectName.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<db_products> db_products { get; set; }
        public DbSet<db_category> db_category { get; set; }
    }
}