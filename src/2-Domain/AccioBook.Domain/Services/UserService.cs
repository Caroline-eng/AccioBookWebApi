using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class UserService : DatabaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var repo = (IUserRepository)_repository;
            return await repo.GetUserByEmail(email);
        }

        
    }
}
