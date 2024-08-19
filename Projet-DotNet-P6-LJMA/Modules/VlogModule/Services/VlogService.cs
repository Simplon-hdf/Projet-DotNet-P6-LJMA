using Projet_DotNet_P6_LJMA.Shared.Mapping;
using Projet_DotNet_P6_LJMA.Shared.DTOs;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;
using Projet_DotNet_P6_LJMA.Modules.VlogModule.Repositories;

namespace Projet_DotNet_P6_LJMA.Modules.VlogModule.Services
{
    public class VlogService : IVlogService
    {
        private readonly IVlogRepository _vlogRepository;
        public VlogService(IVlogRepository vlogRepository)
            => _vlogRepository = vlogRepository;

        public async Task CreateAsync(VlogCreatedDTO vlog)
            => await _vlogRepository.CreateAsync(vlog.Map());

        public async Task DeleteAsync(Guid id)
            => await _vlogRepository.DeleteAsync(id);

        public async IAsyncEnumerable<VlogDTO> GetAllAsync()
        {
            await foreach (Vlog vlog in _vlogRepository.GetAllAsync())
            {
                yield return vlog.Map();
            }
        }

        public async Task<VlogDTO?> GetByIdAsync(Guid id)
            => (await _vlogRepository.GetByIdAsync(id))?.Map();

        public async Task UpdateAsync(VlogDTO vlog)
            => await _vlogRepository.UpdateAsync(vlog.Map());
    }
}