using Microsoft.EntityFrameworkCore;
using study_together_api.Entities;

namespace study_together_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<DataContextException> Exceptions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        
    }
}