using AccioBook.CrossCutting.Criptografy;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Enums;

namespace AccioBook.WepApi.Models
{
    public class UserModel
    {
        public static string PASS_KEY { get { return "ACCIO_WEB"; } }
        public Int64 Id { get; set; }
        public string Name { get; set;}
        public UserType UserType { get; set; }
        public UserGender UserGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        private string _password;
        public string Password { 
            get 
            {
                return DecryptPassword(_password);
            }
            set 
            {
                _password = value;
            } 
        }

        public static string DecryptPassword(string encriptedPassword)
        {
            return encriptedPassword.Decrypt(PASS_KEY);
        }
    }
}
