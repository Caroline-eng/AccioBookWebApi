using AccioBook.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class AuthorController: ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
       
    }
}
