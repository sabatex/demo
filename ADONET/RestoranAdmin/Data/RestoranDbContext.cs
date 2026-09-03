using ADONETDemoFramework.Models;
using CommonDbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranAdmin.Data
{
    public class RestoranDbContext: DbContext
    {
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<ClientTableWaiter> ClientTableWaiters { get; set; }

        //public RestoranDbContext(DbContextOptions options):base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //    //optionsBuilder.UseMySQL(@"server=127.0.0.1;uid=root;pwd=12345;database=test");

        //    //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\\DataBases\Restor.mdf;Integrated Security=True;Connect Timeout=30");
              optionsBuilder.UseSqlite(App.Configuration.GetSection("ConnectionStrings")["sqlite"]);
        //    base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Waiter>().ToTable("Waiters", "dbo");
            modelBuilder.Entity<Order>().HasComment("Замовлення").Property(p=>p.Date).HasColumnType("date").HasPrecision(9, 2);
            modelBuilder.Entity<Order>().Property(p => p.Date).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<FoodItem>().Property(p => p.Description).HasComputedColumnSql("[Name] +  [Price]");
            modelBuilder.Entity<OrderItem>().ToTable("order_item",schema:"ddd").Ignore(f=>f.Count).Property(p=>p.Price).HasColumnName("Price");
            modelBuilder.Entity<FoodItem>().HasKey(p=>new { p.Name,p.Id }).HasName("myPrimaryKey");
            modelBuilder.Entity<FoodItem>().Property(p => p.Price).HasDefaultValue(9.99);

            modelBuilder.Entity<Waiter>().Property(d => d.Password).HasComment("Пароль в відкитому виді");
            modelBuilder.Entity<Waiter>().HasData(new Waiter[]
            {
                new Waiter {Id=1,Name="Іван",Password="1"},
                new Waiter { Id = 2, Name = "Piter", Password = "2"} 
            });
            modelBuilder.Entity<ClientTable>().HasData(new ClientTable[] { new ClientTable { Id = 1, Name = "Table 1" } });
            modelBuilder.Entity<ClientTable>().HasData(new ClientTable[] { new ClientTable { Id = 2, Name = "Table 2" } });

            modelBuilder.Entity<ClientTableWaiter>().HasOne<ClientTable>().WithMany().HasForeignKey(p=>p.ClientTableId);

            //modelBuilder.Entity<ClientTableWaiter>().HasData(new ClientTableWaiter[] { new ClientTableWaiter { Id = 1, ClientTableId = 1, WaiterId = 1 } });

        }

    }
}
