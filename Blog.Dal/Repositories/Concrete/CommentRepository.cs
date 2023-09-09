using Blog.Dal.Context;
using Blog.Dal.Repositories.Abstract;
using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(ProjectContext context) : base(context)
        {
        }
    }
}
