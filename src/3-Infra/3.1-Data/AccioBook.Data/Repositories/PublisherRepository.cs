using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using System.Linq;

namespace AccioBook.Data.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AccioBookContext context) : base(context)
        {

        }

        public Task<IQueryable<Publisher>> GetLastPublishersTop100()
        {
            var context = (AccioBookContext)_context;
            var entities = context.Publishers;
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }

        public Task<IQueryable<Publisher>> GetPublisherByNameAsync(string publisherName)
        {
            var context = (AccioBookContext)_context;
            var entities = context.Publishers;
            return Task.Run(() => { return entities.Where(x => x.Name.Equals(publisherName) || x.Name.Contains(publisherName)); });
        }

       
    }
}
