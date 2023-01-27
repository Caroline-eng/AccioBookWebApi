using AccioBook.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class GenreSearchController : ControllerBase
    {
        private readonly IGenreSearchService _genreSearchService;
        public GenreSearchController(IGenreSearchService genreSearchService)
        {
            _genreSearchService = genreSearchService;
        }
    }
}
