using Microsoft.EntityFrameworkCore;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Persistence
{
    public class SecurityTestDataContext:DbContext
    {
        public SecurityTestDataContext(DbContextOptions<SecurityTestDataContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SecurityTestDataContext).Assembly);
        }
    }
}
