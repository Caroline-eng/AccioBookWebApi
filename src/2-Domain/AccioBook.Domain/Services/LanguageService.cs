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

        public async Task<IEnumerable<Language>> GetLanguageByNameAsync(string languageName)
        {
            var repo = (ILanguageRepository)_repository;
            return await repo.GetLanguageByNameAsync(languageName);
        }

        public async Task<IEnumerable<Language>> GetLastLanguageTop100()
        {
            var repo = (ILanguageRepository)_repository;
            return await repo.GetLastLanguageTop100();
        }
    }
}
