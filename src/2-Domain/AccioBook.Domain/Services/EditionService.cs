using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class EditionService : DatabaseService<Edition>, IEditionService
    {
        public EditionService(IEditionRepository repository) : base(repository)
        {

        }

        public async Task<IEnumerable<Edition>> GetLastEditionsTop100()
        {
            var repo = (IEditionRepository)_repository;
            return await repo.GetLastEditionsTop100();
        }
    }

}
