using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        Task<IQueryable<Publisher>> GetLastPublishersTop100();
        Task<IQueryable<Publisher>> GetPublisherByNameAsync(string publisherName);
    }
}
