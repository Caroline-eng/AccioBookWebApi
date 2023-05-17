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

        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string bookTitle)
        {
            var repo = (IBookRepository)_repository;
            return await repo.GetBooksByTitleAsync(bookTitle);
        }

        public async Task<IEnumerable<Book>> GetBooksByParamsAsync(string filter)
        {
            var repo = (IBookRepository)_repository;
            return await repo.GetBooksByParamsAsync(filter);
        }

        public async Task<IEnumerable<Book>> GetLastBooksTop100()
        {
            var repo = (IBookRepository)_repository;
            return await repo.GetLastBooksTop100();
        }
    }
}
