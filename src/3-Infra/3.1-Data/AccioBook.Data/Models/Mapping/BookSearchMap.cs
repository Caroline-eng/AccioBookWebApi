using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
               .WithMany(a => a.BookSearches)
               .HasForeignKey(a => a.Id_User);
        }
    }
}
