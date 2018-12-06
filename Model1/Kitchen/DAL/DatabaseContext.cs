using Microsoft.EntityFrameworkCore;

namespace Model.Kitchen.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<StorageDao> Storage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            throw new System.Exception("Not implemented");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new System.Exception("Not implemented");
        }


    }

}
