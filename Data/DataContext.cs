using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using study_together_api.Entities;

namespace study_together_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure table bindings here
            // `Post` bindings
            EntityTypeBuilder<Post> post = modelBuilder.Entity<Post>();
            post.HasOne(p => p.User).WithMany(u => u.Posts).OnDelete(DeleteBehavior.Cascade);
            // `Friend` bindings
            EntityTypeBuilder<Friend> friend = modelBuilder.Entity<Friend>();
            friend.HasKey(f => new { f.UserId, f.FriendUserId });
            friend.HasOne(f => f.User).WithMany(u => u.Friends).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<DataContextException> Exceptions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Friend> Friends { get; set; }
        
    }
}