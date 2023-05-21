using AccioBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace AccioBook.WepApi.Models
{
    public class AccessModel
    {
        [JsonIgnore]
        public Int64 Id { get; set; }

        public DateTime DateAccess { get; set; }
        public DateTime DateOff { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }
    }
}

