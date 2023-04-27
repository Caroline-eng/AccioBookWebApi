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

            _aes.KeySize = 128; // usar um tamanho de chave de 128 bits
            _aes.BlockSize = 128; // usar um bloco de tamanho fixo de 128 bits

            _aes.GenerateKey(); // gerar uma chave aleatória
            _aes.GenerateIV(); // gerar um IV aleatório       
            
        }

        /// <summary>
        /// Insere um novo usuário no banco.
        /// </summary>     
        /// <returns></returns>        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(UserModel userArgs)
        {

            byte[] encrypted = EncryptStringToBytes(userArgs.Password, _aes);
            string decrypted = DecryptStringFromBytes(encrypted, _aes);

            Console.WriteLine($"Texto original: {userArgs.Password}");
            Console.WriteLine($"Texto criptografado: {Convert.ToBase64String(encrypted)}");
            Console.WriteLine($"Texto descriptografado: {decrypted}");

            var user = new User();
            user.Name = userArgs.Name;
            user.UserType = userArgs.UserType;
            user.Password = Convert.ToBase64String(encrypted);
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

        static byte[] EncryptStringToBytes(string plainText, Aes aes)
        {
            // Criar um objeto de criptografia para criptografar os dados
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            // Criptografar o texto original
            byte[] encrypted = null;
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                }

                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, Aes aes)
        {
            // Criar um objeto de criptografia para descriptografar os dados
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Descriptografar o texto criptografado
            string plaintext = null;
            using (var msDecrypt = new System.IO.MemoryStream(cipherText))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        /*[HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
             var user = await _userService.GetUserByEmail(email);

                if (user == null)
                {
                return BadRequest("Email ou senha inválidos");
                }
        }*/

    }
}
