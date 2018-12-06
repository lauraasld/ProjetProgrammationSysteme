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
                optionsBuilder.UseSqlServer(@"data source=tcp:DESKTOP-NTF3CC3,1433;initial catalog=BDDRestaurant;persist security info=True;Integrated Security=SSPI; user id = sa; password = root;");
            }
            public DbSet<CategoryDao> Category { get; set; }
            public DbSet<ProductDao> Product { get; set; }
            public DbSet<StorageDao> Storage { get; set; }

        }

}
