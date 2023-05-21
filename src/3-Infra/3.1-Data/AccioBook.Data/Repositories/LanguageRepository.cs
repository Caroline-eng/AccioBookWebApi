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

        public Task<IQueryable<Language>> GetLanguageByNameAsync(string languageName)
        {
            var context = (AccioBookContext)_context;
            var entities = context.Languages;
            return Task.Run(() => { return entities.Where(x => x.Name.Equals(languageName) || x.Name.Contains(languageName)); });
        }

        public Task<IQueryable<Language>> GetLastLanguageTop100()
        {

            var context = (AccioBookContext)_context;
            var entities = context.Languages;
            return Task.Run(() => { return entities.OrderByDescending(x => x.Id).Take(100); });
        }
    }
}
