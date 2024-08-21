using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;
using Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Repositories;
using Projet_DotNet_P6_LJMA.Infrastructure.Configurations;
using Projet_DotNet_P6_LJMA.Shared.Helpers;

namespace Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly string _defaultRole;
        public UtilisateurService(IUtilisateurRepository utilisateurRepository, IConfiguration configuration)
        {
            _utilisateurRepository = utilisateurRepository;
            _defaultRole = ConfigurationValidator.GetDefaultRole(configuration);
        }

        public async Task CreateAsync(UtilisateurCreatedDTO utilisateurDto)
        {
            utilisateurDto.MotDePasse = PasswordHasher.HashPassword(utilisateurDto.MotDePasse);
            Utilisateur utilisateur = utilisateurDto.Map();
            utilisateur.Role = _defaultRole;
            await _utilisateurRepository.CreateAsync(utilisateur);
        }

        public async Task DeleteAsync(Guid id)
            => await _utilisateurRepository.DeleteAsync(id);

        public async IAsyncEnumerable<UtilisateurDTO> GetAllAsync()
        {
            await foreach (Utilisateur utilisateur in _utilisateurRepository.GetAllAsync())
            {
                yield return utilisateur.Map();
            }
        }

        public async Task<UtilisateurDTO?> GetByIdAsync(Guid id)
            => (await _utilisateurRepository.GetByIdAsync(id))?.Map();

        public async Task UpdateAsync(UtilisateurDTO utilisateur)
            => await _utilisateurRepository.UpdateAsync(utilisateur.Map());
    }
}
