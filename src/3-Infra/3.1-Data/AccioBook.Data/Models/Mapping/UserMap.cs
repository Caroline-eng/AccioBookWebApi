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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name);
            builder.Property(a => a.UserType);
            builder.Property(a => a.Password);
            builder.Property(a => a.UserGender);
            builder.Property(a => a.DateOfBirth);
            builder.Property(a => a.Email);

        }
    }
}
