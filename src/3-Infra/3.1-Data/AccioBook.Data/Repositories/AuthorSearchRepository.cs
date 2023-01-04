using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class AuthorSearchRepository : Repository<AuthorSearch>, IAuthorSearchRepository
    {
        public AuthorSearchRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
