using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MigrationRestoran
{
    public partial class RestorantContext : DbContext
    {
        public RestorantContext()
        {
        }

        public RestorantContext(DbContextOptions<RestorantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonent> Abonent { get; set; }
        public virtual DbSet<ClientCards> ClientCards { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<Waiters> Waiters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string cs = Program.Configuration.GetSection("ConnectionStrings").GetSection("PostgreConnection").Value;
                optionsBuilder.UseNpgsql(cs);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonent>(entity =>
            {
                entity.ToTable("abonent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

            modelBuilder.Entity<Details>(entity =>
            {
                entity.ToTable("details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bill)
                    .HasColumnName("bill")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ItemsId).HasColumnName("items_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detail_ToOrder");
            });

            modelBuilder.Entity<Items>(entity =>
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
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tmp_ms_x__3213E83E1B4D841E")
                    .IsClustered(false);

                entity.ToTable("order");

                entity.HasIndex(e => e.TimeOrder);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbonentId).HasColumnName("abonent_id");

                entity.Property(e => e.Bill)
                    .HasColumnName("bill")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EndOrder)
                    .HasColumnName("end_order")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceId).HasColumnName("source_id");

                entity.Property(e => e.TimeOrder)
                    .HasColumnName("time_order")
                    .HasColumnType("datetime");

                entity.Property(e => e.WaiterId).HasColumnName("waiter_id");
            });

            modelBuilder.Entity<Sources>(entity =>
            {
                entity.ToTable("sources");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Waiters>(entity =>
            {
                entity.ToTable("waiters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
