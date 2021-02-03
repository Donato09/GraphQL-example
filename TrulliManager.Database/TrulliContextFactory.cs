using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TrulliManager.Database
{
    class TrulliContextFactory : IDesignTimeDbContextFactory<TrulliContext>
    {
        public TrulliContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TrulliContext>();
            var connectionString = config.GetConnectionString("TrulliContext");
            builder.UseSqlServer(connectionString);

            return new TrulliContext(builder.Options);
        }
    }
}
