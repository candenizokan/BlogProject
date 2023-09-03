using Blog.Model.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity    //generic type
    {
    }
}
