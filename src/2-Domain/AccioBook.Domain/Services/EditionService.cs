using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class EditionService : DatabaseService<Edition>, IEditionService
    {
        public EditionService(IEditionRepository repository) : base(repository)
        {

        }
    }

}
