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
    [Route("author")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthorController: ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Insere um novo autor no banco.
        /// </summary>     
        /// <returns></returns>        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(AuthorModel authorArgs)
        {
            var author = new Author();

            author.Name = authorArgs.Name;


            author = await _authorService.AddAndSaveAsync(author);

            if (author.Id != default(int))
            {
                return Ok(author);
            }

            return BadRequest();
        }

        /// <summary>
        /// Retorna toda lista de Autores
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAuthor()
        {
            try
            {
                var author = await _authorService.GetAllAsync();
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
