using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IQueryable<Author>> GetAuthorByNameAsync(string authorName);
        Task<IQueryable<Author>> GetLastAuthorsTop100();
    }
}
