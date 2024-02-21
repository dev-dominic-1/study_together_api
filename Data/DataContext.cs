using Microsoft.EntityFrameworkCore;
using study_together_api.Entities;

namespace study_together_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        
    }
}