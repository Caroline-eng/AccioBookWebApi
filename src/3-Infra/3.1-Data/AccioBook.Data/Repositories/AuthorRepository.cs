using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AccioBookContext context) : base(context)
        {

        }

        public Task<IQueryable<Author>> GetAuthorByNameAsync(string authorName)
        {
            var context = (AccioBookContext)_context;
            var entities = context.Authors;
            return Task.Run(() => { return entities.Where(x => x.Name.Equals(authorName) || x.Name.Contains(authorName)); });
        }

        public Task<IQueryable<Author>> GetLastAuthorsTop100()
        {
            var context = (AccioBookContext)_context;
            var entities = context.Authors;
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }

        
    }
}
