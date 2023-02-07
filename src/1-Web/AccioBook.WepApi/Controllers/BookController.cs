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
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IEditionService _editionService;
        private readonly IPublisherService _publisherService;
        private readonly ILanguageService _languageService;


        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService,
            IEditionService editionService, IPublisherService publisherService, ILanguageService languageService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
            _editionService = editionService;
            _publisherService = publisherService;
            _languageService = languageService;
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

            /*Author author = new Author();
            author.Id = bookArgs.Author.Id;
            author.Name = bookArgs.Author.Name;
            book.Author = author;

            Genre genre = new Genre();
            genre.Id = bookArgs.Genre.Id;
            genre.Name = bookArgs.Genre.Name;
            book.Genre = genre;*/


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
        [HttpDelete("delete")]
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

        /// <summary>
        /// Atualiza um livro existente no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(BookModel bookArgs)
        {
            var book = await _bookService.GetAsync(bookArgs.Id);

            if (book == null)
            {
                return BadRequest();
            }

            book.Title = bookArgs.Title;
            book.Id_Author = bookArgs.Id_Author;
            book.Id_Genre = bookArgs.Id_Genre;
            

            Author author = new Author();
            author.Id = bookArgs.Author.Id;
            author.Name = bookArgs.Author.Name;
            book.Author = author;

            Genre genre = new Genre();
            genre.Id = bookArgs.Genre.Id;
            genre.Name = bookArgs.Genre.Name;
            book.Genre = genre;

            await _bookService.UpdateAsync(book);

            return Ok(book);
        }

        /// <summary>
        /// Insere um novo autor no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPost("insertAuthor")]
        public async Task<IActionResult> InsertAuthor(AuthorModel authorArgs)
        {
            var author = new Author();

            author.Id = authorArgs.Id;
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
        [HttpDelete("deleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(AuthorModel authorArgs)
        {
            var author = new Author();

            author.Id = authorArgs.Id;

            try
            {
                await _authorService.DeleteAsync(author.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um autor existente no banco
        /// </summary>        
        /// <returns></returns>
        [HttpPut("updateAuthor")]
        public async Task<IActionResult> UpdateAuthor(AuthorModel authorArgs)
        {
            var author = await _authorService.GetAsync(authorArgs.Id);

            if (author == null)
            {
                return BadRequest();
            }

            author.Name = authorArgs.Name;

            await _authorService.UpdateAsync(author);

            return Ok(author);
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


        /// <summary>
        /// Insere uma nova edição.
        /// </summary>     
        /// <returns></returns>

        [HttpPost("insertEdition")]
        public async Task<IActionResult> InsertEdition(EditionModel editionArgs)
        {
            var edition = new Edition();

            edition.Id = editionArgs.Id;
            edition.Id_Book = editionArgs.Id_Book;
            edition.Id_Publisher = editionArgs.Id_Publisher;
            edition.Id_Language = editionArgs.Id_Language;
            edition.Cover = editionArgs.Cover;
            edition.PublicationDate = editionArgs.PublicationDate;            
            edition.PageCount = editionArgs.PageCount;
            edition.ISBNCode_10 = editionArgs.ISBNCode_10;
            edition.ISBNCode_13 = editionArgs.ISBNCode_13;

            Book book = new Book();
            book.Id = editionArgs.Book.Id;
            book.Title = editionArgs.Book.Title;
            edition.Book = book;

            Publisher publisher = new Publisher();
            publisher.Id = editionArgs.Publisher.Id;
            publisher.Name = editionArgs.Publisher.Name;
            edition.Publisher = publisher;

            Language language = new Language();
            language.Id = editionArgs.Language.Id;
            language.Name = editionArgs.Language.Name;
            edition.Language = language;


            edition = await _editionService.AddAndSaveAsync(edition);

            if (edition.Id != default(int))
            {
                return Ok(edition);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma edição do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteEdition")]
        public async Task<IActionResult> DeleteEdition(EditionModel editionArgs)
        {
            var edition = new Edition();

            edition.Id = editionArgs.Id;

            try
            {
                await _editionService.DeleteAsync(edition.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma edição existente no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPut("updateEdition")]
        public async Task<IActionResult> UpdateEdition(EditionModel editionArgs)
        {
            var edition = await _editionService.GetAsync(editionArgs.Id);

            if (edition == null)
            {
                return NotFound();
            }

            edition.Id = editionArgs.Id;
            edition.Id_Book = editionArgs.Id_Book;
            edition.Id_Publisher = editionArgs.Id_Publisher;
            edition.Id_Language = editionArgs.Id_Language;
            edition.Cover = editionArgs.Cover;
            edition.PublicationDate = editionArgs.PublicationDate;
            edition.PageCount = editionArgs.PageCount;
            edition.ISBNCode_10 = editionArgs.ISBNCode_10;
            edition.ISBNCode_13 = editionArgs.ISBNCode_13;

            Book book = new Book();
            book.Id = editionArgs.Book.Id;
            book.Title = editionArgs.Book.Title;
            edition.Book = book;

            Publisher publisher = new Publisher();
            publisher.Id = editionArgs.Publisher.Id;
            publisher.Name = editionArgs.Publisher.Name;
            edition.Publisher = publisher;

            Language language = new Language();
            language.Id = editionArgs.Language.Id;
            language.Name = editionArgs.Language.Name;
            edition.Language = language;

            try
            {
                await _editionService.UpdateAndSaveAsync(edition);
                return Ok(edition);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insere um nova linguagem no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPost("insertLanguage")]
        public async Task<IActionResult> InsertLanguage(LanguageModel languageArgs)
        {
            var language = new Language();

            language.Id = languageArgs.Id;
            language.Name = languageArgs.Name;

            language = await _languageService.AddAndSaveAsync(language);

            if (language.Id != default(int))
            {
                return Ok(language);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma linguagem do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteLanguage")]
        public async Task<IActionResult> DeleteLanguage(LanguageModel languageArgs)
        {
            var language = new Language();

            language.Id = languageArgs.Id;

            try
            {
                await _languageService.DeleteAsync(language.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma linguagem existente no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPut("updateLanguage")]
        public async Task<IActionResult> UpdateLanguage(LanguageModel languageArgs)
        {
            var language = new Language();

            language.Id = languageArgs.Id;
            language.Name = languageArgs.Name;

            try
            {
                await _languageService.UpdateAsync(language);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insere um nova editora no banco.
        /// </summary>     
        /// <returns></returns>

        [HttpPost("insertPublisher")]
        public async Task<IActionResult> InsertPublisher(PublisherModel publisherArgs)
        {
            var publisher = new Publisher();

            publisher.Id = publisherArgs.Id;
            publisher.Name = publisherArgs.Name;

            publisher = await _publisherService.AddAndSaveAsync(publisher);

            if (publisher.Id != default(int))
            {
                return Ok(publisher);
            }

            return BadRequest();
        }

        /// <summary>
        /// Deleta uma editora do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deletePublisher")]
        public async Task<IActionResult> DeletePublisher(PublisherModel publisherArgs)
        {
            var publisher = new Publisher();

            publisher.Id = publisherArgs.Id;

            try
            {
                await _publisherService.DeleteAsync(publisher.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma editora no banco.
        /// </summary>
        /// <returns></returns>
        [HttpPut("updatePublisher")]
        public async Task<IActionResult> UpdatePublisher(PublisherModel publisherArgs)
        {
            var publisher = new Publisher();

            publisher.Id = publisherArgs.Id;
            publisher.Name = publisherArgs.Name;

            publisher = await _publisherService.UpdateAndSaveAsync(publisher);

            if (publisher.Id != default(int))
            {
                return Ok(publisher);
            }

            return BadRequest();
        }

        /// <summary>
        /// Obtém livros de um autor específico
        /// </summary>
        /// <param name="authorId">Id do autor</param>
        /// <returns></returns>
        [HttpGet("GetBooksByAuthor/{authorId}")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            var books = await _bookService.GetAsync(authorId);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }


        /// <summary>
        /// Obtém livros por título
        /// </summary>        
        /// <returns></returns>
        [HttpGet("GetBooksByTitle/{title}")]
        public async Task<IActionResult> GetBooksByTitle(string title)
        {
            var books = await _bookService.GetAsync(l => l.Title.Equals(title) || l.Title.Contains(title));

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }


        /// <summary>
        /// Obtém livros por ISBN
        /// </summary>        
        /// <returns>Lista de livros escritos pelo autor</returns>
        [HttpGet("GetBooksByISBN/{ISBN}")]
        public async Task<IActionResult> GetBooksByISBN(string ISBN)
        {
            try
            {


                var edition = await _editionService.GetAllAsync(e => e.ISBNCode_10 == ISBN || e.ISBNCode_13 == ISBN);

                if (!edition.Any())
                {
                    return null;
                }

                var books = await _bookService.GetAsync(b => b.Editions == edition);


                if (books == null)
                {
                    return NotFound();
                }

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
        /// Obtém livros por Gênero
        /// </summary>        
        /// <returns>Lista de livros escritos pelo autor</returns>
        [HttpGet("GetBooksByGenre/{IdGenre}")]
        public async Task<IActionResult> GetBooksByGenre(int IdGenre)
        {
            try
            {
                var books = await _bookService.GetAsync(IdGenre);

                if (books == null)
                {
                    return NotFound();
                }

                return Ok(books);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
