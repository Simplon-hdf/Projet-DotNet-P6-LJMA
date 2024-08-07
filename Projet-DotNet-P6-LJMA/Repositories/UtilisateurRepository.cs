using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    public interface IUtilisateurRepository
    {
        IAsyncEnumerable<Utilisateur> GetAllAsync();
        Task<Utilisateur> GetByIdAsync(Guid id);
        Task CreateAsync(Utilisateur utilisateur);
        Task UpdateAsync(Utilisateur utilisateur);
        Task DeleteAsync(Guid id);
        Task<bool> UtilisateurExist(Guid id);
    }

    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApiDbContext _context;

        /// <summary>
        /// La classe UtilisateurRepository est notre couche d'accès aux données 
        /// ( Data access Layer )
        /// et prend en paramètre le <c>context</c> de la base de donnée ( Data Storage )
        /// </summary>
        /// <param name="context"> </param>
        public UtilisateurRepository(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère les utilisateurs en base de donnée
        /// </summary>
        /// <returns>
        /// Renvoie une collection d'utilisateurs en asynchrone de type IAsyncEnumerable<Utilisateur>
        /// </returns>
        public async IAsyncEnumerable<Utilisateur> GetAllAsync()
        {
            await foreach (Utilisateur utilisateur in _context.Utilisateurs)
            {
                yield return utilisateur;
            }
        }

        /// <summary>
        /// Récupère un utilisateur par son identifiant <c>id</c>
        /// </summary>
        /// <param name="id">l'identifiant de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Utilisateur> GetByIdAsync(Guid id)
        {
            return await _context.Utilisateurs.FindAsync(id);
        }

        /// <summary>
        /// Rècupère un booléen si un utilisateur existe dans la base de données
        /// </summary>
        /// <param name="id">identifiant de l'utilisateur</param>
        /// <returns>
        /// Renvoie True si l'utilisateur dans la base de données et False sinon
        /// </returns>
        public async Task<bool> UtilisateurExist(Guid id)
        {
            return await _context.Utilisateurs.AnyAsync(utilisateur => utilisateur.id_utilisateur == id);
        }

        /// <summary>
        /// Créer un utilisateur à partir de son identifiant
        /// </summary>
        /// <param name="utilisateur"></param>
        public async Task CreateAsync(Utilisateur utilisateur)
        {
            _context.Add(utilisateur);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Supprime un utilisateur à partir de son identifiant
        /// </summary>
        /// <param name="id">identifiant de l'utilisateur</param>
        public async Task DeleteAsync(Guid id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Mets à jour un utilisateur à partir de <c>utilisateurToUpdate</c>
        /// </summary>
        /// <param name="utilisateurToUpdate">le nouveau utilisateur à mettre à jour</param>
        public async Task UpdateAsync(Utilisateur utilisateurToUpdate)
        {
            _context.Utilisateurs.Update(utilisateurToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
