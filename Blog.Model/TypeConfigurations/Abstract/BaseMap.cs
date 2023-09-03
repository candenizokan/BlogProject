using Blog.Model.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity//BaseEntityden kalıtım alanlar alanların propları konfigure ediyorum. bunu kullansın isterse kendide bir şey yazabiliyor olsun dediğim noktadan Configure'yi virtual yapmam lazım
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a=>a.ID);//primary key 
        }
    }
}
