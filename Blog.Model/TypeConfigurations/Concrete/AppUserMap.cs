using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>//AppUser için config yapıyorum
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.FirstName).IsRequired(true);
            builder.Property(a => a.LastName).IsRequired(true);
        }
    }
}
