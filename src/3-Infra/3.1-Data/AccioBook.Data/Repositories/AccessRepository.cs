using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class AccessRepository : Repository<Access>, IAccessRepository
    {
        public AccessRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
