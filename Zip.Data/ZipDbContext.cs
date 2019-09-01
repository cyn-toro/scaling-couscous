using Microsoft.EntityFrameworkCore;
using Zip.Data.Entities;

namespace Zip.Data
{
    public class ZipDbContext : DbContext
    {
        public ZipDbContext(DbContextOptions<ZipDbContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("ZipDbContext::ctor ->" + GetHashCode());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZipDbContext).Assembly);
        }

    }
}
