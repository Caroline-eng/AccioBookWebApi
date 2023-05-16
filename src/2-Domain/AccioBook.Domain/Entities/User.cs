using AccioBook.CrossCutting.Criptografy;
using AccioBook.Domain.Enums;
using System.Diagnostics.CodeAnalysis;

namespace AccioBook.Domain.Entities
{
    public class User
    {
        public static string PASS_KEY { get { return "ACCIO_BD"; } }

        public Int64 Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public UserGender UserGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email  { get; set; }
        public virtual ICollection<BookSearch> BookSearches { get; set; }
        public virtual ICollection<AuthorSearch> AuthorSearches { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<Access> AccessA { get; set; }
        public virtual ICollection<GenreSearch> GenreSearches { get; set; }

        private string _password;
        public string Password 
        { 
            get 
            {
                return _password;
            }
            set 
            {
                _password = value.Encrypt(PASS_KEY);
            } 
        }

        public bool IsPassword(string password)
        {
            return _password.Decrypt(PASS_KEY) == password;
        }
    }
} 
