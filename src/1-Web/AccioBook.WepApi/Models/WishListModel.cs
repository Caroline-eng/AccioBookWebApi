using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class WishListModel
    {
        public Int64 Id { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public DateTime IncludeDate { get; set; }
    }
}
