using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class AuthorService : DatabaseService<Author>, IAuthorService
    {
        public AuthorService(IAuthorRepository repository) : base(repository)
        {

        }
    }

}
