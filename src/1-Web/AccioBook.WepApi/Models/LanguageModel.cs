using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class LanguageModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Edition> EditionsLang { get; set; }
    }
}
