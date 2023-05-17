using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccioBook.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AccioBookContext context) : base(context)
        {

        }
        public async Task<User> GetUserByEmail(string email)
        {
            var context = (AccioBookContext)_context;
            var users = context.Users;

            return await users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
