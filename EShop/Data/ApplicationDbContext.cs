using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ProductPath> ProductPaths { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "ADMIN", Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "USER", Name = "User", NormalizedName = "USER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "VELKOOBCHOD", Name = "Velkoobchod", NormalizedName = "VELKOOBCHOD" });
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "ADMINISTRATOR",
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                Email = "teascreate@seznam.cz",
                NormalizedEmail = "TEASCREATE@SEZNAM.CZ",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = hasher.HashPassword(null, "hmat2002"),
                DCity = "Empty",
                DPostalCode = 0,
                DStreetName = "Empty",
                FirstName = "Empty",
                LastName = "Empty",
                PhoneNumber = "Empty"

            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = "ADMIN", UserId = "ADMINISTRATOR" });
            builder.Entity<CategoryProduct>().HasKey(k => new { k.CategoryId, k.ProductId });
            builder.Entity<ProductPath>().HasKey(k => new { k.ProductID, k.PathID });
            //Inicializace kategorií
            builder.Entity<Category>().HasData(new Category() { ID = 1, DisplayName = "Dětská móda" });
            builder.Entity<Category>().HasData(new Category() { ID = 2, DisplayName = "Kukly, čepice", IdentifierName = "Čepice - Dětské", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 3, DisplayName = "Nákrčníky, slintáky", IdentifierName = "Nákrčníky - Dětské", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 4, DisplayName = "Body, trička", IdentifierName = "Body - Dětské", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 5, DisplayName = "Yogínky, turky", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 6, DisplayName = "Plenky", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 7, DisplayName = "AIO", ParentID = 6 });
            builder.Entity<Category>().HasData(new Category() { ID = 8, DisplayName = "Novorozenecké", IdentifierName = "Novorozenecké - AIO", ParentID = 7 });
            builder.Entity<Category>().HasData(new Category() { ID = 9, DisplayName = "Jednovelikostní", IdentifierName = "Jednovelikostní - AIO", ParentID = 7 });
            builder.Entity<Category>().HasData(new Category() { ID = 10, DisplayName = "SIO", ParentID = 6 });
            builder.Entity<Category>().HasData(new Category() { ID = 11, DisplayName = "Novorozenecké", IdentifierName = "Novorozenecké - SIO", ParentID = 10 });
            builder.Entity<Category>().HasData(new Category() { ID = 12, DisplayName = "Jednovelikostní", IdentifierName = "Jednovelikostní - SIO", ParentID = 10 });
            builder.Entity<Category>().HasData(new Category() { ID = 13, DisplayName = "Kalhotkové", ParentID = 6 });
            builder.Entity<Category>().HasData(new Category() { ID = 14, DisplayName = "Novorozenecké", IdentifierName = "Novorozenecké - Kalhotkové", ParentID = 13 });
            builder.Entity<Category>().HasData(new Category() { ID = 15, DisplayName = "Jednovelikostní", IdentifierName = "Jednovelikostní - Kalhotkové", ParentID = 13 });
            builder.Entity<Category>().HasData(new Category() { ID = 16, DisplayName = "Svrchní", ParentID = 6 });
            builder.Entity<Category>().HasData(new Category() { ID = 17, DisplayName = "Novorozenecké", IdentifierName = "Novorozenecké - Svrchní", ParentID = 16 });
            builder.Entity<Category>().HasData(new Category() { ID = 18, DisplayName = "Jednovelikostní", IdentifierName = "Jednovelikostní - Svrchní", ParentID = 16 });
            builder.Entity<Category>().HasData(new Category() { ID = 19, DisplayName = "Spodní prádlo", IdentifierName = "Spodní prádlo - Dětské", ParentID = 1 });
            builder.Entity<Category>().HasData(new Category() { ID = 20, DisplayName = "Dámská móda" });
            builder.Entity<Category>().HasData(new Category() { ID = 21, DisplayName = "Čepice", IdentifierName = "Čepice - Dámské", ParentID = 20 });
            builder.Entity<Category>().HasData(new Category() { ID = 22, DisplayName = "Nákrčníky", IdentifierName = "Nákrčníky - Dámské", ParentID = 20 });
            builder.Entity<Category>().HasData(new Category() { ID = 23, DisplayName = "Tuniky, trička", IdentifierName = "Tuniky, trička - Dámské", ParentID = 20 });
            builder.Entity<Category>().HasData(new Category() { ID = 24, DisplayName = "Šaty", ParentID = 20 });
            builder.Entity<Category>().HasData(new Category() { ID = 25, DisplayName = "Spodní prádlo", IdentifierName = "Spodní prádlo - Dámské", ParentID = 20 });
            builder.Entity<Category>().HasData(new Category() { ID = 26, DisplayName = "Pánská móda" });
            builder.Entity<Category>().HasData(new Category() { ID = 27, DisplayName = "Čepice", IdentifierName = "Čepice - Pánské", ParentID = 26 });
            builder.Entity<Category>().HasData(new Category() { ID = 28, DisplayName = "Nákrčníky", IdentifierName = "Nákrčníky - Pánské", ParentID = 26 });
            builder.Entity<Category>().HasData(new Category() { ID = 29, DisplayName = "Trička", IdentifierName = "Trička - Pánská", ParentID = 26 });
            builder.Entity<Category>().HasData(new Category() { ID = 30, DisplayName = "Spodní prádlo", IdentifierName = "Spodní prádlo - Pánské", ParentID = 26 });
            

        }
    }
}
