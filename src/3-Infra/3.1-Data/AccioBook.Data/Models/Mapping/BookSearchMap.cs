using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccioBook.Data.Models.Mapping
{
    public class BookSearchMap : IEntityTypeConfiguration<BookSearch>
    {
        public void Configure(EntityTypeBuilder<BookSearch> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id_Book);
            builder.Property(a => a.SearchDate);
            builder.Property(a => a.Id_User);

            builder.HasOne(a => a.Book)
               .WithMany(a => a.BookSearches)
               .HasForeignKey(a => a.Id_Book);

            builder.HasOne(a => a.User)
               .WithMany(a => a.UserSearches)
               .HasForeignKey(a => a.Id_User);
        }
    }
}
