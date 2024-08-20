using Projet_DotNet_P6_LJMA.Infrastructure.Data;
using Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Services;
using Projet_DotNet_P6_LJMA.Modules.PostModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.PostModule.Services;
using Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.RandonneeModule.Services;
using Projet_DotNet_P6_LJMA.Modules.ReserverModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.ReserverModule.Services;
using Projet_DotNet_P6_LJMA.Modules.SessionModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.SessionModule.Services;
using Projet_DotNet_P6_LJMA.Modules.ThemeModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.ThemeModule.Services;
using Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Services;
using Projet_DotNet_P6_LJMA.Modules.VlogModule.Repositories;
using Projet_DotNet_P6_LJMA.Modules.VlogModule.Services;
using Projet_DotNet_P6_LJMA.Shared.Helpers;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthentificationRepository, AuthentificationRepository>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();

            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddScoped<IUtilisateurService, UtilisateurService>();

            services.AddScoped<IReserverRepository, ReserverRepository>();
            services.AddScoped<IReserverService, ReserverService>();

            services.AddScoped<IVlogRepository, VlogRepository>();
            services.AddScoped<IVlogService, VlogService>();

            services.AddScoped<IRandonneeRepository, RandonneeRepository>();
            services.AddScoped<IRandonneeService, RandonneeService>();

            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IThemeService, ThemeService>();

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<JwtHelper>();

            services.AddScoped<DataSeeder>();

            return services;
        }
    }
}