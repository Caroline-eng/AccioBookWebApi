using AccioBook.Domain.Entities;
using AccioBook.Domain.Enums;

namespace AccioBook.WepApi.Models
{
    public class UserModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set;}
        public UserType UserType { get; set; }
        public string Password { get; set; }
        public UserGender UserGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public virtual ICollection<BookSearch> UserSearches { get; set; }

       
    }
}
