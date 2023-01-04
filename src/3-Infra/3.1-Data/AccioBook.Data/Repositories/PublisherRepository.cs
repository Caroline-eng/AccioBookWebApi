using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
