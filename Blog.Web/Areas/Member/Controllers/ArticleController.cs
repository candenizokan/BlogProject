using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    public class ArticleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryRepository _cRepo;
        private readonly IArticleRepository _articleRepository;

        public ArticleController(UserManager<AppUser> userManager, ICategoryRepository cRepo, IArticleRepository articleRepository)
        {
            _userManager = userManager;
            _cRepo = cRepo;
            _articleRepository = articleRepository;
        }
        public IActionResult Create()
        {
            //içerdeki kişiyi bulayım. user managera ihtiyacım var . di ile alacağım
            return View();
        }
    }
}
