using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
               .WithMany(a => a.WishLists)
               .HasForeignKey(a => a.Id_User);

            builder               
               .HasOne(a => a.Book)
               .WithMany(a => a.WishLists)
               .HasForeignKey(a => a.Id_Book); 
        }
    }
}
