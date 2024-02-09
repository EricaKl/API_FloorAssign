using API_FloorAssign.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API_FloorAssign.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<UserDetails> User { get; set; }
        public DbSet<UserRegistration> UserRegistration { get; set; }
    }
}
