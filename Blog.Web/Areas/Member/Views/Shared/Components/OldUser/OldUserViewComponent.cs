using Blog.Model.Models.Concrete;
using Blog.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Member.Views.Shared.Components.OldUser
{
    public class OldUserViewComponent : ViewComponent
    {
        //member areadaki anasayfada yani en eski ilk 4 kullanıcımızın ad, soyad, varsa fullname, id ve bu zamana kadarki toplam makale sayısını(aktif pasif herşey) ve aktif makale sayısını(pasif olmayan) gösteren ufak cad yapısına bu bilgileri basınız

        //userları getirceğim açin appuserrepoya ihtiyacım var. db den herkesi getirmem lazım 
        private readonly UserManager<AppUser> _userManager;

        public OldUserViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _userManager.Users
                        .Where(a => a.Statu != Model.Models.Enums.Statu.Passive)
                        .OrderBy(a => a.CreatedDate) 
                        .Select(a => new UserDetail
                        {
                            FullName = a.FullName,
                            UserID = a.Id,
                            AllArticleCount = a.Articles.Count,
                            AllNotPassiveArticleCount = a.Articles.Count(article => article.Statu != Model.Models.Enums.Statu.Passive)
                        }).Take(4).ToListAsync();

            return View(list);
        }
    }
}
