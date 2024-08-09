using Projet_DotNet_P6_LJMA.Mapping;
using Projet_DotNet_P6_LJMA.Models;
using Projet_DotNet_P6_LJMA.ModelsDTO;
using Projet_DotNet_P6_LJMA.Repositories.Interfaces;
using Projet_DotNet_P6_LJMA.Services.Interfaces;

namespace Projet_DotNet_P6_LJMA.Services;

public class VlogService : IVlogService
{
    private readonly IVlogRepository _vlogRepository;

    public VlogService(IVlogRepository vlogRepository)
    {
        _vlogRepository = vlogRepository;
    }

    public async Task CreateAsync(VlogCreatedDto vlog)
    {
        await _vlogRepository.CreateAsync(vlog.Map());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _vlogRepository.DeleteAsync(id);
    }

    public async IAsyncEnumerable<VlogDto> GetAllAsync()
    {
        await foreach(Vlog vlog in _vlogRepository.GetAllAsync())
        {
            yield return vlog.MapToDo();
        }
    }

    public async Task<VlogDto> GetByIdAsync(Guid id)
    {
        return (await _vlogRepository.GetByIdAsync(id)).MapToDo();
    }

    public async Task UpdateAsync(VlogDto vlog)
    {
        await _vlogRepository.UpdateAsync(vlog.Map());
    }
}