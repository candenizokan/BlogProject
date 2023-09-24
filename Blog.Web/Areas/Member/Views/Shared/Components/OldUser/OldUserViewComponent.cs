using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Views.Shared.Components.OldUser
{
    public class OldUserViewComponent :ViewComponent
    {
        //member areadaki anasayfada yani en eski ilk 4 kullanıcımızın ad, soyad, varsa fullname, id ve bu zamana kadarki toplam makale sayısını(aktif pasif herşey) ve aktif makale sayısını(pasif olmayan) gösteren ufak cad yapısına bu bilgileri basınız

        //userları getirceğim açin appuserrepoya ihtiyacım var. db den herkesi getirmem lazım 
        private readonly UserManager<AppUser> _userManager;

        public OldUserViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
