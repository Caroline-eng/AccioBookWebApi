using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("genre")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Insere um novo gênero no banco.
        /// </summary>     
        /// <returns></returns>        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(GenreModel genreArgs)
        {
            var genre = new Genre();

            genre.Name = genreArgs.Name;


            genre = await _genreService.AddAndSaveAsync(genre);

            if (genre.Id != default(int))
            {
                return Ok(genre);
            }

            return BadRequest();
        }


        /// <summary>
        /// Deleta um autor do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{genreId}")]
        public async Task<IActionResult> DeleteGenre(Int64 genreId)
        {

            try
            {
                await _genreService.DeleteAsync(genreId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera um gênero no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{genreId}")]
        public async Task<IActionResult> UpdateGenre(Int64 genreId, GenreModel genreArgs)
        {

            var genre = await _genreService.GetAsync(genreId);

            if (genre == null)
            {
                return NotFound();
            }

            genre.Name = genreArgs.Name;


            await _genreService.UpdateAndSaveAsync(genre);

            return Ok(genre);
        }

        /// <summary>
        /// Retorna os últimos 100 gêneros 
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetGenreLast100()
        {
            try
            {
                var genre = await _genreService.GetLastGenreTop100();
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retorna toda lista de Gêneros
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetGenre()
        {
            try
            {
                var genre = await _genreService.GetAllAsync();
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Pesquisa por gênero
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{genreName}")]
        public async Task<IActionResult> GetGenreByName(string genreName)
        {
            try
            {
                var genre = await _genreService.GetGenreByNameAsync(genreName);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
