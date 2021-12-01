using hw9.Services.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace hw9.Services.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
    }
}