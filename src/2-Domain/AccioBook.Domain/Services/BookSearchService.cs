using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class BookSearchService : DatabaseService<BookSearch>, IBookSearchService
    {
        public BookSearchService(IBookSearchRepository repository) : base(repository)
        {

        }
    }
}
