using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class LanguageModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Edition> EditionsLang { get; set; }
    }
}
