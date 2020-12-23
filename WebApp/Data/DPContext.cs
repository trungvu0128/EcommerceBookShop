using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Data
{
    public class DPContext : IdentityDbContext<CustomUser>
    {
            
        public DPContext(DbContextOptions<DPContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<DetailBill> detailBills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<ImportProduct> ImportProducts { get; set; }
        public DbSet<ExportProduct> ExportProducts { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WebApp.Models.Slide> Slide { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            builder.Entity<Cart>().HasNoKey();
        }
    }
}
