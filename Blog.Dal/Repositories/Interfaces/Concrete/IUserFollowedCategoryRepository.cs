﻿using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Interfaces.Concrete
{
    public interface IUserFollewedCategoryRepository// baseden kalıtım almadığından IBaseRepositoryden implemantasyon yapmaz.
    {
        void Delete(UserFollewedCategory entity);

        List<UserFollewedCategory> GetFollowedCategories(Expression<Func<UserFollewedCategory, bool>> expression);

        UserFollewedCategory GetFollewedCategories(Expression<Func<UserFollewedCategory, bool>> expression);//tek bir nesneyi dönen değer
    }
}
