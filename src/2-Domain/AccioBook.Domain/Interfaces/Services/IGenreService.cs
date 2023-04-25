using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IGenreService : IDatabaseService<Genre>
    {
        Task<IEnumerable<Genre>> GetGenreByNameAsync(string genreName);
        Task<IEnumerable<Genre>> GetLastGenreTop100();
    }
}
