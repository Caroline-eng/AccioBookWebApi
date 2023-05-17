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

        public async Task<IEnumerable<Author>> GetAuthorByNameAsync(string authorName)
        {
            var repo = (IAuthorRepository)_repository;
            return await repo.GetAuthorByNameAsync(authorName);
        }

        public async Task<IEnumerable<Author>> GetLastAuthorsTop100()
        {
            var repo = (IAuthorRepository)_repository;
            return await repo.GetLastAuthorsTop100();
        }
    }

}
