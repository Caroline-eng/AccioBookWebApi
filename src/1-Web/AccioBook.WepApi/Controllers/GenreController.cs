using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
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

        /// <summary>
        /// Insere um novo gênero no banco.
        /// </summary>     
        /// <returns></returns>
        [HttpPost("insertGenre")]
        public async Task<IActionResult> InsertGenre(GenreModel genreArgs)
        {
            var genre = new Genre();

            genre.Id = genreArgs.Id;
            genre.Name = genreArgs.Name;

            genre = await _genreService.AddAndSaveAsync(genre);

            if (genre.Id != default(int))
            {
                return Ok(genre);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta um gênero do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteGenre")]
        public async Task<IActionResult> DeleteGenre(GenreModel genreArgs)
        {
            var genre = new Genre();

            genre.Id = genreArgs.Id;

            try
            {
                await _genreService.DeleteAsync(genre.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // <summary>
        /// Atualiza um gênero existente no banco.
        /// </summary>
        /// <param name="genreArgs"></param>
        /// <returns></returns>
        [HttpPut("updateGenre")]
        public async Task<IActionResult> UpdateGenre(GenreModel genreArgs)
        {
            var genre = await _genreService.GetAsync(genreArgs.Id);

            if (genre == null)
                return NotFound();

            genre.Name = genreArgs.Name;

            try
            {
                await _genreService.UpdateAsync(genre);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
