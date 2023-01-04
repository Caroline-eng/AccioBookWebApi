using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class EditionRepository : Repository<Edition>, IEditionRepository
    {
        public EditionRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
