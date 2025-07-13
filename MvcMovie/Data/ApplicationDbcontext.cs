using Microsoft.EntityFrameworkCore;
using MvcMovie.Model;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<MvcMovie.Model.Daily> Daily { get; set; } = default!;
    }
}