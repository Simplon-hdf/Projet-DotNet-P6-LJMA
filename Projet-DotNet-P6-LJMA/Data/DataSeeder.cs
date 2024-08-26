using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Shared.Helpers;

namespace Projet_DotNet_P6_LJMA.Data
{
    public class DataSeeder
    {
        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;

        public DataSeeder(ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task SeedDataAsync()
        {
            var adminEmail = ConfigurationValidator.GetAdminEmail(_configuration);
            var adminPassword = ConfigurationValidator.GetAdminPassword(_configuration);
            var adminRole = ConfigurationValidator.GetAdminRole(_configuration);

            var existingUser = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == adminEmail);

            if (existingUser == null)
            {
                // Créer un nouvel utilisateur administrateur
                var adminUser = new Utilisateur
                {
                    Id = Guid.NewGuid(),
                    Email = adminEmail,
                    Nom = "Admin",
                    Prenom = "System",
                    Telephone = "",
                    MotDePasse = PasswordHasher.HashPassword(adminPassword),
                    Role = adminRole
                };

                _context.Utilisateurs.Add(adminUser);
            }
            else if (existingUser.Role != adminRole)
            {
                // Mettre à jour le rôle si nécessaire
                existingUser.Role = adminRole;
                _context.Utilisateurs.Update(existingUser);
            }

            await _context.SaveChangesAsync();
        }
    }
}
