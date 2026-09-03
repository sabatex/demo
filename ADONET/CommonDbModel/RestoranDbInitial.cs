using ADONETDemoFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDbModel
{
    public class RestoranDbInitial:DbContext
    {
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<ClientTableWaiter> ClientTableWaiters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<OrderItem>();
            modelBuilder.Entity<Waiter>().HasData(new Waiter[] 
            { 
                new Waiter { Id = 1, Name = "Іван", Password = "1" }, 
                new Waiter { Id = 2, Name = "Piter", Password = "2"} 
            });
        }
    }
}
