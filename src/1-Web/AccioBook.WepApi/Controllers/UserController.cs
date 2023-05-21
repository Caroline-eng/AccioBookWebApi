using AccioBook.CrossCutting.Criptografy;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.Domain.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata;

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
            var existingUser = await _userService.GetUserByEmail(userArgs.Email);
            if (existingUser != null)
            {
                return BadRequest("O email já está em uso.");
            }


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
        /// Deletar usuário
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteBook(Int64 userId)
        {

            try
            {
                await _userService.DeleteAsync(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera um usuário no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Update(Int64 userId, UserModel userArgs)
        {

            var user = await _userService.GetAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = userArgs.Name;
            user.Email = userArgs.Email;
            user.DateOfBirth = userArgs.DateOfBirth;

            await _userService.UpdateAndSaveAsync(user);

            return Ok(user);
        }


        /// <summary>
        /// Valida o login de um usuário.
        /// </summary>     
        /// <returns></returns>  
        [HttpPost("login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, [SwaggerSchema(Format = "password")] string password)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user == null)
            {
                return BadRequest("Email inválido!");
            }

            var userPassword = user.Password.Decrypt();

            if (!userPassword.Equals(password))
                BadRequest("Senha inválida!");

            return Ok(user);
        }
    }
}





