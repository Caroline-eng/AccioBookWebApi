using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
