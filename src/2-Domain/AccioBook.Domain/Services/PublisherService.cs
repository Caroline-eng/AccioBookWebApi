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

        public async Task<IEnumerable<Publisher>> GetLastPublishersTop100()
        {
            var repo = (IPublisherRepository)_repository;
            return await repo.GetLastPublishersTop100();
          
        }

        public async Task<IEnumerable<Publisher>> GetPublisherByNameAsync(string publisherName)
        {
            var repo = (IPublisherRepository)_repository;
            return await repo.GetPublisherByNameAsync(publisherName);
        }
    }
}
