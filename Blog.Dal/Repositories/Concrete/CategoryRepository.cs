using Blog.Dal.Context;
using Blog.Dal.Repositories.Abstract;
using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Dal.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProjectContext context) : base(context)
        {
        }

        //kullanıcının takip ettiği kategorileri vermelsiin

        public List<Category> GetCategoryWithId(string id) 
        {//hem kategori hem userı taşayan erişmem lazım yani ara sınıfa gideğim user followedcategory db git bütün tabloyu bul bana bunları getirirken hangisinin appuserıd benim id ile eşleşirse onları getir.
            return _context.UserFollewedCategories.Include(a=>a.AppUser).Include(a=>a.Category).
                Where(a=> a.AppUserID==id).Select(a=>a.Category).ToList();

            //context üzerinden UserFollewedCategories e dahil et appuser ve categoryi
        }
    }
}
