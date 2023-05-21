using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class BookSearchModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public DateTime SearchDate { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }

    }
}
