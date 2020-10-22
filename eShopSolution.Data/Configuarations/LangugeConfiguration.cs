using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolution.Data.Configuarations
{
    public class LangugeConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languges");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().IsUnicode(false).HasMaxLength(5);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}
