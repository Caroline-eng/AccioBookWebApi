using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class LanguageService : DatabaseService<Language>, ILanguageService
    {
        public LanguageService(ILanguageRepository repository) : base(repository)
        {

        }
    }
}
