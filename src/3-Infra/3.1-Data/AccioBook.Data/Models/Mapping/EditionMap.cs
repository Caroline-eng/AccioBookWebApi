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
    public class EditionMap : IEntityTypeConfiguration<Edition>
    {
        public void Configure(EntityTypeBuilder<Edition> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id_Book);
            builder.Property(a => a.Id_Publisher);
            builder.Property(a => a.Id_Language);
            builder.Property(a => a.Cover);
            builder.Property(a => a.PublicationDate);
            builder.Property(a => a.PageCount);          
            builder.Property(a => a.ISBNCode_10);
            builder.Property(a => a.ISBNCode_13);

            builder.HasOne(a => a.Book)
             .WithMany(a => a.Editions)
             .HasForeignKey(a => a.Id_Book);

            builder.HasOne(a => a.Publisher)
               .WithMany(a => a.Editions)
               .HasForeignKey(a => a.Id_Publisher);

            builder.HasOne(a => a.Language)
               .WithMany(a => a.Editions)
               .HasForeignKey(a => a.Id_Language);
        }
    }
}
