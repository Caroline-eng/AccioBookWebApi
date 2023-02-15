using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class AuthorSearchModel
    {
        public Int64 Id { get; set; }
        public Int64 Id_Author { get; set; }
        public Author Author { get; set; }
        public DateTime SearchDate { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
       
    }
}
