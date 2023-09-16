using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Member.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
