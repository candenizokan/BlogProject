using Blog.Dal.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public IActionResult Detail(int id)//makale id
        {
            return View();
        }
    }
}
