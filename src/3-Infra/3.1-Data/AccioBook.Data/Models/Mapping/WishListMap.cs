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
    public class WishListMap : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id_User);
            builder.Property(a => a.Id_Book);
            builder.Property(a => a.IncludeDate);

            builder.HasOne(a => a.User)
               .WithOne(a => a.UserList)
               .HasForeignKey(a => a.Id_User);


            builder.HasMany(a => a.Book)
               .WithMany(a => a.BookList)
               .HasForeignKey(a => a.Id_Book);
        }
    }
}
