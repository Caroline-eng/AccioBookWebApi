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
    public class AuthorSearchMap : IEntityTypeConfiguration<AuthorSearch>
    {
        public void Configure(EntityTypeBuilder<AuthorSearch> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id_Author);

            builder.HasOne(a => a.Author)
                .WithMany(a => a.AuthorSearches)
                .HasForeignKey(a => a.Id_Author);
        }
    }
}
