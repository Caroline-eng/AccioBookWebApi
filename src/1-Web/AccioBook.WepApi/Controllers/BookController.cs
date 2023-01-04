using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Insere um livro no banco 
        /// </summary>
        /// <param name="bookArgs"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(BookModel bookArgs)
        {
            var book = new Book();
            
            book.Title = bookArgs.Title;
            book.Id_Author = bookArgs.Id_Author;
            book.Cover = bookArgs.Cover;
            
                 
            book = await _bookService.AddAndSaveAsync(book);

            if (book.Id != default(int))
            {
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Retorna livros que o Título contém Harry Potter e número de páginas maior que 200.
        /// </summary>     
        /// <returns></returns>

        [HttpGet("filter")]
        public async Task<IActionResult> GetBooksFilter()
        {
            try
            {                
                var books =  await _bookService.GetAllAsync(l => l.Title.Contains("Harry Potter") && l.PageCount > 200);
                return Ok(books);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        /// <summary>
        /// Retorna uma lista de Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetBooks()
        {            
            try
            {
                var books = await _bookService.GetAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta um livro 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("all")]
        public async Task<IActionResult> DeleteBook(BookModel bookArgs)
        {
            var book = new Book();

            book.Id = bookArgs.Id;

            try
            {
                await _bookService.DeleteAsync(book.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }            
           
    }
}
