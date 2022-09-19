using Microsoft.EntityFrameworkCore;

namespace PagosPruebaTuya.Data.Models.AplicationDb
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<OrderProduct> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.userName).IsRequired().HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.email).IsRequired().HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.pass).IsRequired().HasMaxLength(50);
                entity.HasMany(p => p.orders).WithOne(d => d.fkUser).HasForeignKey(d => d.fkUser_id).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasMany(p => p.Addresses).WithOne(d => d.fkUser).HasForeignKey(d => d.fkUser_id);
                entity.ToTable("User");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.name).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasMany(p => p.orders).WithOne(d => d.fkPaymentMethod).HasForeignKey(d => d.fkPaymentMethod_id).IsRequired(false);
                entity.ToTable("PaymentMethod");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.country).IsRequired().HasMaxLength(3);
                entity.Property(e => e.city).IsRequired().HasMaxLength(50);
                entity.Property(e => e.quarter).IsRequired().HasMaxLength(100);
                entity.Property(e => e.streetType).IsRequired();
                entity.Property(e => e.street).IsRequired().HasMaxLength(50);
                entity.Property(e => e.numberExt).IsRequired().HasMaxLength(10);
                entity.Property(e => e.numberInt).IsRequired().HasMaxLength(5);
                entity.Property(e => e.state).IsRequired().HasDefaultValueSql("(0)");
                entity.Property(e => e.created).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.createdBy).IsRequired().HasDefaultValueSql("('SystemTuyaPagos')");
                entity.Property(e => e.lastModified).HasColumnType("datetime");
                entity.HasMany(p => p.orders).WithOne(d => d.fkAddress).HasForeignKey(d => d.fkAddress_id);
                entity.ToTable("Address");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(e => e.id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.stateOrden).IsRequired().HasDefaultValueSql("(0)");
                entity.Property(e => e.price).IsRequired().HasColumnType("decimal").HasPrecision(20, 2).HasDefaultValueSql("(0)");
                entity.Property(e => e.created).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.createdBy).IsRequired().HasDefaultValueSql("('SystemTuyaPagos')");
                entity.Property(e => e.lastModified).HasColumnType("datetime");
                entity.HasMany(p => p.detailOrders).WithOne(d => d.fkOrder).HasForeignKey(d => d.fkOrder_id);
                entity.ToTable("OrderProduct");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.name).IsRequired().HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.description).IsRequired();
                entity.Property(e => e.price).IsRequired().HasColumnType("decimal").HasPrecision(20, 2).HasDefaultValueSql("(0)");
                entity.Property(e => e.created).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.createdBy).IsRequired().HasDefaultValueSql("('SystemTuyaPagos')");
                entity.Property(e => e.lastModified).HasColumnType("datetime");
                entity.HasMany(p => p.DetailOrders).WithOne(d => d.fkProduct).HasForeignKey(d => d.fkProduct_id);
                entity.ToTable("Product");
                entity.HasKey(x => x.id);

            });

            modelBuilder.Entity<DetailOrder>(entity =>
            {
                entity.Property(e => e.quantity).IsRequired();
                entity.Property(e => e.price).IsRequired().HasColumnType("decimal").HasPrecision(20, 2).HasDefaultValueSql("(0)");
                entity.Property(e => e.created).IsRequired().HasColumnType("datetime").HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.createdBy).IsRequired().HasDefaultValueSql("('SystemTuyaPagos')");
                entity.Property(e => e.lastModified).HasColumnType("datetime");
                entity.ToTable("DetailOrder");
                entity.HasKey(x => x.id);
            });
        }

    }
}
