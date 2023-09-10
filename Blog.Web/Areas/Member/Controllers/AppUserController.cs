using Blog.Model.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()//kişi yetkilidir. burada [AllowAnonymous] demeye gerek yok. içerdeki kişi dışarı çıkmak istiyor
        {
            await _signInManager.SignOutAsync();//_signInManager giriş çıkış işlemlerinde kullanılıyor. bu sınıfa ihtiyacım var di ile almalıyım
            return Redirect("~/");//RedirectToAction("Index","Home"); bu şekilde de kullanılabilir
        }
    }
}
