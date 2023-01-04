namespace AccioBook.Domain.Entities
{
    public class Publisher
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Edition> EditionsPub { get; set; }
    }
}
