using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.Repository.Interface;

namespace Projet_DotNet_P6_LJMA.Repository;

/// <summary>
/// Repository de la classe Reserver.
/// </summary>
public class ReserverRepository : IReserverRepository
{
    private readonly ApiDbContext _context;

    public ReserverRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async IAsyncEnumerable<Reserver> GetAllAsync()
    {
        await foreach (var reserver in _context.Reservers)
        {
            yield return reserver;
        }
    }

    public async Task<Reserver?> GetByIdAsync(string id)
    {
        return await _context.Reservers.FindAsync(id);
    }

    public async Task CreateAsync(Reserver reserver)
    {
        _context.Add(reserver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reserver reserver)
    {
        _context.Update(reserver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var reserver = await _context.Reservers.FindAsync(id);
        if (reserver != null)
        {
            _context.Reservers.Remove(reserver);
            await _context.SaveChangesAsync();
        }
    }
}