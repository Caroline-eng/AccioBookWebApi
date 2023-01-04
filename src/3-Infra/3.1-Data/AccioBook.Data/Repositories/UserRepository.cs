using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
