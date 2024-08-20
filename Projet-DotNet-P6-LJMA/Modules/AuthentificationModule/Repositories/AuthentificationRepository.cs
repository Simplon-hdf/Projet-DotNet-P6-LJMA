using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Infrastructure.Data;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Repositories
{
    public class AuthentificationRepository : IAuthentificationRepository
    {
        private readonly ApiDbContext _context;
        public AuthentificationRepository(ApiDbContext context)
            => _context = context;

        public async Task<bool> CheckAsync(Expression<Func<Utilisateur, bool>> predicate)
            => await _context.Utilisateurs.AnyAsync(predicate);

        public async Task<Utilisateur?> GetUtilisateurByEmailAsync(string email) =>
            await _context.Utilisateurs
            .AsNoTracking()
            .Where(u => u.Email == email)
            .Select(u => new Utilisateur
            {
                Id = u.Id,
                Nom = u.Nom,
                Prenom = u.Prenom,
                MotDePasse = u.MotDePasse
            }).FirstOrDefaultAsync();

        public async Task<bool> RegisterAsync(Utilisateur utilisateur)
        {
            await _context.Utilisateurs.AddAsync(utilisateur);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
