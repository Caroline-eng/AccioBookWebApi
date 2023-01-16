using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccioBook.Data.Models.Mapping
{
    public class AuthorSearchMap : IEntityTypeConfiguration<AuthorSearch>
    {
        public void Configure(EntityTypeBuilder<AuthorSearch> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id_Author);
            builder.Property(a => a.Id_User);

            builder.HasOne(a => a.Author)
                .WithMany(a => a.AuthorSearches)
                .HasForeignKey(a => a.Id_Author);

            builder.HasOne(a => a.User)
                .WithMany(a => a.AuthorSearches)
                .HasForeignKey(a => a.Id_User);
        }
    }
}
