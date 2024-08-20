using Microsoft.AspNetCore.Authorization;
using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;

public class ConfigurableAuthorizeAttribute : AuthorizeAttribute
{
    public ConfigurableAuthorizeAttribute(string roleConfigKey)
    {
        var configuration = GetConfiguration();
        Roles = ConfigurationValidator.GetConfigValue(configuration, roleConfigKey);
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        return builder.Build();
    }

    
}
