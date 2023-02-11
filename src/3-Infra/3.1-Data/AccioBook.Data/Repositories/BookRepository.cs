using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AccioBookContext context) : base(context)
        {

        }

        public Task<IQueryable<Book>> GetAllWithAuthorAndGenreAsync()
        {
            var context = (AccioBookContext) _context;

            var entities = context.Books.Include(x => x.Author).Include(x => x.Genre).AsNoTracking();

            return Task.Run(() => { return entities;} );
        }

        public Task<IQueryable<Book>> GetBooksByAuthorAsync(string authorName)
        {
            var context = (AccioBookContext)_context;

            var entities = context.Books.Include(x => x.Author).Include(x => x.Genre).AsNoTracking();

            return Task.Run(() => { return entities.Where(x => x.Author.Name.Equals(authorName) || x.Author.Name.Contains(authorName)); });
        }

        public Task<IQueryable<Book>> GetBooksByTitleAsync(string bookTitle)
        {
            var context = (AccioBookContext)_context;
            var entities = context.Books.Include(x => x.Author).Include(x => x.Genre).AsNoTracking();

            return Task.Run(() => { return entities.Where(x => x.Title.Equals(bookTitle) || x.Title.Contains(bookTitle)); });

        }
    }
}
