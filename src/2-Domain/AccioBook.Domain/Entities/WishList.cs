namespace AccioBook.Domain.Entities
{
    public class WishList
    {
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public DateTime IncludeDate  { get; set; }
                   

    }
}
