﻿using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public interface IUserFollewedCategoryRepository// baseden kalıtım almadığından IBaseRepositoryden implemantasyon yapmaz.
    {
        void Delete(UserFollewedCategory entity);

        List<UserFollewedCategory> GetFollowedCategories(Expression<Func<UserFollewedCategory,bool>> expression);
    }
}
