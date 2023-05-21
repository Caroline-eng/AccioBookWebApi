using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
            var entities = context.Editions.Include(x => x.Book).Include(x => x.Language).Include(x => x.Publisher).AsNoTracking();
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }
    }
}
