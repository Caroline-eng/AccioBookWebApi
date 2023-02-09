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










        ///// <summary>
        ///// Atualiza um livro existente no banco
        ///// </summary>
        ///// <returns></returns>
        //[HttpPut("update")]
        //public async Task<IActionResult> Update(BookModel bookArgs)
        //{
        //    var book = await _bookService.GetAsync(bookArgs.Id);

        //    if (book == null)
        //    {
        //        return BadRequest();
        //    }

        //    book.Title = bookArgs.Title;
        //    book.Id_Author = bookArgs.Id_Author;
        //    book.Id_Genre = bookArgs.Id_Genre;


        //    Author author = new Author();
        //    author.Id = bookArgs.Author.Id;
        //    author.Name = bookArgs.Author.Name;
        //    book.Author = author;

        //    Genre genre = new Genre();
        //    genre.Id = bookArgs.Genre.Id;
        //    genre.Name = bookArgs.Genre.Name;
        //    book.Genre = genre;

        //    await _bookService.UpdateAsync(book);

        //    return Ok(book);
        //}







        ///// <summary>
        ///// Obtém livros de um autor específico
        ///// </summary>
        ///// <param name="authorId">Id do autor</param>
        ///// <returns></returns>
        //[HttpGet("GetBooksByAuthor/{authorId}")]
        //public async Task<IActionResult> GetBooksByAuthor(int authorId)
        //{
        //    var books = await _bookService.GetAsync(authorId);

        //    if (books == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(books);
        //}


        ///// <summary>
        ///// Obtém livros por título
        ///// </summary>        
        ///// <returns></returns>
        //[HttpGet("GetBooksByTitle/{title}")]
        //public async Task<IActionResult> GetBooksByTitle(string title)
        //{
        //    var books = await _bookService.GetAsync(l => l.Title.Equals(title) || l.Title.Contains(title));

        //    if (books == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(books);
        //}


        ///// <summary>
        ///// Obtém livros por ISBN
        ///// </summary>        
        ///// <returns>Lista de livros escritos pelo autor</returns>
        //[HttpGet("GetBooksByISBN/{ISBN}")]
        //public async Task<IActionResult> GetBooksByISBN(string ISBN)
        //{
        //    try
        //    {


        //        var edition = await _editionService.GetAllAsync(e => e.ISBNCode_10 == ISBN || e.ISBNCode_13 == ISBN);

        //        if (!edition.Any())
        //        {
        //            return null;
        //        }

        //        var books = await _bookService.GetAsync(b => b.Editions == edition);


        //        if (books == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(books);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}





        ///// <summary>
        ///// Obtém livros por Gênero
        ///// </summary>        
        ///// <returns>Lista de livros escritos pelo autor</returns>
        //[HttpGet("GetBooksByGenre/{IdGenre}")]
        //public async Task<IActionResult> GetBooksByGenre(int IdGenre)
        //{
        //    try
        //    {
        //        var books = await _bookService.GetAsync(IdGenre);

        //        if (books == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(books);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
