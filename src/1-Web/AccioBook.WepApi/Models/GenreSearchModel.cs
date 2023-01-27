using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class GenreSearchModel
    {
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public Int64 Id_Genre { get; set; }
        public Genre Genre { get; set; }
    }
}
