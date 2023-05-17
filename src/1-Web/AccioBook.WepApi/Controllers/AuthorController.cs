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
        /// Deleta um autor do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(Int64 authorId)
        {

            try
            {
                await _authorService.DeleteAsync(authorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera um autor no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{authorId}")]
        public async Task<IActionResult> UpdateAuthor(Int64 authorId, AuthorModel authorArgs)
        {

            var author = await _authorService.GetAsync(authorId);

            if (author == null)
            {
                return NotFound();
            }

            author.Name = authorArgs.Name;
            

            await _authorService.UpdateAndSaveAsync(author);

            return Ok(author);
        }

        /// <summary>
        /// Retorna os últimos 100 autores 
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetAuthorsLast100()
        {
            try
            {
                var author = await _authorService.GetLastAuthorsTop100();
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        /// <summary>
        ///Pesquisa por autor
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{authorName}")]
        public async Task<IActionResult> GetAuthorByName(string authorName)
        {
            try
            {
                var author = await _authorService.GetAuthorByNameAsync(authorName);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
