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

        public async Task<IEnumerable<Book>> GetAllWithAuthorAndGenreAsync()
        {
            var repo = (IBookRepository) _repository;

            return await repo.GetAllWithAuthorAndGenreAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string authorName)
        {
            var repo = (IBookRepository)_repository;

            return await repo.GetBooksByAuthorAsync(authorName);
        }
    }
}
