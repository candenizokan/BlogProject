using Blog.Model.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.TypeConfigurations.Abstract
{
    public abstract class BaseMap<T>:IEntityTypeConfiguration<T> where T:BaseEntity
    {
    }
}
