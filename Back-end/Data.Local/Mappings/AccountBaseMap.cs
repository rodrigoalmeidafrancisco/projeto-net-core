using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Local.Mappings
{
    public class AccountBaseMap : IEntityTypeConfiguration<AccountBase>
    {
        public void Configure(EntityTypeBuilder<AccountBase> builder)
        {
            builder.ToTable("Base", "Account");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.EmailConfirmed).HasColumnType("BIT").IsRequired(true);
            builder.Property(x => x.Password).HasColumnType("NVARCHAR(MAX)").IsRequired(true);
            builder.Property(x => x.AccessFailedCount).HasColumnType("INT").IsRequired(true);
            builder.Property(x => x.Lockout).HasColumnType("BIT").IsRequired(true);
            builder.Property(x => x.LockoutEnd).HasColumnType("DATETIMEOFFSET(7)").IsRequired(false);

            //Propriedades do Flunt devem ser ignoradas
            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
