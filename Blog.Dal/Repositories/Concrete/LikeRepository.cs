using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ProjectContext _context;

        public LikeRepository(ProjectContext context)
        {
            _context = context;
        }
        public void Create(Like like)
        {
            throw new NotImplementedException();
        }

        public void Delete(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
