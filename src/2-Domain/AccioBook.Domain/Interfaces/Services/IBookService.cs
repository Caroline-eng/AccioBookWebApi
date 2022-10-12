using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IBookService : IDatabaseService<Book>
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBook(int id);        


    }
}
