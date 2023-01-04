using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccioBook.Data.Models.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title);
            builder.Property(a => a.Id_Author);
            builder.Property(a => a.Cover);

            builder.HasOne(a => a.Author)
               .WithMany(a => a.Books)
               .HasForeignKey(a => a.Id_Author);
        }
    }
}
