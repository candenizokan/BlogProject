using Blog.Model.Models.Concrete;
using Blog.Model.TypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Concrete
{
    public class CommentMap : BaseMap<Comment>
    {
        //basemapten gelen configure metodunu override edeceğim. artickemapte de bunu yapabilirdim

        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.Text).IsRequired(true);

            //navigation prop

            //user
            //bir komentin bir userı vardır.-- userın çokça yorumu var--bu ikisi birbirine bağlıdır appuserıd üzerinden
            builder.HasOne(a => a.AppUser).WithMany(a => a.Comments).HasForeignKey(a => a.AppUserID).OnDelete(DeleteBehavior.Restrict);

            //makale
            //bir yorum bir makaleye aittir.--bir makalede çokça yorum vardır--article id üzerinden bağlıdır.
            builder.HasOne(a => a.Article).WithMany(a => a.Comments).HasForeignKey(a => a.ArticleID).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }

    }
}
