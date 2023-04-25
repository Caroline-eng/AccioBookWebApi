using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.Domain.Services
{
    public class GenreService : DatabaseService<Genre>, IGenreService
    {
        public GenreService(IGenreRepository repository) : base(repository)
        {

        }

        public async Task<IEnumerable<Genre>> GetGenreByNameAsync(string genreName)
        {
            var repo = (IGenreRepository)_repository;
            return await repo.GetGenreByNameAsync(genreName);
        }

        public async Task<IEnumerable<Genre>> GetLastGenreTop100()
        {
            var repo = (IGenreRepository)_repository;
            return await repo.GetLastGenreTop100();
        }
    }
}
