using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.Domain.Entities
{
    public class BookSearch
    {
        public Int64 Id { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public DateTime SearchDate { get; set; }
        public Int64 Id_User { get; set; }
        public User User { get; set; }

    }
}
