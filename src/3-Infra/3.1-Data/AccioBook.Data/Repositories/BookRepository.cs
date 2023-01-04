using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
