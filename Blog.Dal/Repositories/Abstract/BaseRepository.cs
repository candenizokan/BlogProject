﻿using Blog.Dal.Context;
using Blog.Dal.Repositories.Interfaces.Abstract;
using Blog.Model.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Blog.Model.Models.Enums;

namespace Blog.Dal.Repositories.Abstract
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity//BaseEntity den ne tür gelirse gelsin tek bir base repository comet,category,article gelse crud yapacaksın
    {
        //benim dbcontext ile konuşmam lazım. ctor ile di.
        private readonly ProjectContext _context;
        private readonly DbSet<T> _table;//t tipi neyse onun tablosu gelsin

        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }
        public void Create(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.Statu = Statu.Passive;
            _context.SaveChanges();
        }

        public TResult GetByDefault<TResult>(
            Expression<Func<T, TResult>> selector, 
            Expression<Func<T, bool>> expression, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;//kendi tablomu atıyorum IQueryable tipine sorgulanabir bir tablosunu elde ettim
            if (include != null) query = include(query); //bütün joinleri yaptın gibi düşünebilirsin
            return query.Where(expression).Select(selector).FirstOrDefault();//karşılaştığım ilk getir
        }

        public List<TResult> GetByDefaults<TResult>(
            Expression<Func<T, TResult>> selector, 
            Expression<Func<T, bool>> expression, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
           
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
