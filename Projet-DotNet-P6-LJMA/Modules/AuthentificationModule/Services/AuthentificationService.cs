using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;
using Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Repositories;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Shared.Exceptions;
using Projet_DotNet_P6_LJMA.Shared.Helpers;
using Projet_DotNet_P6_LJMA.Shared.Mapping;

namespace Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IAuthentificationRepository _authentificationRepository;
        private readonly string _defaultRole;
        private readonly string _adminRole;

        public AuthentificationService(
            IAuthentificationRepository authentificationRepository,
            IConfiguration configuration)
        {
            _authentificationRepository = authentificationRepository;
            _defaultRole = ConfigurationValidator.GetDefaultRole(configuration);
            _adminRole = ConfigurationValidator.GetAdminRole(configuration);
        }

        public async Task<AuthentificateDTO?> AuthentificateAsync(LoginDTO loginDTO)
        {
            var utilisateur = await _authentificationRepository.GetUtilisateurByEmailAsync(loginDTO.Email);
            return utilisateur is not null && PasswordHasher.VerifyPassword(loginDTO.MotDePasse, utilisateur.MotDePasse)
                ? utilisateur.MapToAuthentificateDTO()
                : null;
        }

        public async Task<bool> RegisterAsync(RegisterDTO registerDTO)
        {
            if (await _authentificationRepository.CheckAsync(u => u.Email == registerDTO.Email))
            {
                throw new DuplicateEmailException("L'utilisateur existe déjà");
            }
            registerDTO.MotDePasse = PasswordHasher.HashPassword(registerDTO.MotDePasse);
            Utilisateur utilisateur = registerDTO.Map();
            utilisateur.Telephone = "System";
            utilisateur.Nom = "User";
            utilisateur.Prenom = "System";
            utilisateur.Role = _defaultRole;
            return await _authentificationRepository.RegisterAsync(utilisateur);
        }

        public async Task<bool> RegisterAdminAsync(RegisterDTO registerDTO)
        {
            if (await _authentificationRepository.CheckAsync(u => u.Email == registerDTO.Email))
            {
                throw new DuplicateEmailException("L'utilisateur existe déjà");
            }
            registerDTO.MotDePasse = PasswordHasher.HashPassword(registerDTO.MotDePasse);
            Utilisateur utilisateur = registerDTO.Map();
            utilisateur.Telephone = "System";
            utilisateur.Nom = "Admin";
            utilisateur.Prenom = "System";
            utilisateur.Role = _adminRole;
            return await _authentificationRepository.RegisterAsync(utilisateur);
        }
    }
}