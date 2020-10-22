using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configuarations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Message).IsRequired();
        }
    }
}
