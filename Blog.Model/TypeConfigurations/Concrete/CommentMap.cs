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
        
    }
}
