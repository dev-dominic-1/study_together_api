using Microsoft.EntityFrameworkCore;
using study_together_api.Entities;

namespace study_together_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Friend>().HasKey(f => new { f.UserId, f.FriendUserId });
        }

        public DbSet<DataContextException> Exceptions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Friend> Friends { get; set; }
        
    }
}