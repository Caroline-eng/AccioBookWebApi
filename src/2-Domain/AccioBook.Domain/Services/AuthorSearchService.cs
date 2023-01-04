using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class AuthorSearchService : DatabaseService<AuthorSearch>, IAuthorSearchService
    {
        public AuthorSearchService(IAuthorSearchRepository repository) : base(repository)
        {

        }
    }
}
