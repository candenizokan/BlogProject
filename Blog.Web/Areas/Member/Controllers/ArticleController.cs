using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.DTOs;
using Blog.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Blog.Model.Models.Enums;
using Blog.Dal.Repositories.Concrete;

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

            //articlecreate vm oluştur
            ArticleCreateVM vm = new ArticleCreateVM()
            {
                AppUserID = appUser.Id,
                Categories = _cRepo.GetByDefaults
                (
                    selector: a=> new GetCategoryDTO { ID = a.ID,Name=a.Name},
                    expression : a=> a.Statu != Statu.Passive
                )
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                //ArticleCreateVM nesnesi var Article çıkart diyeceğim. bunu mappers ile söylemem lazım. bir mapleme daha var. kaynak ArticleCreateVM varış noktam article nesnem. ctoda IMapperada ihtiyacım var şimdi 
                return RedirectToAction("List");
            }
            return View(vm);
        }
    }
}
