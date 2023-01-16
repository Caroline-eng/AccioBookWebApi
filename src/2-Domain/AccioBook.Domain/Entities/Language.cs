namespace AccioBook.Domain.Entities
{
    public class Language
    {
        public Int64 Id { get; set; }
        public string Name  { get; set; }
        public virtual ICollection<Edition> Editions{ get; set; }
    }
}
