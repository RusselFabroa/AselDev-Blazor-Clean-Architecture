using AselBlazorCleanArchitecture.Infrastructure.Data.AppDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
namespace AselBlazorCleanArchitecture.Infrastructure.Data.CleanPattern
{
    public class DbContextFactory : IDBContextFactory
    {
        private readonly IConfiguration _config;

        public DbContextFactory(IConfiguration config)
        {
            _config = config;
        }

        public AppDbContextDynamic CreateDbContext(string connectionName)
        {
            var _dbProvider = _config.GetSection($"DynamicConnectionStrings:{connectionName}:Provider").Value;
            var _connectionString = _config.GetSection($"DynamicConnectionStrings:{connectionName}:ConnectionString").Value;
            var _optionsBuilder = new DbContextOptionsBuilder<AppDbContextDynamic>();

            switch (_dbProvider?.ToLower())
            {
                case "mysql":
                    _optionsBuilder.UseMySql(_connectionString,
                        new MySqlServerVersion(new Version(5, 6, 13)));
                    break;
                case "oracle":
                    _optionsBuilder.UseOracle(_connectionString);
                    break;
                default:
                    throw new Exception("Unsupported database provider");
            }

            return new AppDbContextDynamic(_optionsBuilder.Options);
        }
    }
}