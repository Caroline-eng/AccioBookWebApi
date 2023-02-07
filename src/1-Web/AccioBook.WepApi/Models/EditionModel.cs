using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class EditionModel
    {
        public Int64 Id { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public Int64 Id_Publisher { get; set; }
        public Publisher Publisher { get; set; }
        public Int64 Id_Language { get; set; }
        public Language Language { get; set; }
        public string Cover { get; set; }
        public DateTime PublicationDate { get; set; }
        public Int64 PageCount { get; set; }
        public string ISBNCode_10 { get; set; }
        public string ISBNCode_13 { get; set; }
    }
}
