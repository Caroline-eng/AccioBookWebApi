using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccioBook.Data.Models.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name);                    
        }
    }
}
