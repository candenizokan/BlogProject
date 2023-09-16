using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class UserFollewedCategoryRepository : IUserFollewedCategoryRepository
    {
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
