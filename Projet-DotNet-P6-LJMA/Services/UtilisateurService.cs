using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }
        
        public async Task CreateAsync(UtilisateurCreatedDto utilisateur)
        {
            await _utilisateurRepository.CreateAsync(utilisateur.Map());
        }

        public async Task DeleteAsync(Guid id)
        {
            await _utilisateurRepository.DeleteAsync(id);
        }

        public async IAsyncEnumerable<UtilisateurDto> GetAllAsync()
        {
            await foreach (Utilisateur utilisateur in _utilisateurRepository.GetAllAsync())
            {
                yield return utilisateur.MapToDto();
            }
        }

        public async Task<UtilisateurDto> GetByIdAsync(Guid id)
        {
            return (await _utilisateurRepository.GetByIdAsync(id)).MapToDto();
        }

        public async Task UpdateAsync(UtilisateurDto utilisateur)
        {
            await _utilisateurRepository.UpdateAsync(utilisateur.Map());
        }

        public async Task<bool> UtilisateurExist(Guid id)
        {
            return await _utilisateurRepository.UtilisateurExist(id);
        }
    }
}
