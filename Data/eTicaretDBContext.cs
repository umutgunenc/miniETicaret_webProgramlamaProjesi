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
        public virtual DbSet<ProductOrder> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                 .HasOne(o => o.Customer)
                 .WithMany(u => u.CustomerOrders)
                 .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId, po.SellerId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Seller)
                .WithMany(s => s.SellerOrders)
                .HasForeignKey(po => po.SellerId);

            
            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.CustomerId, c.ProductId });

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);


            #region DumpData

            var passwordHasher = new PasswordHasher<AppUser>();

            AppRole admin = new AppRole { Id = 1, Name = "ADMIN" };
            AppRole seller = new AppRole { Id = 2, Name = "SELLER" };
            AppRole customer = new AppRole { Id = 3, Name = "CUSTOMER" };

            AppUser adminUser = new AppUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Name = "ADMIN",
                SurName = "ADMIN",
                TCKN = "12345678901",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "+905300000000",
                Address = "Istanbul",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123123123");

            AppUser sellerUser = new AppUser
            {
                Id = 2,
                UserName = "seller",
                NormalizedUserName = "SELLER",
                Email = "seller@gmail.com",
                NormalizedEmail = "SELLER@GMAIL.COM",
                Name = "SELLER",
                SurName = "SELLER",
                TCKN = "12345678902",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "+905300000001",
                Address = "Ankara",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            sellerUser.PasswordHash = passwordHasher.HashPassword(sellerUser, "qweqweqwe");

            AppUser customerUser = new AppUser
            {
                Id = 3,
                UserName = "customer",
                NormalizedUserName = "CUSTOMER",
                Email = "customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                Name = "CUSTOMER",
                SurName = "CUSTOMER",
                TCKN = "12345678903",
                IsActive = true,
                TermOfUse = true,
                PhoneNumber = "+905300000002",
                Address = "İzmir",
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            customerUser.PasswordHash = passwordHasher.HashPassword(customerUser, "qweqweqwe");

            modelBuilder.Entity<AppRole>()
                .HasData(admin, seller, customer);

            modelBuilder.Entity<AppUser>()
                .HasData(adminUser, sellerUser, customerUser);

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
