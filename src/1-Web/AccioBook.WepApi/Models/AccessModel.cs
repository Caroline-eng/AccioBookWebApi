using AccioBook.Domain.Entities;

namespace AccioBook.WepApi.Models
{
    public class AccessModel
    {
        public Int64 Id { get; set; }
        public DateTime DateAccess { get; set; }
        public DateTime DateOff { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
    }
}

