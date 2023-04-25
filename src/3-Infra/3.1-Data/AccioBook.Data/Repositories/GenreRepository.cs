using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(AccioBookContext context) : base(context)
        {

        }

        public Task<IQueryable<Genre>> GetGenreByNameAsync(string genreName)
        {
            var context = (AccioBookContext)_context;
            var entities = context.Genre;
            return Task.Run(() => { return entities.Where(x => x.Name.Equals(genreName) || x.Name.Contains(genreName)); });
        }

        public Task<IQueryable<Genre>> GetLastGenreTop100()
        {
            var context = (AccioBookContext)_context;
            var entities = context.Genre;
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }
    }
}
