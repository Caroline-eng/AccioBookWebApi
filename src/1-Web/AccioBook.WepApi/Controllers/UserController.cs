using AccioBook.CrossCutting.Criptografy;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

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
            user.Password = userArgs.Password.Encrypt();
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

        /// <summary>
        /// Valida o login de um usuário.
        /// </summary>     
        /// <returns></returns>  
        [HttpPost("login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return BadRequest("Email inválido!");
            }

            var userPassword = user.Password.Decrypt();

            if (!user.Password.Equals(password))
                BadRequest("Senha inválida!");

            return Ok(user);
        }


        ///// <summary>
        ///// Valida o login de um usuário.
        ///// </summary>     
        ///// <returns></returns>  
        //[HttpPost("login/{email}/{password}")]
        //public async Task<IActionResult> Login(UserModel userArgs)
        //{
        //    var user = await _userService.GetUserByEmail(userArgs.Email);

        //    if (user == null)
        //    {
        //        return BadRequest("Email inválido!");
        //    }

        //    var userPassword = user.Password.Decrypt();

        //    if (!userArgs.Password.Equals(userPassword))
        //        BadRequest("Senha inválida!");

        //    return Ok(user);
        //}
    }
}
