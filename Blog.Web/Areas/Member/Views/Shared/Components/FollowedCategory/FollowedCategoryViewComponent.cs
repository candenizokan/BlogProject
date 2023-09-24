using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Member.Views.Shared.Components.FollowedCategory
{
    public class FollowedCategoryViewComponent:ViewComponent
    {
        //kullanıcının takip ettiği kategorileri sunmak

        //kategori repo içinde ihtiyacım olan metodu oluşturacğım.
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<AppUser> _userManager;

        public FollowedCategoryViewComponent(ICategoryRepository categoryRepository,UserManager<AppUser> userManager)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser appUser = await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);

            List<Category> list = _categoryRepository.GetCategoryWithId(appUser.Id);

            return View(list);
        }
    }
}
