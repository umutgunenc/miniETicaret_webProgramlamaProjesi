using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Models.Entity;


namespace miniETicaret.Data
{
    public class eTicaretDBContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public eTicaretDBContext(DbContextOptions<eTicaretDBContext> options) : base(options)
        {

        }
        public virtual DbSet<AppRole> Roles { get; set; }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        // n-n tablolar
        public virtual DbSet<ProductOrder> OrderProducts { get; set; } // Örnek n-n ilişki tablosu


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // AppUser - Order ilişkisini yapılandırma
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)  // Bir siparişin bir müşterisi (AppUser) olacak
                .WithMany(u => u.CustomerOrders)  // Bir müşteri birden fazla siparişe sahip olabilir
                .HasForeignKey(o => o.CustomerId)  // Foreign Key
                .OnDelete(DeleteBehavior.Cascade);  // Müşteri silindiğinde ilgili siparişler de silinir

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Seller)  // Bir siparişin bir satıcısı (AppUser) olacak
                .WithMany(u => u.SellerOrders)  // Bir satıcı birden fazla siparişe sahip olabilir
                .HasForeignKey(o => o.SellerId)  // Foreign Key
                .OnDelete(DeleteBehavior.Restrict);  // Satıcı silindiğinde siparişler silinemez

            // Order ve Product arasındaki ilişki (n-n) - OrderProduct
            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });  // Birleştirilmiş anahtar

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);

            // Customer (AppUser) ve Cart arasındaki ilişkiyi tanımlama
            // CustomerId ve ProductId birleşik anahtar olarak kullanılır

            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.CustomerId, c.ProductId });  

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=eTicaret.db");
        }

    }
}
