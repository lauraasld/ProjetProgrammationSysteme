using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model.Kitchen.DAL;

namespace Model.Kitchen
{
    class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=tcp:DESKTOP-NTF3CC3,1433;initial catalog=RestoBDD;persist security info=True;Integrated Security=SSPI; user id = sa; password = root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComposeDao>().HasKey(i => new { i.ScenarioId, i.ActionId });
        }

        public DbSet<PersonDao> Person { get; set; }
        public DbSet<ActionDao> Action { get; set; }
        public DbSet<ScenarioDao> Scenario { get; set; }
        public DbSet<ComposeDao> Compose { get; set; }
    }

}
