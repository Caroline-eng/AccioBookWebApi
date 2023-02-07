using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class BookService : DatabaseService<Book>, IBookService
    {        
        public BookService(IBookRepository repository) : base(repository)
        {

        }       
    }
}
