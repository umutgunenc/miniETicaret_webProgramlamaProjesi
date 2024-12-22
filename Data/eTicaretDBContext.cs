using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Models.Entity;
using System;


namespace miniETicaret.Data
{
    public class eTicaretDBContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public eTicaretDBContext()
        {

        }
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

            #region DumpData

            var passwordHasher = new PasswordHasher<AppUser>();

            AppRole admin = new AppRole { Id = 1, Name = "ADMIN" };
            AppRole seller = new AppRole { Id = 2, Name = "SELLER" };
            AppRole customer = new AppRole { Id = 3, Name = "CUSTOMER" };

            AppUser adminUser = new AppUser
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@gmail.com",
                Name = "ADMIN",
                SurName = "ADMIN",
                TCKN = "12345678901",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "05300000000",
                Address = "Istanbul",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123123123");

            AppUser sellerUser = new AppUser
            {
                Id = 2,
                UserName = "seller",
                Email = "seller@gmail.com",
                Name = "SELLER",
                SurName = "SELLER",
                TCKN = "12345678902",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "05300000001",
                Address = "Ankara",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            sellerUser.PasswordHash = passwordHasher.HashPassword(sellerUser, "qweqweqwe");

            AppUser customerUser = new AppUser
            {
                Id = 3,
                UserName = "customer",
                Email = "customer@gmail.com",
                Name = "CUSTOMER",
                SurName = "CUSTOMER",
                TCKN = "12345678903",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "05300000002",
                Address = "İzmir",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            customerUser.PasswordHash = passwordHasher.HashPassword(customerUser, "qweqweqwe");
            
            modelBuilder.Entity<AppRole>()
                .HasData(admin, seller, customer);

            modelBuilder.Entity<AppUser>()
                .HasData(adminUser,sellerUser, customerUser);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int> { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int> { RoleId = 3, UserId = 3 }
                );



            #endregion



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=eTicaret.db");
        }

    }
}
