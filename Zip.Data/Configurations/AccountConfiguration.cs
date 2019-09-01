using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zip.Data.Entities;

namespace Zip.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered(false);
            builder.HasIndex(x => x.Index).ForSqlServerIsClustered(true);

            builder.Property(x => x.CreditBalance).IsRequired();
            builder.Property(x => x.CreditLimit).IsRequired();
            builder.Property(x => x.Index).ValueGeneratedOnAdd();

            builder.Property(x => x.Created).IsRequired().HasDefaultValueSql("getutcdate()");
        }
    }
}
