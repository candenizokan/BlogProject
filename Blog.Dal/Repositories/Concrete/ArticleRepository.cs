using Blog.Dal.Context;
using Blog.Dal.Repositories.Abstract;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class ArticleRepository : BaseRepository<Article>,IArticleRepository
    {
        public ArticleRepository(ProjectContext context) : base(context)//context alacam ben kullanmayacağım atam base'e göndereceğim yani baserepository'e yolladım
        {
        }
    }
}
