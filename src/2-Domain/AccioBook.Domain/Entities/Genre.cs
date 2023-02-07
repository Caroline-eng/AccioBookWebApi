namespace AccioBook.Domain.Entities
{
    public class Genre
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GenreSearch> GenreSearches { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
