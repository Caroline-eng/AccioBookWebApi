namespace AccioBook.Domain.Entities
{
    public class Author
    {
        public Int64 Id { get; set; }        
        public string Name { get; set; }
        public virtual ICollection<AuthorSearch> AuthorSearches { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
