using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class BookModel
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public Int64 Id_Author { get; set; }
        public Int64 Id_Genre { get; set; }        
        public AuthorModel Author { get; set; }
        public GenreModel Genre { get; set; }
       
    }
}
