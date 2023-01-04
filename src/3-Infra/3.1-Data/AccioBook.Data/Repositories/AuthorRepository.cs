using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
