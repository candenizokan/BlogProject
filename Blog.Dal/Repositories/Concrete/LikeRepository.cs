using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //base'den almadığı için direkt siliyorum statuyu pasife çekme gibi bir durum yok burada
            _table.Remove(like);
            _context.SaveChanges();
        }

        public Like GetDefault(int id,string appUserId)
        {
            return _table.FirstOrDefault(like => like.ArticleID == id && like.AppUserID == appUserId);
        }
    }
}
