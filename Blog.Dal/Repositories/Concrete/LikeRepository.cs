using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ProjectContext _context;
        private readonly DbSet<Like> _table;

        public LikeRepository(ProjectContext context)
        {
            _context = context;
            _table= _context.Set<Like>();
        }
        public void Create(Like like)
        {
            _table.Add(like);
            _context.SaveChanges();
        }

        public void Delete(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
