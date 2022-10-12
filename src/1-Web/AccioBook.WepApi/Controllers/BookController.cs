using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
            book.PageCount = bookArgs.PageCount;
            book.PublishingDate = bookArgs.PublishingDate;

            book = await _bookService.AddAndSaveAsync(book);

            if (book.Id != default(int))
            {
                return Ok();
            }

            return BadRequest();            
        }

        /// <summary>
        /// Retorna uma lista de Livros 
        /// </summary>
        /// <param name="bookArgs"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult><IAsyncEnumerable<Book>>> GetBooks()
        {
            try
            {
               
            }
            catch
            {

            }           
        }
    }
}
