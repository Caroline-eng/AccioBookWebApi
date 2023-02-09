using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class BookModel
    {
        public string Title { get; set; }
        public Int64 Id_Author { get; set; }
        public Int64 Id_Genre { get; set; }        
               
    }
}
