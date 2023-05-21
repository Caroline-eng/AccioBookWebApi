using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class EditionModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public Int64 Id_Book { get; set; }       
        public Int64 Id_Publisher { get; set; }      
        public Int64 Id_Language { get; set; }      
        public string Cover { get; set; }
        public DateTime PublicationDate { get; set; }
        public Int64 PageCount { get; set; }
        public string ISBNCode_10 { get; set; }
        public string ISBNCode_13 { get; set; }
    }
}
