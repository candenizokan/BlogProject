using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create()
        {
            //içerdeki kişiyi bulayım. user managera ihtiyacım var . di ile alacağım
            AppUser appUser = await _userManager.GetUserAsync(User);
            return View();
        }
    }
}
