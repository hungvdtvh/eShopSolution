using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModerBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData
                (new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyWord", Value = "This is keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is discription page of eShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "EngLish", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                });

            modelBuilder.Entity<CategoryTranslation>().HasData
            (
                new CategoryTranslation { Id = 1, CategoryId = 1, Name = "Áo Nam", LangugeId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                new CategoryTranslation { Id = 2, CategoryId = 1, Name = "Men Shirt", LangugeId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                new CategoryTranslation { Id = 3, CategoryId = 2, Name = "Áo Nữ", LangugeId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang nữ" },
                new CategoryTranslation { Id = 4, CategoryId = 2, Name = "Women Shirt", LangugeId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0
                });

            modelBuilder.Entity<ProductTranslation>().HasData(
                    new ProductTranslation() { Id = 1, ProductId = 1, Name = "Áo Sơ Mi Nam", LanguageId = "vi-Vn", SeoAlias = "ao-so-mi-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam", Details = "Mô tả sản phẩm", Description = "" },
                    new ProductTranslation() { Id = 2, ProductId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men", Details = "Description of product", Description = "" }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { CategoryId = 1, ProductId = 1 });

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = new Guid("A1330FAB-AC03-4D0E-9887-FFE7D76584B1"),
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Adminstrator role"
                });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = new Guid("F8FF17F5-B3A7-4AF1-BDD5-44D02750508A"),
                    UserName = "Admin",
                    NormalizedUserName = "Admin",
                    Email = "hungvd.tvh@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Hungvd@123"),
                    SecurityStamp = string.Empty,
                    FristName = "Hung",
                    LastName = "Vo Duy",
                    Dob = new DateTime(1993, 12, 15)
                });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                {
                    RoleId= new Guid("A1330FAB-AC03-4D0E-9887-FFE7D76584B1"),
                    UserId= new Guid("F8FF17F5-B3A7-4AF1-BDD5-44D02750508A")
                });
        }
    }
}
