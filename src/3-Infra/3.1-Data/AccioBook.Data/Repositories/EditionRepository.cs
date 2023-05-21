using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class EditionRepository : Repository<Edition>, IEditionRepository
    {
        public EditionRepository(AccioBookContext context) : base(context)
        {

        }
              

        public Task<IQueryable<Edition>> GetLastEditionsTop100()
        {
            var context = (AccioBookContext)_context;
            var entities = context.Editions;
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }
    }
}
