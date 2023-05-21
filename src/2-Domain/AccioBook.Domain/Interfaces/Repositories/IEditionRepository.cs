using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IEditionRepository : IRepository<Edition>
    {
        Task<IQueryable<Edition>> GetLastEditionsTop100();
    }
}
