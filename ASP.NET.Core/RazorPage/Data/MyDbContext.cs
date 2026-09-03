using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>(e =>
            {
                e.HasData(new School[]{
                    new School{
                        Id = 1,
                        Name = "School #1"
                    },
                    new School{
                        Id = 2,
                        Name = "School #2"
                    },
                    new School{
                        Id = 3,
                        Name = "School #3"
                    }
                });
            });
            modelBuilder.Entity<Student>(e =>
            {
                e.HasData(new Student[]{
                    new Student{
                        Id = 1,
                        Name = "User1",
                        SchoolId = 1
                    },
                    new Student{
                        Id = 2,
                        Name = "User2",
                        SchoolId = 1
                    },
                    new Student{
                        Id = 3,
                        Name = "User3",
                        SchoolId = 1,
                    },
                    new Student{
                        Id = 4,
                        Name = "User4",
                        SchoolId = 2
                    },
                    new Student{
                        Id = 5,
                        Name = "User5",
                        SchoolId = 2
                    },
                    new Student{
                        Id = 6,
                        Name = "User6",
                        SchoolId = 2,
                    },new Student{
                        Id = 7,
                        Name = "User7",
                        SchoolId = 3
                    },
                    new Student{
                        Id = 8,
                        Name = "User8",
                        SchoolId = 3
                    },
                    new Student{
                        Id = 9,
                        Name = "User9",
                        SchoolId = 3,
                    }
                });
            });

        }
    }
}
