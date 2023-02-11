using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("book")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;    
      
        public BookController(IBookService bookService)
        {
            _bookService = bookService;           
        }

        /// <summary>
        /// Insere um novo livro no banco 
        /// </summary>
        /// <param name="bookArgs"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(BookModel bookArgs)
        {
            var book = new Book();

            book.Title = bookArgs.Title;
            book.Id_Author = bookArgs.Id_Author;
            book.Id_Genre = bookArgs.Id_Genre;
            book.Description = bookArgs.Description;

            book = await _bookService.AddAndSaveAsync(book);

            if (book.Id != default(int))
            {
                return Ok(book);
            }

            return BadRequest();
        }


        /// <summary>
        /// Deleta um livro do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{bookId}")]
        public async Task<IActionResult> DeleteBook(Int64 bookId)
        {       

            try
            {
                await _bookService.DeleteAsync(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna toda lista de Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetBooksLast100()
        {
            try
            {
                var books = await _bookService.GetLastBooksTop100();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna toda lista de Livros
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
        /// Retorna lista de livros com autores e gêneros
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-author-genre")]
        public async Task<IActionResult> GetBooksWithAuthorAndGenre()
        {
            try
            {
                var books = await _bookService.GetAllWithAuthorAndGenreAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retorna lista de livros por autor 
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-by-author/{authorName}")]
        public async Task<IActionResult> GetBooksByAuthor(string authorName)
        {
            try
            {
                var books = await _bookService.GetBooksByAuthorAsync(authorName);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Pesquisa por livro
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{bookTitle}")]
        public async Task<IActionResult> GetBooksByTitle(string bookTitle)
        {
            try
            {
                var book = await _bookService.GetBooksByTitleAsync(bookTitle);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
