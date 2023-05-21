using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class GenreModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }
}
