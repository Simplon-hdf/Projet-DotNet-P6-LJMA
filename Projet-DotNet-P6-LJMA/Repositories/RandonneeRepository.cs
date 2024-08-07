﻿using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;

namespace Projet_DotNet_P6_LJMA.Repositories
{

    /// <summary>
    /// Repository de la classe Randonnee.
    /// </summary>
    public class RandonneeRepository : IRandonneeRepository
    {
        private readonly ApiDbContext _context;
        public RandonneeRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<Randonnee> GetAllAsync()
        {
            await foreach (var randonnee in _context.Randonnees)
            {
                yield return randonnee;
            }
        }

        public async Task<Randonnee?> GetByIdAsync(string id)
        {
            return await _context.Randonnees.FindAsync(id);
        }

        public async Task CreateAsync(Randonnee randonnee)
        {
            _context.Add(randonnee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Randonnee randonnee)
        {
            _context.Update(randonnee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var randonnee = await _context.Randonnees.FindAsync(id);
            if (randonnee != null)
            {
                _context.Randonnees.Remove(randonnee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
