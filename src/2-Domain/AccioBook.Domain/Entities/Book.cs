namespace AccioBook.Domain.Entities
{
    public class Book
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public Int64 Id_Author { get; set; }
        public Author Author  { get; set; }        
        public string Cover { get; set; }
        public virtual ICollection<BookSearch> BookSearches { get; set; }
        public virtual ICollection<Edition> Editions { get; set; }
        public virtual WishList BookList { get; set; }
    }
}
