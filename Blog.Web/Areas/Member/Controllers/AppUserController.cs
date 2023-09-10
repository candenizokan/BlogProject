using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
