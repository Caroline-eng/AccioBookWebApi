using AccioBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccioBook.Data.Models.Mapping
{
    public class AccessMap : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DateAccess);
            builder.Property(a => a.DateOff);

            builder.HasOne(a => a.User)
               .WithMany(a => a.AccessA)
               .HasForeignKey(a => a.Id_User);            
        }
    }
}
