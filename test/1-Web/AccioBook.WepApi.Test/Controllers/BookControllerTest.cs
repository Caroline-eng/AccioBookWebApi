using AccioBook.Data.Repositories;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Controllers;
using AccioBook.WepApi.Models;
using Microsoft.OpenApi.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.WepApi.Test.Controllers
{
    public class BookControllerTest
    {
        private readonly Mock<IBookRepository> _bookRepo;
        public BookControllerTest()
        {

            _bookRepo = new Mock<IBookRepository>();          
        }

        [Fact]
        public void InsertOk()
        {
            var book = new Book()
            {
                Id = 1,
                Title = "Como eu era antes de você",
                Id_Author = 1,
                Id_Genre = 1,
                Description = "Will Traynor, de 35 anos, é inteligente, rico e mal-humorado. Preso a uma cadeira de rodas depois de um acidente de moto, " +
                "o antes ativo e esportivo Will desconta toda a sua amargura em quem estiver por perto e planeja dar um fim ao seu sofrimento. O que Will " +
                "não sabe é que Lou está prestes a trazer cor a sua vida."
            };


            _bookRepo.As<IRepository<Book>>().Setup(x => x.AddAsync(It.IsAny<Book>())).Returns(Task.FromResult(book));
            IBookService bookServ = new BookService(_bookRepo.Object);
            BookController controller = new BookController(bookServ);

            var bookModel = new BookModel()
            {
                Title = book.Title,
                Id_Author = book.Id_Author,
                Id_Genre = book.Id_Genre,
                Description = book.Description
            };

            var insertedBook = controller.Insert(bookModel);


            Assert.Equal(book.Id, insertedBook.Id);
        }
    }
}
