using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class PublisherService : DatabaseService<Publisher>, IPublisherService
    {
        public PublisherService(IPublisherRepository repository) : base(repository)
        {

        }
    }
}
