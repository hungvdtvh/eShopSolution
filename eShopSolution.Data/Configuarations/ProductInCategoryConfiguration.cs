using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configuarations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(t => new { t.ProductId, t.CategoryId});
            builder.HasOne(p => p.Product)
                .WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(b=>b.ProductId);

            builder.HasOne(pc => pc.Category).
                WithMany(p => p.ProductInCategories).
                HasForeignKey(pc => pc.CategoryId);

        }
    }
}
