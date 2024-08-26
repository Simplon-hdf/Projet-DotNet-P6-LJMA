using Projet_DotNet_P6_LJMA.Models;
using System.Linq.Expressions;

namespace Projet_DotNet_P6_LJMA.Modules.AuthentificationModule.Repositories
{
    public interface IAuthentificationRepository
    {
        Task<bool> RegisterAsync(Utilisateur utilisateur);
        Task<bool> CheckAsync(Expression<Func<Utilisateur, bool>> predicate);
        Task<Utilisateur?> GetUtilisateurByEmailAsync(string email);
    }
}
