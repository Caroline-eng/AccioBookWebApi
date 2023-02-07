namespace AccioBook.Domain.Entities
{
    public class Book
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public Int64 Id_Author { get; set; }
        public Author Author  { get; set; }
        public Int64 Id_Genre { get; set; }
        public Genre Genre { get; set; }        
        public virtual ICollection<BookSearch> BookSearches { get; set; }
        public virtual ICollection<Edition> Editions { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
