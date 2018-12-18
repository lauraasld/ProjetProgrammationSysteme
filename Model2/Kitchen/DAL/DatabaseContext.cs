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
            optionsBuilder.UseSqlServer(@"Server=tcp:srvresto.database.windows.net,1433;Initial Catalog=RestoBDD;Persist Security Info=False;User ID=clt_root;Password=Azerty123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
        }
        public DbSet<PersonDao> Person { get; set; }
        public DbSet<ActionDao> Action { get; set; }
        public DbSet<ScenarioDao> Scenario { get; set; }
        public DbSet<ActionsListDao> ActionsList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
