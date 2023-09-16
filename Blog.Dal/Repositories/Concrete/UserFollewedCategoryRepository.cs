using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class UserFollewedCategoryRepository : IUserFollewedCategoryRepository
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<UserFollewedCategory> _table;

        public UserFollewedCategoryRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _table = _projectContext.Set<UserFollewedCategory>(); //böyle yaparak tablomu elde ettim
        }
        public void Delete(UserFollewedCategory entity)
        {
            //sileceğim nesne elimde. kendi tablosuna git remove et. sonra context üzerinden kaydet
            _table.Remove(entity);
            _projectContext.SaveChanges();
        }

        public UserFollewedCategory GetFollewedCategory(Expression<Func<UserFollewedCategory, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<UserFollewedCategory> GetFollowedCategories(Expression<Func<UserFollewedCategory, bool>> expression)
        {
            // kendi tablosuna git where ile expression yolla. liste haline getir sonuçları göster
            return _table.Where(expression).ToList();
        }
    }
}
