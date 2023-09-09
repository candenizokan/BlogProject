using Blog.Dal.Repositories.Interfaces.Abstract;
using Blog.Model.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Dal.Repositories.Abstract
{
    public class BaseRepository<T> :IBaseRepository<T> where T:BaseEntity
    {
    }
}
