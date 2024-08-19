using Projet_DotNet_P6_LJMA.Shared.Mapping;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Configurations
{
    public static class ApplicationSetup
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            ConfigurationValidator.ValidateConfigurations(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()));

            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerConfiguration();
            builder.Services.AddDatabaseConfiguration(builder.Configuration);
            builder.Services.AddAuthenticationConfiguration(builder.Configuration);

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy =>
                    policy.RequireRole(builder.Configuration["UserRoles:AdminRole"]!));
                options.AddPolicy("RequireDefaultRole", policy =>
                    policy.RequireRole(builder.Configuration["UserRoles:DefaultRole"]!));
            });

            builder.Services.AddCors(options => // setting front
            {
                options.AddPolicy("AllowAngularApp", builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("AllowAngularApp"); // setting front
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection(); // setting front
            app.MapControllers();

            return app;
        }
    }

}
