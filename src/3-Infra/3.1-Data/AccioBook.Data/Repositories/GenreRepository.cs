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
    }
}
