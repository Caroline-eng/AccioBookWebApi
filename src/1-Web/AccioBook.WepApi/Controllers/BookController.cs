using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        ///Altera um livro no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{bookId}")]
        public async Task<IActionResult> Update(Int64 bookId, BookModel bookArgs)
        {           

            var book = await _bookService.GetAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookArgs.Title;            
            book.Id_Author = bookArgs.Id_Author;
            book.Id_Genre = bookArgs.Id_Genre;
            book.Description = bookArgs.Description;

            await _bookService.UpdateAndSaveAsync(book);

            return Ok(book);
        }       

        /// <summary>
        ///Altera o título do livro no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/title/{bookId}")]
        public async Task<IActionResult> UpdateBookTitle(Int64 bookId, [FromBody] BookModel bookArgs)
        {
            try
            {
                var book = await _bookService.GetAsync(bookId);

                if (book == null)
                {
                    return NotFound();
                }

                book.Title = bookArgs.Title;

                await _bookService.UpdateAndSaveAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera a descrição do livro no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/description/{bookId}")]
        public async Task<IActionResult> UpdateBookDescription(Int64 bookId, [FromBody] BookModel bookArgs)
        {
            try
            {
                var book = await _bookService.GetAsync(bookId);

                if (book == null)
                {
                    return NotFound();
                }

                book.Description = bookArgs.Description;

                await _bookService.UpdateAndSaveAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera o gênero do livro no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/genre/{bookId}")]
        public async Task<IActionResult> UpdateBookGenre(Int64 bookId, [FromBody] BookModel bookArgs)
        {
            try
            {
                var book = await _bookService.GetAsync(bookId);

                if (book == null)
                {
                    return NotFound();
                }
               
                book.Id_Genre = bookArgs.Id_Genre;

                await _bookService.UpdateAndSaveAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera o autor do livro no banco
        /// </summary>
        /// <returns></returns>       
        [HttpPut("update/author/{bookId}")]
        public async Task<IActionResult> UpdateBookAuthor(Int64 bookId, [FromBody] BookModel bookArgs)
        {
            try
            {
                var book = await _bookService.GetAsync(bookId);

                if (book == null)
                {
                    return NotFound();
                }              
                               
                book.Id_Author = bookArgs.Id_Author;

                await _bookService.UpdateAndSaveAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       

        /// <summary>
        /// Retorna os últimos 100 livros 
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

        /// <summary>
        ///Pesquisa de livro com parâmetros
        /// </summary>
        /// <returns></returns>
        [HttpGet("searchParams/{filter}")]
        public async Task<IActionResult> GetBooksByParams(string filter)
        {

            try
            {
                var book = await _bookService.GetBooksByParamsAsync(filter);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




    }
}
