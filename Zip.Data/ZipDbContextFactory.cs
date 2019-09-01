using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Zip.Data
{
    public class ZipDbContextFactory : IDesignTimeDbContextFactory<ZipDbContext>
    {
        private const string ConnectionStringName = "ZipDb";
        private const string EntryProjectName = "Zip";

        public ZipDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}{1}", Path.DirectorySeparatorChar, EntryProjectName);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string is not configured properly. No value found.");

            return Create(connectionString);
        }

        private static ZipDbContext Create(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<ZipDbContext>();
            builder.UseSqlServer(connectionString);

            return (ZipDbContext)Activator.CreateInstance(typeof(ZipDbContext), builder.Options);
        }
    }
}
