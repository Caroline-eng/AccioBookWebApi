using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class GenreSearchModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public Int64 Id_Genre { get; set; }
        public Genre Genre { get; set; }
    }
}
