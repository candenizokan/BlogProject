using Blog.Model.Models.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity    //generic type
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetDefault(Expression<Func<T, bool>> expression);

        List<T> GetDefaults(Expression<Func<T, bool>> expression);

        TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector,
                                      Expression<Func<T, bool>> expression,
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                             Expression<Func<T, bool>> expression,
                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
                                               
    }
}
