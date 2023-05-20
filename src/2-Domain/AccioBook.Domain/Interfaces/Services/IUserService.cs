using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface IUserService : IDatabaseService<User>
    {
        Task<User> GetUserByEmail(string email);
       
    }
}

