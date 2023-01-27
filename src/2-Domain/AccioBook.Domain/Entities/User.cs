using AccioBook.Domain.Enums;

namespace AccioBook.Domain.Entities
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Password { get; set; }
        public UserGender UserGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email  { get; set; }
        public virtual ICollection<BookSearch> BookSearches { get; set; }
        public virtual ICollection<AuthorSearch> AuthorSearches { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<Access> AccessA { get; set; }
        public virtual ICollection<GenreSearch> GenreSearches { get; set; }
    }
} 
