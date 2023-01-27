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
    public class GenreSearchMap : IEntityTypeConfiguration<GenreSearch>
    {
        public void Configure(EntityTypeBuilder<GenreSearch> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
              .WithMany(a => a.GenreSearches)
              .HasForeignKey(a => a.Id_User);

            builder.HasOne(a => a.Genre)
              .WithMany(a => a.GenreSearches)
              .HasForeignKey(a => a.Id_Genre);
        }
    }
}
