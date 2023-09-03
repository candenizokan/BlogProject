﻿using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class UserFollewedCategoryMap : IEntityTypeConfiguration<UserFollewedCategory>
    {
        public void Configure(EntityTypeBuilder<UserFollewedCategory> builder)
        {
            //ikisi beraberce anahtardır.
            builder.HasKey(a => new { a.AppUserID, a.CategoryID });
        }
    }
}
