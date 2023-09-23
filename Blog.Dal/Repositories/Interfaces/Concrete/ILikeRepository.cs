using Blog.Model.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Dal.Repositories.Interfaces.Concrete
{
    public interface ILikeRepository
    {
        //like diğerleri gibi değil. ya oluşturursun ya silersin
        void Create(Like like);
        void Delete(Like like);

        //Like GetDefault(int id,string appUserId);//tek bir like nesnesi döndür

        Like GetDefault(Expression<Func<Like, bool>> expression);
    }
}
