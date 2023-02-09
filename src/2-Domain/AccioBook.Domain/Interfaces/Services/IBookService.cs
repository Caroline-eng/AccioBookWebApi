using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IBookService : IDatabaseService<Book>
    {
        Task <IEnumerable<Book>> GetAllWithAuthorAndGenreAsync();
        Task <IEnumerable<Book>> GetBooksByAuthorAsync(string authorName);
    }
}
