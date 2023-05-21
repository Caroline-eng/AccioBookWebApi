using AccioBook.CrossCutting.Criptografy;
using AccioBook.Domain.Entities;
using AccioBook.Domain.Enums;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    /// 
    /// 
    /// 
    public class UserModel
    {

        [JsonIgnore]
        public Int64 Id { get; set; }
        public string Name { get; set;}
        public UserType UserType { get; set; }
        public UserGender UserGender { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Email { get; set; }       
        public string Password { get; set; }
    }
}