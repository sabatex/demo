using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestoranClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestoranClient.Data
{
    public class RestoranDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Abonent> Abonent { get; set; }
        //public DbSet<SourceItem> Sources { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql(Config.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            optionsBuilder.UseSqlServer("Data Source=192.168.10.20;Initial Catalog=RestorantNew;Persist Security Info=True;User ID=sa;Password=Aa12345678");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Abonent>(entity =>
            {
                entity.ToTable("abonent");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.HasData(new Abonent { Id = 1, Name = "table 1" },
                new Abonent { Id = 2, Name = "table 2" },
                new Abonent { Id = 3, Name = "table 3" },
                new Abonent { Id = 4, Name = "table 4" });

            });
            modelBuilder.Entity<ClientCards>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(18, 2)");
                entity.HasData(
                    new FoodItem { Name = "Bear", Price = 45.00M, Id = 1 },
                    new FoodItem { Name = "Borch", Price = 50.00M, Id = 2 },
                    new FoodItem { Name = "bread", Price = 5.00M, Id = 3 },
                    new FoodItem { Name = "Chicken soup", Price = 45.00M, Id = 4 },
                    new FoodItem { Name = "chicken with poatoes", Price = 95.00M, Id = 5 },
                    new FoodItem { Name = "Coca Cola", Price = 40.00M, Id = 6 },
                    new FoodItem { Name = "Cofee", Price = 25.00M, Id = 7 },
                    new FoodItem { Name = "Duck soup", Price = 45.00M, Id = 8 },
                    new FoodItem { Name = "IceCream", Price = 50.00M, Id = 9 },
                    new FoodItem { Name = "ketchup", Price = 300.00M, Id = 10 },
                    new FoodItem { Name = "pizza", Price = 95.00M, Id = 11 },
                    new FoodItem { Name = "Salad", Price = 100.00M, Id = 12 },
                    new FoodItem { Name = "shashlik", Price = 300.00M, Id = 13 },
                    new FoodItem { Name = "Vodka", Price = 300.00M, Id = 14 },
                    new FoodItem { Name = "water", Price = 40.00M, Id = 15 },
                    new FoodItem { Name = "Whiskey", Price = 1000.00M, Id = 16 }
                    );


            });

            var sourceConverter = new ValueConverter<FixSource, string>(
                    v => v.ToString(),
                    v => (FixSource)Enum.Parse(typeof(FixSource), v));
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(p => p.WaiterId).HasColumnName("waiter_id");
                entity.Property(p => p.AbonentId).HasColumnName("abonent_id");
                //entity.Property(p => p.SourceId).HasColumnName("source_id");
                entity.Property(p => p.TimeOrder).HasColumnName("time_order");
                entity.Property(p => p.EndOrder).HasColumnName("end_order");
                entity.Property(p => p.FixedSource).HasConversion(sourceConverter);
                entity.HasData(new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:00:00.000"), Bill = 290.00M, Id = 1, WaiterId = 2, AbonentId = 1, FixedSource = FixSource.Kitchen, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:00:00.000"), Bill = 140.00M, Id = 4, WaiterId = 1, AbonentId = 3, FixedSource = FixSource.Kitchen, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:05:00.000"), Bill = 125.00M, Id = 5, WaiterId = 1, AbonentId = 4, FixedSource = FixSource.Bar, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:10:00.000"), Bill = 485.00M, Id = 2, WaiterId = 2, AbonentId = 2, FixedSource = FixSource.Kitchen, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:10:00.000"), Bill = 302.50M, Id = 3, WaiterId = 2, AbonentId = 2, FixedSource = FixSource.Bar, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:30:00.000"), Bill = 200.00M, Id = 7, WaiterId = 2, AbonentId = 1, FixedSource = FixSource.Kitchen, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 02 - 24 16:50:00.000"), Bill = 160.00M, Id = 6, WaiterId = 1, AbonentId = 3, FixedSource = FixSource.Bar, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 04 - 08 15:16:05.357"), Bill = 100.00M, Id = 8, WaiterId = 1, AbonentId = 1, FixedSource = FixSource.Kitchen, Paid = 0 },
new Order { TimeOrder = DateTime.Parse("2020 - 04 - 08 15:16:17.813"), Bill = 10350.00M, Id = 9, WaiterId = 1, AbonentId = 4, FixedSource = FixSource.Bar, Paid = 0 });



            });
            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(p => p.OrderId).HasColumnName("order_id");
                entity.Property(p => p.ItemsId).HasColumnName("items_id");
                entity.Property(p => p.Bill).HasColumnName("bill");
                entity.Property(p => p.Count).HasColumnName("count");
                entity.Property(p => p.Price).HasColumnName("price");
                entity.HasData(new Detail { Id = 1, ItemsId = 2, OrderId = 1, Price = 50.00M, Count = 2.000M, Bill = 100.00M },
new Detail { Id = 2, ItemsId = 8, OrderId = 2, Price = 45.00M, Count = 2.000M, Bill = 90.00M },
new Detail { Id = 3, ItemsId = 14, OrderId = 3, Price = 300.00M, Count = 0.500M, Bill = 150.00M },
new Detail { Id = 4, ItemsId = 4, OrderId = 4, Price = 45.00M, Count = 1.000M, Bill = 45.00M },
new Detail { Id = 5, ItemsId = 7, OrderId = 5, Price = 25.00M, Count = 2.000M, Bill = 50.00M },
new Detail { Id = 6, ItemsId = 7, OrderId = 5, Price = 25.00M, Count = 3.000M, Bill = 75.00M },
new Detail { Id = 7, ItemsId = 2, OrderId = 8, Price = 50.00M, Count = 2.000M, Bill = 100.00M },
new Detail { Id = 8, ItemsId = 7, OrderId = 9, Price = 25.00M, Count = 2.000M, Bill = 50.00M },
new Detail { Id = 9, ItemsId = 15, OrderId = 9, Price = 40.00M, Count = 10.000M, Bill = 400.00M },
new Detail { Id = 10, ItemsId = 13, OrderId = 9, Price = 300.00M, Count = 10.000M, Bill = 3000.00M },
new Detail { Id = 11, ItemsId = 16, OrderId = 9, Price = 1000.00M, Count = 5.000M, Bill = 5000.00M },
new Detail { Id = 12, ItemsId = 11, OrderId = 9, Price = 95.00M, Count = 20.000M, Bill = 1900.00M });

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasData(new User { Id = 1, Name = "Andrea", Password = "1111" },
                              new User { Id = 2, Name = "Suzane", Password = "2222" },
                              new User { Id = 3, Name = "Ivanka", Password = "3333" },
                              new User { Id = 4, Name = "Ruslan", Password = "4444" });
            });
            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey("UserId","Group");
                entity.HasData(new UserGroup { UserId = 1, Group = Group.Waiters },
                    new UserGroup { UserId = 2, Group = Group.Waiters },
                    new UserGroup { UserId = 3, Group = Group.Waiters },
                    new UserGroup { UserId = 4, Group = Group.Barmens },
                    new UserGroup { UserId = 3, Group = Group.Barmens });
            
            });
        }

    }
}
