using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IAuthorService : IDatabaseService<Author>
    {
        Task<IEnumerable<Author>> GetAuthorByNameAsync(string bookTitle);
        Task<IEnumerable<Author>> GetLastAuthorsTop100();
    }
}
