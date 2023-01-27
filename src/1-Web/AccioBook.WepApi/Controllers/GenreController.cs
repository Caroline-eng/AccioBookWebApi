using AccioBook.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
    }
}
