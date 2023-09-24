using Blog.Dal.Repositories.Interfaces.Concrete;
using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
