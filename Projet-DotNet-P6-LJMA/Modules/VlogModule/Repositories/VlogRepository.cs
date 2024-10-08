﻿using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Modules.VlogModule.Repositories
{
    public class VlogRepository : IVlogRepository
    {
        private readonly ApiDbContext _context;
        public VlogRepository(ApiDbContext context)
            => _context = context;

        public async IAsyncEnumerable<Vlog> GetAllAsync()
        {
            await foreach (var vlog in _context.Vlogs)
            {
                yield return vlog;
            }
        }

        public async Task<Vlog?> GetByIdAsync(Guid id)
            => await _context.Vlogs.FindAsync(id);

        public async Task CreateAsync(Vlog vlog)
        {
            await _context.Vlogs.AddAsync(vlog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vlog vlog)
        {
            _context.Vlogs.Update(vlog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var vlog = await _context.Vlogs.FindAsync(id);
            if (vlog != null)
            {
                _context.Vlogs.Remove(vlog);
                await _context.SaveChangesAsync();
            }
        }
    }
}