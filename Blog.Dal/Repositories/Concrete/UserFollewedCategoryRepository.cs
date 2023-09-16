using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<UserFollewedCategory> GetFollowedCategories(Expression<Func<UserFollewedCategory, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
