using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;

namespace AccioBook.Domain.Services
{
    public class StatisticsService : DatabaseService<Statistics>, IStatisticsService
    {
        public StatisticsService(IStatisticsRepository repository) : base(repository)
        {

        }
    }
}
