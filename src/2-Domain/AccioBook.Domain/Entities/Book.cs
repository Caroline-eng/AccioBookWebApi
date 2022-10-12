using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int PageCount { get; set; } 

        public DateTime PublishingDate { get; set; }


    }
}
