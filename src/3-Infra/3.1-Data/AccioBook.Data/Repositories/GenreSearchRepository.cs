using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class GenreSearchRepository : Repository<GenreSearch>, IGenreSearchRepository
    {
        public GenreSearchRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
