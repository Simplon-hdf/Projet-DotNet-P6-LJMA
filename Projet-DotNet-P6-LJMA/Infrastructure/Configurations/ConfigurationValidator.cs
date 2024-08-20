using Projet_DotNet_P6_LJMA.Shared.Validators;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Configurations
{
    public static class ConfigurationValidator
    {
        private const int MinJwtSecretLength = 32;
        private const int MinAdminPasswordLength = 12;

        public static void ValidateConfigurations(IConfiguration configuration)
        {
            ValidateJwtSecret(configuration);
            ValidateUserRoles(configuration);
            ValidateAdminUser(configuration);
            ValidateDbConnection(configuration);
        }

        #region Validation Methods

        private static void ValidateJwtSecret(IConfiguration configuration)
        {
            string jwtSecret = GetConfigValue(configuration, "JwtSecret");
            if (jwtSecret.Length < MinJwtSecretLength) /// TODO: on pourrait ajouter de le valideurPasswordComplex
            {
                throw new InvalidOperationException($"JWT secret key must be at least {MinJwtSecretLength} characters long.");
            }
        }

        private static void ValidateUserRoles(IConfiguration configuration)
        {
            GetConfigValue(configuration, "UserRoles:DefaultRole");
            GetConfigValue(configuration, "UserRoles:AdminRole");
        }

        private static void ValidateAdminUser(IConfiguration configuration)
        {
            string adminEmail = GetConfigValue(configuration, "AdminUser:Email");
            string adminPassword = GetConfigValue(configuration, "AdminUser:Password");

            if (!EmailValidator.IsValidEmail(adminEmail))
            {
                throw new InvalidOperationException("Admin email is not valid.");
            }

            if (adminPassword.Length < MinAdminPasswordLength || !PasswordValidator.IsValidPassword(adminPassword))
            {
                throw new InvalidOperationException($"Admin password is not valid (minimum {MinAdminPasswordLength} characters and must meet complexity requirements).");
            }
        }

        private static void ValidateDbConnection(IConfiguration configuration)
        {
            GetConnectionString(configuration);
        }

        #endregion

        #region Get Methods

        public static string GetJwtSecret(IConfiguration configuration)
            => GetConfigValue(configuration, "JwtSecret");

        public static string GetConnectionString(IConfiguration configuration)
            => GetConfigValue(configuration, "ConnectionStrings:DefaultConnection");

        public static string GetAdminEmail(IConfiguration configuration)
            => GetConfigValue(configuration, "AdminUser:Email");

        public static string GetAdminPassword(IConfiguration configuration)
            => GetConfigValue(configuration, "AdminUser:Password");

        public static string GetAdminRole(IConfiguration configuration)
            => GetConfigValue(configuration, "UserRoles:AdminRole");

        public static string GetDefaultRole(IConfiguration configuration)
            => GetConfigValue(configuration, "UserRoles:DefaultRole");

        #endregion

        public static string GetConfigValue(IConfiguration configuration, string key)
        {
            string? value = configuration[key];

            return !string.IsNullOrEmpty(value)
                ? value
                : throw new InvalidOperationException($"Configuration value for '{key}' is missing or empty.");
        }
    }
}
