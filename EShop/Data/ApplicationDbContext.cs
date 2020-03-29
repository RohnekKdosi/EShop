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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "ADMIN", Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "USER", Name = "User", NormalizedName = "USER" });
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

        }
    }
}
