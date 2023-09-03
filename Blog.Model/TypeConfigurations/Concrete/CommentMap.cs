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



            //makale


            base.Configure(builder);
        }

    }
}
