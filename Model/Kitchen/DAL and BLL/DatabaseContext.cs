using System;
namespace Kitchen.DAL and BLL {
	public class DatabaseContext {
		public DbSet<Storage> Storage { get; set; }

		protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			throw new System.Exception("Not implemented");
		}
		protected void OnModelCreating(ModelBuilder modelBuilder) {
			throw new System.Exception("Not implemented");
		}


	}

}
