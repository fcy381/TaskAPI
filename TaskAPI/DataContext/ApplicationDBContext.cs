using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Azure.Core.HttpHeader;

namespace TaskAPI.DataContext
{
    public class ApplicationDBContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Entities.Task> Tasks { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Entities.Task>().HasData(
                    new Entities.Task()
                    {
                        id = 1,
                        title = "Create Proyect",
                        description = "The reason to this development is to support a KANBAN board.",
                        creationDate = "12-12-2022",
                        statusUpdateDate = "12-12-2022",
                        author = "Sebastián Montemaggiore",
                        condition = "En espera",
                    },
                    new Entities.Task()
                    {
                        id = 2,
                        title = "Create Minimal API",
                        description = "The reason to this development is to support a KANBAN board.",
                        creationDate = "12-12-2022",
                        statusUpdateDate = "12-12-2022",
                        author = "Sebastián Montemaggiore",
                        condition = "En espera",
                    });
            }
        }
    }
}
