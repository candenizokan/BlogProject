using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Web.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Model.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Web.Views.Shared.Components.ArticlesWith
{
    public class ArticlesWithViewComponent : ViewComponent
    {
        //En güncel 10 makaleyi getirelim
        private readonly IArticleRepository _articleRepository;

        


        public ArticlesWithViewComponent(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public IViewComponentResult Invoke()
        {

            //makalenin her şeyini veya bilgilerini getirmeyeceğim categorinin bzaı datalarını alacağım. list article almayacağım. neyi istiyorsam vm nesnesi ile almam lazım. şu şu dataları alacağım. hangi propları taşıyacağımı vm üzerindenn karar vereceğim
            //aktif makaleleri getir. sırala. 
            //article repoya itiyacım var di ile alacam


            List<GetArticleVM> list = _articleRepository.GetByDefaults
                (
                    selector: a => new GetArticleVM() // her articledan get article vm nesnesi vereceksin
                    {
                        Title = a.Title,
                        Content = a.Content,
                        ImagePath = a.ImagePath,
                        CreatedDate = a.CreatedDate,
                        UserFullName = a.AppUser.FullName,
                        CategoryName = a.Category.Name,
                        AppUserID = a.AppUserID,
                        ArticleID = a.ID
                    },
                    expression: a => a.Statu != Statu.Passive,
                    include: a => a.Include(a => a.Category).Include(a => a.AppUser),
                    orderBy: a => a.OrderByDescending(a => a.CreatedDate)
                ).Take(10).ToList() ;

            return View(list);
        }




    }
}
