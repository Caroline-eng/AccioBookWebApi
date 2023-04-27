using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("user")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Insere um novo usuário no banco.
        /// </summary>     
        /// <returns></returns>        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(UserModel userArgs)
        {
            var user = new User();

            user.Name = userArgs.Name;
            user.UserType = userArgs.UserType;
            user.Password = userArgs.Password;
            user.UserGender = userArgs.UserGender;
            user.DateOfBirth = userArgs.DateOfBirth;
            user.Email = userArgs.Email;

            user = await _userService.AddAndSaveAsync(user);

            if (user.Id != default(int))
            {
                return Ok(user);
            }

            return BadRequest();

        }

        /*[HttpPost("login")]
        public async Task<IActionResult> Login(string email, UserModel userArgs)
        {
            
        }*/

    }
}
