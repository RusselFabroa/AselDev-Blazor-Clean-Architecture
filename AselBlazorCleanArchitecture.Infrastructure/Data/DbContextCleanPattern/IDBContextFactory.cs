using AselBlazorCleanArchitecture.Infrastructure.Data.AppDBContext;


namespace AselBlazorCleanArchitecture.Infrastructure.Data.CleanPattern
{
    // Inject to Program.cs
    // builder.Services.AddScoped<IDBContextFactory, DbContextFactory>();
 
    public interface IDBContextFactory
    { 
        AppDbContextDynamic CreateDbContext(string connectionName);
    }

    
}
