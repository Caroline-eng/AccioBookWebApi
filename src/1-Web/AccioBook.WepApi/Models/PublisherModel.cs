using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class PublisherModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Edition> EditionsPub { get; set; }
    }
}
