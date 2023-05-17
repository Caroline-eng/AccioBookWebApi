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
        private readonly Aes _aes;

        public UserController(IUserService userService)
        {
            _userService = userService;

            _aes = Aes.Create();

            _aes.KeySize = 256; // usar um tamanho de chave de 256 bits
            _aes.BlockSize = 128; // usar um bloco de tamanho fixo de 128 bits

            byte[] key = Encoding.UTF8.GetBytes("uma chave fixa de 256 bits accio");
            byte[] iv = Encoding.UTF8.GetBytes("um iv fixo de128");

            _aes.Key = key;
            _aes.IV = iv;

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

        /// <summary>
        /// Valida o login de um usuário.
        /// </summary>     
        /// <returns></returns>  
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return BadRequest("Email inválido!");
            }

            string decryptedPassword = UserModel.DecryptPassword(password);
            if (user.IsPassword(decryptedPassword))
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Senha inválida!");
            }
        }
    }
}
