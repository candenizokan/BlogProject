using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    public class ArticleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Create()
        {
            //içerdeki kişiyi bulayım. user managera ihtiyacım var . di ile alacağım
            return View();
        }
    }
}
