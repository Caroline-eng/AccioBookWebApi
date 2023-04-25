using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IQueryable<Genre>> GetGenreByNameAsync(string genreName);
        Task<IQueryable<Genre>> GetLastGenreTop100();
    }
}
