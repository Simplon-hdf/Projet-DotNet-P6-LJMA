using Projet_DotNet_P6_LJMA.Data;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Configurations
{
    public static class DataInitializer
    {
        public static async Task InitializeDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dataSeeder = services.GetRequiredService<DataSeeder>();
            await dataSeeder.SeedDataAsync();
        }
    }

}
