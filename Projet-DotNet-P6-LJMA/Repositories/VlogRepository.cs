using Projet_DotNet_P6_LJMA.Data;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA;

public class VlogRepository : IVlogRepository
{
    private readonly ApiDbContext _context;

    public VlogRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async IAsyncEnumerable<Vlog> GetAllAsync()
    {
        await foreach ( var vlog in _context.Vlogs )
        {
            yield return vlog;
        }
    }

    public async Task<Vlog?> GetByIdAsync(string id)
    {
        return await _context.Vlogs.FindAsync(id);
    }

    public async Task CreateAsync(Vlog vlog)
    {
        _context.Add(vlog);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Vlog vlog)
    {
        _context.Update(vlog);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var vlog = await _context.Vlogs.FindAsync(id);
        if (vlog != null)
        {
            _context.Vlogs.Remove(vlog);
            await _context.SaveChangesAsync();
        }
    }
}