using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Repositories;
using AccioBook.Domain.Services;
using Moq;

namespace AccioBookTest
{
    public class BookTest
    {
        [Fact]
        public void GetBooksByTitleAsyncTest()
        {
            Moq.Mock<IBookRepository> mock = new Moq.Mock<IBookRepository>();
            //mock.Setup(x => x.GetBooksByTitleAsync(It.IsAny<string>())).Returns("Teste");
            BookService bookServ = new BookService(mock.Object);

            //Task<IQueryable<Book>> op = bookServ.GetBooksByTitleAsync("Test")

           //(string title) op = bookServ.GetBooksByTitleAsync("Test")

           //Assert.Equal("Test", op.Task<IQueryable<Book>>);

           //Assert.Equal("Test", op.title); 

        }
    }
}