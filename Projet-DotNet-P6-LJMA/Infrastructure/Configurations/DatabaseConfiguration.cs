using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Infrastructure.Data;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = ConfigurationValidator.GetConnectionString(configuration);
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            return services;
        }
    }
}
