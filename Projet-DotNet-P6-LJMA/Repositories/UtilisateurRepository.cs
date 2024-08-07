﻿using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Repositories
{
    public interface IUtilisateurRepository
    {
        IAsyncEnumerable<Utilisateur> GetAllAsync();
        Task<Utilisateur> GetByIdAsync(string id);
        Task CreateAsync(Utilisateur utilisateur);
        Task UpdateAsync(Utilisateur utilisateur);
        Task DeleteAsync(string id);
        Task<bool> UtilisateurExist(string id);
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

        public async Task<bool> UtilisateurExist(string id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupere les utilisateurs en base de donnée
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

        public Task<Utilisateur> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }
    }
}
