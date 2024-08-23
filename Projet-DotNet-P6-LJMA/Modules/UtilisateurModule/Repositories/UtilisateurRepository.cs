using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.UtilisateurModule.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApiDbContext _context;
        public UtilisateurRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Utilisateur> GetAllAsync()
        {
            await foreach (Utilisateur utilisateur in _context.Utilisateurs)
            {
                yield return utilisateur;
            }
        }

        public async Task<Utilisateur?> GetByIdAsync(Guid id)
            => await _context.Utilisateurs.FindAsync(id);

        public async Task CreateAsync(Utilisateur utilisateur)
        {
            await _context.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Utilisateur utilisateurToUpdate)
        {
            _context.Utilisateurs.Update(utilisateurToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
