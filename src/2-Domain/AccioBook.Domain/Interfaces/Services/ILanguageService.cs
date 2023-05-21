using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Services
{
    public interface ILanguageService : IDatabaseService<Language>
    {
        Task<IEnumerable<Language>> GetLanguageByNameAsync(string languageName);
        Task<IEnumerable<Language>> GetLastLanguageTop100();
    }
}
