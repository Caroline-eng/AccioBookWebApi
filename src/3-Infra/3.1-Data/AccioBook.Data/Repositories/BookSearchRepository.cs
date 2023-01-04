using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class BookSearchRepository : Repository<BookSearch>, IBookSearchRepository
    {
        public BookSearchRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
