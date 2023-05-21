using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<IQueryable<Language>> GetLanguageByNameAsync(string languageName);
        Task<IQueryable<Language>> GetLastLanguageTop100();
    }
}
