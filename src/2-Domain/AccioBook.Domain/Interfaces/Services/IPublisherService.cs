using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IPublisherService : IDatabaseService<Publisher>
    {
        Task<IEnumerable<Publisher>> GetPublisherByNameAsync(string publisherName);
        Task<IEnumerable<Publisher>> GetLastPublishersTop100();
    }
}
