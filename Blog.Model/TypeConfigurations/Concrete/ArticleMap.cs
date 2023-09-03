using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class ArticleMap : IEntityTypeConfiguration<Article>//Article için db configurasyonu
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired(true);

            //navigation prop


            //category



            //user
        }
    }
}
