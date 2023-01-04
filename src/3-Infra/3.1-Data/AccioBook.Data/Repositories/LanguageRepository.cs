using AccioBook.Data.Contexts;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;

namespace AccioBook.Data.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(AccioBookContext context) : base(context)
        {

        }
    }
}
