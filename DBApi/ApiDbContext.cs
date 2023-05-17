using Formula.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula.App.Database
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Driver>? Drivers { get; set; }
    }
}