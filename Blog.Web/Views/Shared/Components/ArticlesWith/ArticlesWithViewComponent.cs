using Blog.Dal.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Mvc;

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




        }




    }
}
