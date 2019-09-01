using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zip.Data.Entities;

namespace Zip.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).ForSqlServerIsClustered(false); ;
            builder.HasIndex(x => x.Index).ForSqlServerIsClustered(true);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.MonthlyExpenses).IsRequired();
            builder.Property(x => x.MonthlySalary).IsRequired();
            builder.Property(x => x.Created).IsRequired().HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.Index).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Account).WithOne(x => x.User);
        }
    }
}
